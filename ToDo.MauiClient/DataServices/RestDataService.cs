using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ToDo.MauiClient.Models;

namespace ToDo.MauiClient.DataServices
{
    public class RestDataService : IRestDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public RestDataService()
        {
            _httpClient = new HttpClient();
            _baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5075" : "https://localhost:7255";
            _url = $"{_baseAddress}/api";

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }
        public async Task AddToDoAsync(ToDoItem toDo)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No internet Access");
                return;
            }

            try
            {
                string jsonToDo = JsonSerializer.Serialize(toDo, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonToDo, Encoding.UTF8, "application/json");

                HttpResponseMessage resppnse = await _httpClient.PostAsync($"{_url}/todo", content);

                if (resppnse.IsSuccessStatusCode)
                {
                    Debug.WriteLine("to do created.");
                }
                else
                {
                    Debug.WriteLine("Non http 2xx response");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"exception: {ex.Message}");
            }
        }

        public async Task DeleteToDoAsync(int id)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No internet Access");
                return;
            }

            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{_url}/todo/{id}");
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("to do deleted.");
                }
                else
                {
                    Debug.WriteLine("Non http 2xx response");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"exception: {ex.Message}");
            }
            return;
        }

        public async Task<List<ToDoItem>> GetAllToDosAsync()
        {
            List<ToDoItem> todos = new List<ToDoItem>();

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No internet Access");
                return null;
            }
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/todo");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    todos = JsonSerializer.Deserialize<List<ToDoItem>>(content, _jsonSerializerOptions);
                }
                else
                {
                    Debug.WriteLine("Non http 2xx response");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"exception: {ex.Message}");
            }
            return todos;
        }

        public async Task UpdateToDoAsync(int id, ToDoItem toDo)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No internet Access");
                return;
            }

            try
            {
                string jsonToDo = JsonSerializer.Serialize(toDo, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonToDo, Encoding.UTF8, "application/json");

                HttpResponseMessage resppnse = await _httpClient.PutAsync($"{_url}/todo/{toDo.Id}", content);

                if (resppnse.IsSuccessStatusCode)
                {
                    Debug.WriteLine("to do created.");
                }
                else
                {
                    Debug.WriteLine("Non http 2xx response");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"exception: {ex.Message}");
            }
        }
    }
}
