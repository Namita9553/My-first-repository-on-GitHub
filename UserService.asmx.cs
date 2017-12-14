using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Data;

namespace RWA1
{
    /// <summary>
    /// Summary description for UserService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class UserService : System.Web.Services.WebService
    {

        [WebMethod]
        public void showAllFlats()
        {
            List<FlatData> listFlat = new List<FlatData>();
            string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select * from Flat_data1 ", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                FlatData fd = new FlatData();
                fd.Flat_no = Convert.ToInt32(rdr["Flat_no"]);
                fd.Floor = Convert.ToInt32(rdr["Floor"]);
                fd.User_id = rdr["User_id"].ToString();
                fd.Resident_count = Convert.ToInt32(rdr["Resident_count"]);
                fd.Flat_type = rdr["Flat_type"].ToString();
                fd.Parking_space = rdr["Parking_space"].ToString();
                fd.Date_of_own = rdr["Date_of_own"].ToString();
                listFlat.Add(fd);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(listFlat));
        }
        [WebMethod]
        public void searchFlatByFlatNo(int flat_no)
        {
            FlatData fd = new FlatData();
            string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Flat_data1 where Flat_no = @flat_no ", con);
            SqlParameter param = new SqlParameter()
            {
                ParameterName = "@flat_no",
                 Value = flat_no
        };

            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                
                fd.Flat_no = Convert.ToInt32(rdr["Flat_no"]);
                fd.Floor = Convert.ToInt32(rdr["Floor"]);
                fd.User_id = rdr["User_id"].ToString();
                fd.Resident_count = Convert.ToInt32(rdr["Resident_count"]);
                fd.Flat_type = rdr["Flat_type"].ToString();
                fd.Parking_space = rdr["Parking_space"].ToString();
                fd.Date_of_own = rdr["Date_of_own"].ToString();
              
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(fd));
        }
        [WebMethod]
        public void showFlatByUserId()
        {
            List<UserData> listUser = new List<UserData>();
            string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from User_data1 ;Select * from Flat_data1", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataView dataview = new DataView(ds.Tables[1]);
          foreach(DataRow rdr in ds.Tables[0].Rows)
            {
                UserData ud = new UserData();
                ud.User_id = rdr["User_id"].ToString();
                ud.User_name = rdr["User_name"].ToString();
                ud.User_number = Convert.ToInt32(rdr["User_number"]);

                List<FlatData> flatList = new List<FlatData>();
                foreach(DataRowView flatrow in dataview)
                {
                    DataRow flatdatarow = flatrow.Row;

                    FlatData fd = new FlatData();
                    fd.Flat_no = Convert.ToInt32(flatdatarow["Flat_no"]);
                    fd.Floor = Convert.ToInt32(rdr["Floor"]);
                    fd.User_id = flatdatarow["User_id"].ToString();
                    fd.Resident_count = Convert.ToInt32(flatdatarow["Resident_count"]);
                    fd.Flat_type = flatdatarow["Flat_type"].ToString();
                    fd.Parking_space = flatdatarow["Parking_space"].ToString();
                    fd.Date_of_own = flatdatarow["Date_of_own"].ToString();


                    flatList.Add(fd);
                   }

                ud.Flats = flatList;
                listUser.Add(ud);


            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(listUser));
        }
        public void searchFlatByUser(string user_id)
        {
            FlatData fd = new FlatData();
            string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Flat_data1 where User_id = @user_id ", con);
            SqlParameter param = new SqlParameter()
            {
                ParameterName = "@user_id",
                Value = user_id
            };

            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                fd.Flat_no = Convert.ToInt32(rdr["Flat_no"]);
                fd.Floor = Convert.ToInt32(rdr["Floor"]);
                fd.User_id = rdr["User_id"].ToString();
                fd.Resident_count = Convert.ToInt32(rdr["Resident_count"]);
                fd.Flat_type = rdr["Flat_type"].ToString();
                fd.Parking_space = rdr["Parking_space"].ToString();
                fd.Date_of_own = rdr["Date_of_own"].ToString();

            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(fd));
        }
    }

    }

