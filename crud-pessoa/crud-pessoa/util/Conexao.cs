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
        private static string _server = "localhost";
        private static string _database = "c#_projeto";
        private static string _user = "root";
        private static string _password = "";
        private static string _port = "3306";
        private static string _sslM = "none";

        private static string _connString = String.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}",
            _server, _port, _user, _password, _database, _sslM);

        public static MySqlConnection _connection = new MySqlConnection(_connString);

        public static void connectTest()
        {
             
            try
            {
                _connection.Open();

                Console.WriteLine("Connection Successful");

                _connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message + _connString);
            }

        }

        
    }
}

