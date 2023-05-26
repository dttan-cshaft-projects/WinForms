using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using DTO;


namespace DAL
{
    public class DALStudents : Connection
    {
        private static string _Table = "students";

        public int CountAll()
        {
            var sql = "SELECT count(*) FROM " + _Table + " ORDER BY ID ASC;";
            return ExecuteScalar(sql);
        }

        // read all data
        public MySqlDataReader ReadAll()
        {
            var sql = "SELECT * FROM " + _Table + " ORDER BY ID ASC;";
            return ExecuteReader(sql);
            
        }

        //create, update, delete
        public bool Crud(DTOStudents st, string action )
        {
            string sql = "";
            if (action == "I" )
            {
                sql = string.Format("INSERT INTO " + _Table + "(student_name, student_age, student_address, student_semester) VALUES ('{0}', '{1}', '{2}', '{3}')", st.Student_name, st.Student_age, st.Student_address, st.Student_semester);
            } else if (action == "U" )
            {
                sql = string.Format("UPDATE " + _Table + "SET student_name='{0}', student_age='{1}', student_address='{2}', student_semester='{3}'", st.Student_name, st.Student_age, st.Student_address, st.Student_semester);
            } else if (action == "D" )
            {
                sql = string.Format("DELETE FROM " + _Table + "WHERE id={0}", st.Student_Id);
            }
            
            if (String.IsNullOrEmpty(sql) )
            {
                return false;
            } else
            {
                return ExecuteNonQuery(sql);
            }
            
        }



    }
}
