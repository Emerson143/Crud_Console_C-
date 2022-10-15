using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_pessoa.util
{
    public class Conexao
     {
        
        public static void connect()
        {
            string server = "localhost";
            string database = "c#_projeto";
            string user = "root";
            string password = "";
            string port = "3306";
            string sslM = "none";

            string connString = String.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}", 
                server, port, user, password, database, sslM);

            var conn = new MySqlConnection(connString);
            try
            {
                conn.Open();

                Console.WriteLine("Connection Successful");

                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message + connString);
            }

        }

        
    }
}

