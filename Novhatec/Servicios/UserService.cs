using Novhatec.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Novhatec.Servicios
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl1 = "https://usuario-function.azurewebsites.net/api/user";
        private readonly string _baseUrl2 = "https://resultado-function.azurewebsites.net/api/user";

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UsuarioModel>> GetUsers()
        {
            var response = await _httpClient.GetAsync(_baseUrl1);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<UsuarioModel>>();
            }
            else
            {
                throw new ApiException($"Failed to get users: {response.StatusCode}");
            }
        }
        public async Task<List<ResultadoModel>> GetResults()
        {
            var response = await _httpClient.GetAsync(_baseUrl2);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<ResultadoModel>>();
            }
            else
            {
                throw new ApiException($"Failed to get users: {response.StatusCode}");
            }
        }

    }
}
