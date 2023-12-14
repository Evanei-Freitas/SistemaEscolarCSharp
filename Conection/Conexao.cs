using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectionBD
{
    public class Conexao
    {
        //Método para conexao com o banco de dados Mysql.
        public static MySqlConnection GetMyConnection()
        {
            MySqlConnection conn = null;
            string connectionstring = "server=localhost;User id=root;pwd='';database=escola";
            conn = new MySqlConnection(connectionstring);
            return conn;
        }
    }
}
