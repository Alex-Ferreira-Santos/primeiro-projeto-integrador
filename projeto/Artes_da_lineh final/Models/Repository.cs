using MySql.Data.MySqlClient;

namespace Artes_da_lineh_final.Models
{
    public abstract class Repository
    {
        protected const string _strConexao = "Database=artes;Data Source=localhost;User Id=root";
        protected MySqlConnection conexao=new MySqlConnection(_strConexao);
    }
}