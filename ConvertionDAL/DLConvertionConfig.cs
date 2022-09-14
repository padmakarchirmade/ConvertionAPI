using ConvertionDAL.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ConvertionDAL
{
    public class DLConvertionConfig
    {
        private readonly IConfiguration _configuration;
        public DLConvertionConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public ConvertionConfig GetConvertionConfig(string convertionType, ConvertionInput convertionInput)
        {
            ConvertionConfig convertionConfig = null;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "GetConvertionConfig";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ConvertionType", convertionType);
            cmd.Parameters.AddWithValue("FromUnit", convertionInput.FromUnit);
            cmd.Parameters.AddWithValue("ToUnit", convertionInput.ToUnit);
            
            var constr =this._configuration.GetConnectionString("ConfigDB");
            using (SqlConnection con = new SqlConnection(constr))
            {
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    convertionConfig = TransferRow(dt.Rows[0]);
                }
            }
            return convertionConfig;
        }

        ConvertionConfig TransferRow(DataRow dr)
        {
            ConvertionConfig convertionConfig = new ConvertionConfig();
            convertionConfig.ConvertionType =Convert.ToString( dr["ConvertionType"]);
            convertionConfig.FromUnit = Convert.ToString(dr["FromUnit"]);
            convertionConfig.ToUnit = Convert.ToString(dr["ToUnit"]);
            convertionConfig.ToValue = Convert.ToInt32(dr["ToValue"]);
            return convertionConfig;
        }
    }
}
