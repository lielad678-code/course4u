using Model;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyWebsite
{
    public static class GenericApiClient
    {

        private const string _baseUrl = "http://localhost:50300/";
        private static HttpClient _httpClient;

        public static void init()
        {
            if (_httpClient == null)
            {
                _httpClient = new HttpClient
                {
                    BaseAddress = new Uri(_baseUrl)
                };
            }
        }

        /// <summary>
        /// ביצוע בקשת GET גנרית
        /// </summary>
        /// <typeparam name="TResponse">סוג הנתונים שמוחזר מהשרת</typeparam>
        /// <param name="path">נתיב ה-API (לדוגמה: "api/users")</param>
        public static async Task<TResponse> GetAsync<TResponse>(string path)
        {
            init();
            var response = await _httpClient.GetAsync(path);
            response.EnsureSuccessStatusCode(); // זורק שגיאה אם הבקשה נכשלה

            return await response.Content.ReadFromJsonAsync<TResponse>();
        }

        /// <summary>
        /// ביצוע בקשת POST גנרית עם שליחת נתונים
        /// </summary>
        /// <typeparam name="TRequest">סוג הנתונים הנשלחים</typeparam>
        /// <typeparam name="TResponse">סוג הנתונים שמוחזר מהשרת</typeparam>
        /// <param name="path">נתיב ה-API</param>
        /// <param name="data">הנתונים לשליחה בגוף הבקשה</param>
        public static async Task<TResponse> PostAsync<TRequest, TResponse>(string path, TRequest data)
        {
            init();
            var response = await _httpClient.PostAsJsonAsync(path, data);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<TResponse>();
        }

        /// <summary>
        /// ביצוע בקשת PUT גנרית לעדכון נתונים
        /// </summary>
        public static async Task<TResponse> PutAsync<TRequest, TResponse>(string path, TRequest data)
        {
            init();
            var response = await _httpClient.PutAsJsonAsync(path, data);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<TResponse>();
        }

        /// <summary>
        /// ביצוע בקשת DELETE גנרית
        /// </summary>
        public static async Task DeleteAsync(string path)
        {
            init();
            var response = await _httpClient.DeleteAsync(path);
            response.EnsureSuccessStatusCode();
        }
    }
}