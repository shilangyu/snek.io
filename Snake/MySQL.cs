using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class MySQL
    {
        // properties
        string connectionString;
        string query;
        MySqlConnection myConn;
        MySqlDataReader result;
           
        public MySQL(string que)
        {
            Query = que;
            ConnectionString = "datasource=localhost;port=3306;database=preferences;username=clitcancer;password=adminadmin";
        }

        // functions
        public MySqlDataReader Exec(object[] args)
        {
            try
            {
                myConn = new MySqlConnection(connectionString);
                myConn.Open();

                MySqlCommand cmd = new MySqlCommand(Query, myConn);

                for (int i = 0; i < args.Length; i++)
                {
                    cmd.Parameters.Add(new MySqlParameter("param" + i, args[i]));
                }

                result = cmd.ExecuteReader();
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return result;
            }
        }
        public void NonExec(object[] args)
        {
            try
            {
                myConn = new MySqlConnection(connectionString);
                myConn.Open();

                MySqlCommand cmd = new MySqlCommand(Query, myConn);

                for (int i = 0; i < args.Length; i++)
                {
                    cmd.Parameters.Add(new MySqlParameter("param"+i, args[i]));
                }
                
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Close()
        {
            myConn.Close();
        }
         

        public string ConnectionString {set => connectionString = value; }
        public string Query { get => query; set => query = value; }
    }
}
