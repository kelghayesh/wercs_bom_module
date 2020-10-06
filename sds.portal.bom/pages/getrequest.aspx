<%@ Page Async="true" Title="Formula Request Options" Language="C#" MasterPageFile="~/_master/aspx.master" AutoEventWireup="true" CodeBehind="getrequest.aspx.cs" Inherits="SDS.Portal.Web.pages.getrequest" %>


<asp:Content ID="body_content_holder" ContentPlaceHolderID="body_content_holder" runat="server">
    <div >
        <br /><br /><br />
    </div>
  

    <table border="0">
    <tr>
    <td >
        <br />
        <a href="pass_comp_req.aspx">Create Simple Formula Request</a>
        <br /><br />
    </td>
    </tr>
    <tr>
    <td>
        <a href="target_bom_req.aspx">Create BOM Formula Request</a>
        <br /><br />
    </td>
    </tr>
   </table>
</asp:Content>
