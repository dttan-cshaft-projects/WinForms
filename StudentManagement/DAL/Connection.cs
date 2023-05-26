using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Connection
    {
        protected MySqlConnection _conn;
        static string host = "localhost";
        static string database = "university";
        static string userDB = "root";
        static string pwdDB = "_TanDoan@2023";
        public static string provider = "server=" + host + ";user=" + userDB + ";pwd=" + pwdDB + ";database=" + database + ";Connect Timeout=10000;charset=utf8;convertzerodatetime=true;";

        //protected MySqlConnection _conn = new MySqlConnection("server=147.121.56.227;user=autoload_data;pwd=DATAELS&Auto@{2022};database=au_avery;Connect Timeout=10000;charset=utf8;convertzerodatetime=true;");

        public bool Open()
        {
            try
            {
                //provider = "server=" + host + ";Database=" + database + ";User ID=" + userDB + ";Password=" + password;
                _conn = new MySqlConnection(provider);
                _conn.Open();
                return true;
            }
            catch (Exception er)
            {
                MessageBox.Show("Connection Error ! " + er.Message, "Information");
            }
            return false;
        }

        public void Close()
        {
            _conn.Close();
            //Giải phóng tài nguyên đang giữ
            _conn.Dispose();
        }

        public DataSet ExecuteDataSet(string sql)
        {
            //Connection open
            Open();

            try
            {
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, _conn);
                da.Fill(ds, "result");

                //Connection close
                Close();

                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);   
            }

            //Connection close
            Close();

            return null;
        }

        public MySqlDataReader ExecuteReader(string sql)
        {
            //Connection open
            Open();

            try
            {
                MySqlDataReader reader;
                MySqlCommand cmd = new MySqlCommand(sql, _conn);
                reader = cmd.ExecuteReader();

                //Connection close
                Close();

                return reader;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            //Connection close
            Close();

            return null;
        }



        public bool ExecuteNonQuery(string sql)
        {
            //Connection open
            Open();

            var affected = false;
            MySqlCommand cmd = _conn.CreateCommand();
            MySqlTransaction myTrans = _conn.BeginTransaction();
            // Must assign both transaction object and connection
            // to Command object for a pending local transaction
            cmd.Connection = _conn;
            cmd.Transaction = myTrans;

            try
            {
                //exe
                cmd.CommandText = sql;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    affected = true;

                    //commit transaction
                    myTrans.Commit();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                //Console.WriteLine("An exception of type " + e.GetType() + " was encountered while inserting the data.");
                //Console.WriteLine("Neither record was written to database.");

                try
                {
                    myTrans.Rollback();
                    
                }
                catch (SqlException ex)
                {
                    if (myTrans.Connection != null)
                    {
                        MessageBox.Show("An exception of type " + ex.GetType() + " was encountered while attempting to roll back the transaction.");
                       
                    }
                }

                
            }

            //Connection close
            Close();

            return affected;

        }


        public int ExecuteScalar(string sql)
        {
            //Connection open
            Open();

            var count = 0;

            try
            {
                
                MySqlCommand cmd = new MySqlCommand(sql, _conn);
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            //Connection close
            Close();

            return count;
        }

       




    }
}
