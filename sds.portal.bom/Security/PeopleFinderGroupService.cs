using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace PG.GPS.Services {

    /*
    This can be used to pull list of groups for a user, or list of users for a group, etc…
    http://peoplefinder.internal.pg.com/GDSGroupService.jrun
    Example to look up groups that I am in:
    http://peoplefinder.internal.pg.com/GDSGroupService.jrun?sysid=example&syspw=example1&op=getmembergroups&accountshortname=hodges.bc&attributes=name,domains
     */
    public class PeopleFinderGroupService {
        private const int REQUEST_TIMEOUT_SECONDS = 60;

        public static PeopleFinderGroupResponse LookupGroupInPeopleFinder(string groupDn)
        {
            string appConfigKey = "PeopleFinderGroupLookupUrl";
            
            string peopleFinderGroupLookupUrl = ConfigurationManager.AppSettings.Get(appConfigKey);
            if(string.IsNullOrWhiteSpace(peopleFinderGroupLookupUrl))
                throw new Exception("AppSettings value missing for "+appConfigKey);

            PeopleFinderGroupResponse response;
            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(string.Format(peopleFinderGroupLookupUrl, groupDn) );
                myRequest.Timeout = REQUEST_TIMEOUT_SECONDS * 1000;

                using (HttpWebResponse myResponse = (HttpWebResponse) myRequest.GetResponse())
                {
                    Encoding enc = Encoding.GetEncoding(1252); // Windows default  Code Page
                    StreamReader responseReader = new StreamReader(myResponse.GetResponseStream(), enc);
                    response = DeserializePeopleFinderResponse(responseReader);
                    responseReader.Close();
                }

            } catch (Exception e)
            {
                throw new Exception("There was an error looking up PeopleFinderGroup in PeopleFinder: "+e.Message, e);
            }

            return response;
        }

        /// <summary>
        /// Deserializes PeopleFinder response.
        /// </summary>
        /// <param name="input">People finder response as TextReader, Stream, or XmlReader</param>
        /// <returns></returns>
        public static PeopleFinderGroupResponse DeserializePeopleFinderResponse(object input) {
            if(input == null)
                return null;

            XmlSerializer xs = new XmlSerializer(typeof(PeopleFinderGroupResponse));
            if(input is TextReader)
                return xs.Deserialize((TextReader)input) as PeopleFinderGroupResponse;

            if(input is Stream)
                return xs.Deserialize((Stream)input) as PeopleFinderGroupResponse;

            if(input is XmlReader)
                return xs.Deserialize((XmlReader)input) as PeopleFinderGroupResponse;

            throw new Exception("Unknown input Type for Deserialization: " + input.GetType());
        }

        [XmlRoot("GDSGroupService")]
        public class PeopleFinderGroupResponse {
            [XmlArray("results")]
            [XmlArrayItem("group")]
            public PeopleFinderGroup[] Results { get; set; }

            // Error info below:
            [XmlElement("message-code")]
            public string ErrorCode;

            [XmlElement("message-text")]
            public string ErrorText;

            [XmlElement("message-detail")]
            public string ErrorDetail;

            public string ErrorTextOrDetail => this.ErrorText ?? this.ErrorDetail ?? "Code: "+this.ErrorCode;

            public bool IsError => this.ErrorCode != null || this.ErrorText != null || this.ErrorDetail != null;

            public bool HasResponse => this.ResultCount > 0;

            public int ResultCount => this.Results?.Length ?? -1;

        }

        public class PeopleFinderGroup {
            [XmlAttribute("dn")]
            public string Dn { get; set; }

            [XmlAttribute("type")]
            public string Type { get; set; }

            [XmlElement("name")]
            public string Name { get; set; }

            [XmlElement("description")]
            public string Description { get; set; }

            [XmlElement("owner")]
            public PeopleFinderPrinciple Owner { get; set; }

            [XmlArray("members")]
            [XmlArrayItem("member")]
            public PeopleFinderPrinciple[] Members { get; set; }

            public bool HasMembers => this.MemberCount > 0;

            public int MemberCount => this.Members?.Length ?? -1;

            // TODO: Domains;
            // TODO: Delegates;
        }

        public class PeopleFinderPrinciple {
            // attributes
            [XmlAttribute("dn")]
            public string LdapPath { get; set; }

            [XmlAttribute("type")]
            public string Type { get; set; } // Note: could be Enum, but possible values are currently unknown

            // valued elements
            [XmlElement("ExtShortName")]
            public string ShortName { get; set; }

            [XmlElement("telephoneNumber")]
            public string Telephone { get; set; }

            [XmlElement("FaxNumber")]
            public string FaxNumber { get; set; }

            [XmlElement("mail")]
            public string Email { get; set; }

            [XmlElement("uid")]
            public string TNumber { get; set; }

            [XmlElement("givenName")]
            public string FirstName { get; set; }

            [XmlElement("sn")]
            public string LastName { get; set; }

            [XmlElement("cn")]
            public string DisplayName { get; set; }

        }
    }

}
