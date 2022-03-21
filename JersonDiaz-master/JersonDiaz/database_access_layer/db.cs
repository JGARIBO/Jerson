using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using JersonDiaz.Controllers;
using JersonDiaz.Data;
using Microsoft.Extensions.Logging;

namespace JersonDiaz.database_access_layer
{
    public class db
    {
        SqlConnection con = new SqlConnection("Data Source=workstation id=Jerson-Diaz.mssql.somee.com;packet size=4096;user id=JGARIBO_SQLLogin_1;pwd=6d3e93qkx4;data source=Jerson-Diaz.mssql.somee.com;persist security info=False;initial catalog=Jerson-Diaz;");


        //Get Country List

        //public DataSet GetCountry()
        //{
        //    SqlCommand com = new SqlCommand("Sp_Country", con);
        //    com.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter da = new SqlDataAdapter(com);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    return ds;
        //}
        //public DataSet GetState(int cid)
        //{
        //    SqlCommand com = new SqlCommand("Sp_State", con);
        //    com.CommandType = CommandType.StoredProcedure;
        //    com.Parameters.AddWithValue("@Country_id", cid);
        //    SqlDataAdapter da = new SqlDataAdapter(com);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    return ds;
        //}

      
        public DataSet GetPrestamos(int ? ClienteId)
        {
            SqlCommand com = new SqlCommand("sp_ListarPrestamos", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@IdCliente", ClienteId);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}
