using Novhatec.Models;
namespace Novhatec.Servicios
{
    public interface IUserService
    {
        Task<List<UsuarioModel>> GetUsers();
        Task<List<ResultadoModel>> GetResults();
    }
}
