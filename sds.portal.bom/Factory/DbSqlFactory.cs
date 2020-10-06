using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace SDS.SDSRequest.Factory
{
    public class DbSqlFactory
    {
        private static string SqlConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["SDSRequestDbContext"].ToString();

        public static DataTable GetRequestProducts(int requestId)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("exec usp_SDSREQ_GetRequestProducts @RequestId=" + Convert.ToString(requestId), SqlConnStr);
            sda.Fill(dt);
            sda.Dispose();
            return dt;
        }

        public static DataSet GetRequestProductsProperties(int requestTypeId, int requestId, string productId)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter sda;
            if (string.IsNullOrEmpty(productId))
                sda = new SqlDataAdapter("exec usp_SDSREQ_GetRequestProperties @RequestId=" + Convert.ToString(requestId), SqlConnStr);
            else
                sda = new SqlDataAdapter("exec usp_SDSREQ_GetRequestProperties @RequestId=" + Convert.ToString(requestId) + ", @ProductId=" + productId, SqlConnStr);

            sda.Fill(ds, "requestproperties");

            if (string.IsNullOrEmpty(productId))
                sda.SelectCommand.CommandText = "exec usp_SDSREQ_GetRequestProducts @RequestId=" + Convert.ToString(requestId);
            else
                sda.SelectCommand.CommandText = "exec usp_SDSREQ_GetRequestProducts @RequestId=" + Convert.ToString(requestId) + ", @ProductId=" + productId;
            sda.Fill(ds, "requestproducts");

            sda.SelectCommand.CommandText = "exec usp_SDSREQ_GetProductProperties @RequestTypeId=" + Convert.ToString(requestTypeId);
            sda.Fill(ds, "productproperties");

            sda.Dispose();

            return ds;
        }
        public static void AddRequestProduct(int requestId, string productId, string productName, bool? isPrestige, bool? isSDSExist, string sDSChangeReason, bool? needBothSDSAvailableConcurrently)
        {
            SqlConnection conn = new SqlConnection(SqlConnStr);
            conn.Open();
            SqlCommand comm = new SqlCommand("inserting", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "usp_SDSREQ_AddRequestProduct";
            SqlParameter[] param = {new SqlParameter("@RequestId", requestId),
                        new SqlParameter("@ProductId", productId),
                        new SqlParameter("@ProductName", productName),
                        new SqlParameter("@IsPrestige", isPrestige.HasValue ? (object)isPrestige : (object)DBNull.Value),
                        new SqlParameter("@IsSDSExist", isSDSExist),
                        new SqlParameter("@SDSChangeReason", string.IsNullOrEmpty(sDSChangeReason) ? (object)DBNull.Value : sDSChangeReason),
                        new SqlParameter("@NeedBothSDSAvailableConcurrently", needBothSDSAvailableConcurrently.HasValue ? (object)needBothSDSAvailableConcurrently : (object)DBNull.Value)
                        };
            comm.Parameters.AddRange(param);
            comm.ExecuteNonQuery();

            /*
            db.Database.ExecuteSqlCommand(
                        @"EXEC usp_SDSREQ_AddRequestProduct @RequestId, @ProductId, @ProductName, @IsPrestige,
                            @IsSDSExist, @SDSChangeReason, @NeedBothSDSAvailableConcurrently",
                        
                        new SqlParameter("@RequestId", requestId),
                        new SqlParameter("@ProductId", productId),
                        new SqlParameter("@ProductName", productName),
                        new SqlParameter("@IsPrestige", isPrestige.HasValue ? (object)isPrestige : (object)DBNull.Value),
                        new SqlParameter("@IsSDSExist", isSDSExist),
                        new SqlParameter("@SDSChangeReason", string.IsNullOrEmpty(sDSChangeReason) ? (object)DBNull.Value : sDSChangeReason),
                        new SqlParameter("@NeedBothSDSAvailableConcurrently", needBothSDSAvailableConcurrently.HasValue ? (object)needBothSDSAvailableConcurrently : (object)DBNull.Value)
                //new SqlParameter("@NeedBothSDSAvailableConcurrently", 0)
                    );
            //Incorrect syntax near '@IsSDSExist'. >> There was a missing comma inside your sqlstmt string constant
            */
        }

        public static void UpdateRequestProduct(int requestId, string productId, string productName, bool? isPrestige, bool? isSDSExist, string sDSChangeReason, bool? needBothSDSAvailableConcurrently)
        {
            SqlConnection conn = new SqlConnection(SqlConnStr);
            conn.Open();
            SqlCommand comm = new SqlCommand("updating", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "usp_SDSREQ_UpdateRequestProduct";
            SqlParameter[] param = {
                        new SqlParameter("@RequestId", requestId),
                        new SqlParameter("@ProductId", productId),
                        new SqlParameter("@ProductName", productName),
                        new SqlParameter("@IsPrestige", (object)isPrestige ?? DBNull.Value),
                        new SqlParameter("@IsSDSExist", (object)isSDSExist ?? DBNull.Value),
                        new SqlParameter("@SDSChangeReason", string.IsNullOrEmpty(sDSChangeReason) ? (object)DBNull.Value : sDSChangeReason),
                        new SqlParameter("@NeedBothSDSAvailableConcurrently", (object)needBothSDSAvailableConcurrently ?? DBNull.Value)
                        };
            comm.Parameters.AddRange(param);
            comm.ExecuteNonQuery();

            /*
            db.Database.ExecuteSqlCommand(
                        @"EXEC usp_SDSREQ_UpdateRequestProduct @RequestId, @ProductId, @ProductName, @IsPrestige,
                            @IsSDSExist, @SDSChangeReason, @NeedBothSDSAvailableConcurrently",
                        new SqlParameter("@RequestId", requestId),
                        new SqlParameter("@ProductId", productId),
                        new SqlParameter("@ProductName", productName),
                        new SqlParameter("@IsPrestige", (object)isPrestige ?? DBNull.Value),
                        new SqlParameter("@IsSDSExist", (object)isSDSExist ?? DBNull.Value),
                        new SqlParameter("@SDSChangeReason", string.IsNullOrEmpty(sDSChangeReason) ? (object)DBNull.Value : sDSChangeReason),
                        new SqlParameter("@NeedBothSDSAvailableConcurrently", (object)needBothSDSAvailableConcurrently ?? DBNull.Value)
                    );
            */
        }

        public static void AddRequestProductProperty(int requestId, string productId, string productPropertyDataCode, string propertyValue)
        {
            SqlConnection conn = new SqlConnection(SqlConnStr);
            conn.Open();
            SqlCommand comm = new SqlCommand("inserting", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "usp_SDSREQ_AddRequestProductProperty";
            SqlParameter[] param = {
                        new SqlParameter("@RequestId", requestId),
                        new SqlParameter("@ProductId", productId),
                        new SqlParameter("@PropertyDataCode", productPropertyDataCode),
                        new SqlParameter("@PropertyValue", propertyValue)
                        };
            comm.Parameters.AddRange(param);
            comm.ExecuteNonQuery();

            /*            
                        db.Database.ExecuteSqlCommand(
                        @"EXEC usp_SDSREQ_AddRequestProductProperty @RequestId, @ProductId, @PropertyDataCode, @PropertyValue",
                        new SqlParameter("@RequestId", requestId),
                        new SqlParameter("@ProductId", productId),
                        new SqlParameter("@PropertyDataCode", productPropertyDataCode),
                        new SqlParameter("@PropertyValue", propertyValue)
                    );
            */
        }

        public static void UpdateRequestProductProperty(int requestId, string productId, string productPropertyDataCode, string propertyValue)
        {
            int i = 0;

        }

        public static void DeleteRequestProduct(int requestId, string productId)
        {
            SqlConnection conn = new SqlConnection(SqlConnStr);
            conn.Open();
            SqlCommand comm = new SqlCommand("deleting", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "usp_SDSREQ_DeleteRequestProduct";
            SqlParameter[] param = {
                        new SqlParameter("@RequestId", requestId),
                        new SqlParameter("@ProductId", productId)
                        };
            comm.Parameters.AddRange(param);
            comm.ExecuteNonQuery();

            /*            
            db.Database.ExecuteSqlCommand(
                        @"EXEC usp_SDSREQ_DeleteRequestProduct @RequestId, @ProductId",
                        new SqlParameter("@RequestId", requestId),
                        new SqlParameter("@ProductId", productId)
            );
            */
        }

        /*
        public static int SubmitCompassRequest(string requester, string requestDate, string requestInfo, List<CompassGCAS> requestedList)
        {
            SqlConnection conn = new SqlConnection(SqlConnStr);
            conn.Open();
            SqlCommand comm = new SqlCommand("inserting header", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "usp_SDSREQ_AddFormulaImportRequestHeader";

            SqlParameter[] param1 = {
                        new SqlParameter("@RequestDescr", requestInfo),
                        new SqlParameter("@RequestStatus", "New"),
                        new SqlParameter("@UpdatedBy", requester)
                        };

            SqlParameter newRequestId = new SqlParameter("@requestId", System.Data.SqlDbType.Int);
            newRequestId.Direction = System.Data.ParameterDirection.Output;

            comm.Parameters.AddRange(param1);
            comm.Parameters.Add(newRequestId);
            comm.ExecuteNonQuery();

            int requestId = Convert.ToInt32(newRequestId.Value);

            string fpcOverride;
            comm = new SqlCommand("inserting products", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "usp_SDSREQ_AddFormulaImportRequestProduct";

            foreach (CompassGCAS gcas in requestedList)
            {
                if (gcas.FPC_Override) fpcOverride = "N";
                else fpcOverride = "Y";

                SqlParameter[] param2 = {
                        new SqlParameter("@RequestId", requestId),
                        new SqlParameter("@ProductId", gcas.ProductId),
                        new SqlParameter("@FPC_Override", fpcOverride)
                        };
                comm.Parameters.AddRange(param2);
                comm.ExecuteNonQuery();
                comm.Parameters.Clear();
                //Array.Clear(param2,0,param2.Length);
            }

            comm = new SqlCommand("submitting request", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "usp_SDSREQ_SubmitCompassRequest";
            SqlParameter[] param3 = {
                        new SqlParameter("@RequestId", requestId),
                        };
            comm.Parameters.AddRange(param3);
            comm.ExecuteNonQuery();

            return requestId;
        }
        */
    }
}