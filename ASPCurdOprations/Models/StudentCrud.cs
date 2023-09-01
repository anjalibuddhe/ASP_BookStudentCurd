using System.Collections.Generic;
using System.Data.SqlClient;

namespace ASPCurdOprations.Models
{
    public class StudentCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;

        public StudentCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(configuration.GetConnectionString("defaultConnection"));
        }

        public IEnumerable<Student> GetAllStudents()
        {
            List<Student> list=new List<Student> ();

            string qry = "select * from Student where isActive=1";
            cmd = new SqlCommand(qry, con);

            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while(dr.Read())
                {
                    Student s = new Student();
                    s.Id = Convert.ToInt32(dr["id"]);
                    s.Name = dr["name"].ToString();
                    s.Course = dr["course"].ToString();
                    s.Duration = dr["duration"].ToString();
                    s.isActive = Convert.ToInt32(dr["isActive"]);
                    list.Add(s);
                }
            }
            con.Close();
            return list;

        }


        public Student GetStudentById(int id)
        {
            Student s = new Student();
            string qry = "select * from Student where @id=id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    s.Id = Convert.ToInt32(dr["id"]);
                    s.Name = dr["name"].ToString();
                    s.Course = dr["course"].ToString();
                    s.Duration = dr["duration"].ToString();
                    s.isActive = Convert.ToInt32(dr["isActive"]);
                }
            }
            con.Close();
            return s;
        }

       
        public int AddStudent(Student student)
        {
            student.isActive = 1;
            int result = 0;
            string qry = "insert into Student values(@name,@course,@duration,@isActive)";
            cmd= new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@course", student.Course);
            cmd.Parameters.AddWithValue("@duration", student.Duration);
            cmd.Parameters.AddWithValue("@isActive", student.isActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateStudent(Student student)
        {
            student.isActive = 1;
            int result = 0;
            string qry = "Update Student set name=@name, course=@course,duration=@duration,isActive=@isActive where id=@id";
            cmd = new SqlCommand(qry, con);

            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@course", student.Course);
            cmd.Parameters.AddWithValue("@duration", student.Duration);
            cmd.Parameters.AddWithValue("@isActive", student.isActive);
            cmd.Parameters.AddWithValue("@id", student.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int DeleteStudent(int id)
        {
            int result = 0;
            string qry = "update Student set isActive=0 where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }



    }
}
