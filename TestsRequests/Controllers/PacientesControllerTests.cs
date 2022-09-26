using Desafio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TestsRequests.Utils;
using Xunit;

namespace TestsRequests.Controllers
{
    public class PacientesControllerTests
    {
        /// <summary>
        /// Testar a requisição Get para todos os pacientes.
        /// Este teste só irá funcionar se a API estiver funcionando sem modo Debug
        /// </summary>
        [Fact]
        public void TestGetTodosPacientes()
        {

            var statusCode = 0;
            var msg = string.Empty;
            string baseUrlPaciente = "https://localhost:44323/api/pacientes";
            try
            {
                var email = "marge@simpsons.com";
                var senha = "marge123456";
                var token = RequestTokenAPI.GetToken(email, senha);
                var urlParams = "";
                var http = new HttpClient { BaseAddress = new Uri($"{baseUrlPaciente}") };

                http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                http.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = http.GetAsync(urlParams).Result;

                var retorno = JsonSerializer.Deserialize<List<Paciente>>(response.Content.ReadAsStringAsync().Result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                statusCode = (int)response.StatusCode;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                statusCode = 500;
            }

            // Retorno
            Assert.Equal(200, statusCode);
        }
    }
}
