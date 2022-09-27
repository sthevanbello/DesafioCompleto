using Desafio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TestsRequests.Utils
{
    public static class RequestTokenAPI
    {

        /// <summary>
        /// Método para recuperar o Token a partir das chamadas HttpWebRequest e HttpWebResponse
        /// </summary>
        /// <param name="email">email recebido para realizar a autenticação</param>
        /// <param name="senha">senha recebida para realizar a autenticação</param>
        /// <returns>Retorna um token válido por 30 minutos</returns>
        public static string GetToken(Autenticar login)
        {
            const string baseUrl = "https://localhost:44323/api/";
            var json = JsonSerializer.Serialize(login);

            var data = Encoding.ASCII.GetBytes(json);

            string path = $"{baseUrl}_Autenticar"; 
            HttpWebRequest request = WebRequest.CreateHttp(path);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;
            request.UserAgent = "RequestToken";
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            HttpWebResponse responseToken = (HttpWebResponse)request.GetResponse();
            var token = new StreamReader(responseToken.GetResponseStream()).ReadToEnd();
            return token;
        }
    }
}
