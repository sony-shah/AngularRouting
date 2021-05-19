using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Data.SqlClient;

namespace Routing
{
    /// <summary>
    /// Summary description for StudentService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class StudentService : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetAllStudents()
        {
            List<Student> listStudents = new List<Student>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from Students", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Student s = new Student();
                    s.id = Convert.ToInt32(rdr["Id"]);
                    s.name = rdr["Name"].ToString();
                    s.gender = rdr["Gender"].ToString();
                    s.city = rdr["City"].ToString();
                    listStudents.Add(s);


                }

            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(listStudents));

        }
    
    }
}
