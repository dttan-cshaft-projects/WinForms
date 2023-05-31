using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using DTO;

namespace DAL
{
    public class DALAccounts : Connection
    {
        private static string _Table = "accounts";

        public int CountAll()
        {
            var sql = "SELECT count(*) FROM " + _Table + " ORDER BY username ASC;";
            return ExecuteScalar(sql);
        }

        // read all data
        public MySqlDataReader ReadAll()
        {
            var sql = "SELECT * FROM " + _Table + " ORDER BY username ASC;";
            return ExecuteReader(sql);

        }

        //create, update, delete
        public bool Crud(DTOAccounts acc, string action)
        {
            string sql = "";
            if (action == "I")
            {
                sql = string.Format("INSERT INTO " + _Table + "(username, password) VALUES ('{0}', '{1}'')", acc.Username, acc.Password);
            }
            else if (action == "U")
            {
                sql = string.Format("UPDATE " + _Table + "SET password='{0}'", acc.Password);
            }
            else if (action == "D")
            {
                sql = string.Format("DELETE FROM " + _Table + " WHERE username={0}", acc.Username);
            }

            if (String.IsNullOrEmpty(sql))
            {
                return false;
            }
            else
            {
                return ExecuteNonQuery(sql);
            }

        }

        public bool Login(DTOAccounts acc )
        {
            string sql = string.Format("SELECT count(*) FROM " + _Table + " WHERE username='{0}' AND password='{1}'", acc.Username, acc.Password);
            int check = ExecuteScalar(sql);
            if (check > 0)
                return true;

            return false;

        }
    }
}
