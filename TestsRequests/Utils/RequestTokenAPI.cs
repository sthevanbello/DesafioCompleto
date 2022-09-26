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


        public static string GetToken(string email, string senha)
        {
            const string baseUrl = "https://localhost:44323/api/";
            var json = JsonSerializer.Serialize(new { email, senha });

            var data = Encoding.ASCII.GetBytes(json);

            string path = $"{baseUrl}Logins";
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
