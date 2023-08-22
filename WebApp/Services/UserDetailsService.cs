using System.Net.Http.Headers;
using Newtonsoft.Json;
using RegisterUserAPI.Models;
using WebApp.Services.interfaces;
using WebApp.Helpers;

namespace WebApp.Services{
    public class UserDetailsService: IUserDetailsService
    {
        private readonly HttpClient _httpClient;
        public UserDetailsService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            if (_httpClient.BaseAddress != null)
            {
                //_httpClient.BaseAddress = new Uri("https://localhost:7173/");
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                // optional
                _httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            }
        }

        public async Task<IEnumerable<UserDetails>> GetAllUserDetails()
        {
            List<UserDetails>? userDetailsList = new();
            HttpResponseMessage response = await _httpClient.GetAsync("api/UserDetails");
            if(response.IsSuccessStatusCode)
            {
                string userDetailsAsString = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(userDetailsAsString))
                {
                    userDetailsList = JsonConvert.DeserializeObject<List<UserDetails>>(userDetailsAsString);
                }
            }

            return userDetailsList ?? new();
        }

        public async Task<UserDetails> GetUserDetailsById(int? id)
        {
            UserDetails? userDetails = null;
            HttpResponseMessage response = await _httpClient.GetAsync($"api/UserDetails/{id}");

            if(response.IsSuccessStatusCode)
            {
                string userDetailsAsString = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(userDetailsAsString))
                {
                    userDetails = JsonConvert.DeserializeObject<UserDetails>(userDetailsAsString);
                }
            }

            return userDetails ?? new();
        }

        public async Task<string> EditUserDetails(int id, UserDetails userDetails)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"api/UserDetails/{id}", userDetails);

            if(response.IsSuccessStatusCode)
            {
                return "Success";
            }

            return "Failed";
        }

        public async Task<UserDetails> AddUserDetails(UserDetails userDetails)
        {
            UserDetails? userDetailsPostRes = new();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/UserDetails", userDetails);

            if (response.IsSuccessStatusCode)
            {
                // using my own extension ReadContentAsync<T>()
                userDetailsPostRes = await response.ReadContentAsync<UserDetails>();
            }

            return userDetailsPostRes ?? new();
        }

        public async Task<string> DeleteUserDetails(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/UserDetails/{id}");

            if(response.IsSuccessStatusCode)
            {
                return "Success";
            }

            return "Failed";
        }
    }
}