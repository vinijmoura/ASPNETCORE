using System.Data;

namespace AppWeb.Repositorio
{
    public interface IConexao
    {
        IDbConnection AbrirConexao(); 
    }
}