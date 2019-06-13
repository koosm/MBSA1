using MBSA.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MBSA.Models.DataProvider
{
    public class ProjectRepository:IProjectRepo
    {
        public List<Project> GetProjects(int pageSize,int pageNumber)
        {
            List<Project> projects = new List<Project>();
            using (SqlCommand sqlCommand = new SqlCommand("select * from Projects", new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=MBSATest;Integrated Security=True")))
            {
                DataTable dt = new DataTable();
                sqlCommand.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                adapter.Fill(dt);
                sqlCommand.Connection.Close();
                foreach (DataRow row in dt.Rows)
                {
                    projects.Add(new Project
                    {
                        Deleted = Convert.ToBoolean(row["Deleted"]),
                        Description = row["Description"].ToString(),
                        ID = Convert.ToInt32(row["ID"]),
                        Image = row["Image"].ToString(),
                        ProjectName = row["ProjectName"].ToString()
                    });
                }
            }
            return projects.Skip(pageNumber * pageSize).Take(pageSize).ToList();
        }
        public int GetTotalCount()
        {
            int count = 0;
            using (SqlCommand sqlCommand = new SqlCommand("select count(*) from Projects", new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=MBSATest;Integrated Security=True")))
            {
                sqlCommand.Connection.Open();
                count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                sqlCommand.Connection.Close();
             
            }
            return count;
        }
    }
}

