using System.Net.Http.Headers;
using System.Text.Json;
using EmergencyService.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace EmergencyService.Infrastructure.ExternalServices
{
    public class HospitalClient : IHospitalClient
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HospitalClient(HttpClient httpClient, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _httpClient.BaseAddress = new Uri(configuration["HospitalService:BaseUrl"] ?? "https://localhost:7164");
        }

        private void AddAuthHeader()
        {
            var authHeader = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authHeader.Substring(7));
            }
        }

        public async Task<bool> CheckHospitalAvailabilityAsync(int hospitalId)
        {
            AddAuthHeader();
            var response = await _httpClient.GetAsync("/api/hospital");
            if (!response.IsSuccessStatusCode) return false;

            var content = await response.Content.ReadAsStringAsync();
            var hospitals = JsonSerializer.Deserialize<List<HospitalInfo>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            
            var hospital = hospitals?.FirstOrDefault(h => h.Id == hospitalId);
            return hospital != null && hospital.AvailableBeds > 0;
        }

        public async Task<bool> ReserveBedAsync(int hospitalId)
        {
            AddAuthHeader();
            // Assuming we have a way to decrement beds. We can use the PATCH /api/hospital/{id}/beds endpoint
            // First get the hospital to see current count
            var response = await _httpClient.GetAsync("/api/hospital");
            if (!response.IsSuccessStatusCode) return false;

            var content = await response.Content.ReadAsStringAsync();
            var hospitals = JsonSerializer.Deserialize<List<HospitalInfo>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            var hospital = hospitals?.FirstOrDefault(h => h.Id == hospitalId);

            if (hospital == null || hospital.AvailableBeds <= 0) return false;

            // Decrement bed count
            var updateRequest = new { availableBeds = hospital.AvailableBeds - 1 };
            var patchContent = new StringContent(JsonSerializer.Serialize(updateRequest), System.Text.Encoding.UTF8, "application/json");
            
            var patchResponse = await _httpClient.PatchAsync($"/api/hospital/{hospitalId}/beds", patchContent);
            return patchResponse.IsSuccessStatusCode;
        }

        private class HospitalInfo
        {
            public int Id { get; set; }
            public int AvailableBeds { get; set; }
        }
    }
}
