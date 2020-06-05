using System.Data;
using MySql.Data.MySqlClient;

namespace AppWeb.Repositorio
{
    public class Conexao : IConexao
    {
        public IDbConnection AbrirConexao()
        {
//           using(MySqlConnection conn = new MySqlConnection("Server=localhost; Port=3306; Database=lojaSexta; Uid=root; Pwd='';"))
           using(MySqlConnection conn = new MySqlConnection("Server=uninovexavier.mysql.database.azure.com; Port=3306; Database=sexta; Uid=xavier7132@uninovexavier; Pwd=Th_618401212; SslMode=Preferred;"))
           {
               conn.Open();
               return conn;
           }
        }
    }
}