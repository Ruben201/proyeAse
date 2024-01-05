using System.Text;
using System.Text.Json;
using System.Net;
using Aseguradora.Models;
using Microsoft.Net.Http.Headers;

namespace Aseguradora.Services.Backend {
    public class AseguradoraService : IAseguradoraService
    {
        private const string REPORTE_ROUTE = "Reporte";
        private const string CONDUCTOR_ROUTE = "Conductor";
        private const string POLIZA_ROUTE = "Poliza";
        private const string USER_ROUTE = "User";
        private const string SIGNIN_ROUTE ="SignIn";
        private const string LOGIN_ROUTE = "Login";

        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        private string _token { get; set; }
        
        public AseguradoraService(IConfiguration configuration, IHttpClientFactory httpClientFactory){
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public void ConfigureAcessToken(string token)
        {
           _token = token;
        }

        public async Task<Conductor> DeleteConductorByIdAsync(string _Id)
        {
            Conductor conductor = null;
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, $"{_configuration["API_ROUTE"]}/{CONDUCTOR_ROUTE}/{_Id}"){
                Headers = { { HeaderNames.Authorization,"Bearer " + _token } },
            };
            var httpClient = _httpClientFactory.CreateClient();
            try
            {   
                var response = await httpClient.SendAsync(httpRequestMessage);
                if(response.IsSuccessStatusCode)
                {
                    conductor = await response.Content.ReadFromJsonAsync<Conductor>();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return conductor;
        }

        public async Task<Poliza> DeletePolizaById(string _Id)
        {
            Poliza poliza = null;
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, $"{_configuration["API_ROUTE"]}/{POLIZA_ROUTE}/{_Id}"){
                Headers = { { HeaderNames.Authorization,"Bearer " + _token } },
            };
            var httpClient = _httpClientFactory.CreateClient();
            try
            {   
                var response = await httpClient.SendAsync(httpRequestMessage);
                if(response.IsSuccessStatusCode)
                {
                    poliza = await response.Content.ReadFromJsonAsync<Poliza>();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return poliza;
        }

        public async Task<Reporte> DeleteReporteById(string _Id)
        {
            Reporte reporte = null;
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, $"{_configuration["API_ROUTE"]}/{REPORTE_ROUTE}/{_Id}"){
                Headers = { { HeaderNames.Authorization,"Bearer " + _token } },
            };
            var httpClient = _httpClientFactory.CreateClient();
            try
            {   
                var response = await httpClient.SendAsync(httpRequestMessage);
                if(response.IsSuccessStatusCode)
                {
                    reporte = await response.Content.ReadFromJsonAsync<Reporte>();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return reporte;
        }

        public async Task<Conductor> GetConductorByIdAsync(string _Id)
        {
             Conductor conductor = null;

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"{_configuration["API_ROUTE"]}/{CONDUCTOR_ROUTE}/{_Id}"){
                Headers = { { HeaderNames.Authorization,"Bearer " + _token } },
            };
            var httpClient = _httpClientFactory.CreateClient();
            try
            {   
                var response = await httpClient.SendAsync(httpRequestMessage);
                if(response.IsSuccessStatusCode)
                {
                    conductor = await response.Content.ReadFromJsonAsync<Conductor>();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return conductor;
        }

        public async Task<List<Poliza>> GetPolizasByIdConductor(string _Id)
        {
            List<Poliza> polizas = null;

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"{_configuration["API_ROUTE"]}/{POLIZA_ROUTE}/{_Id}")
            {
                Headers = { { HeaderNames.Authorization, "Bearer " + _token } },
            };
            var httpClient = _httpClientFactory.CreateClient();
            try
            {
                var response = await httpClient.SendAsync(httpRequestMessage);
                if (response.IsSuccessStatusCode)
                {
                    polizas = await response.Content.ReadFromJsonAsync<List<Poliza>>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return polizas;
        }

        public async Task<Reporte> GetReporteById(string _Id)
        {
            Reporte reporte = null;
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"{_configuration["API_ROUTE"]}/{REPORTE_ROUTE}/{_Id}")
            {
                Headers = { { HeaderNames.Authorization, "Bearer " + _token } },
            };
            var httpClient = _httpClientFactory.CreateClient();
            try
            {
                var response = await httpClient.SendAsync(httpRequestMessage);
                if (response.IsSuccessStatusCode)
                {
                    reporte = await response.Content.ReadFromJsonAsync<Reporte>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return reporte;
        }
        public async Task<List<Reporte>> GetReportes()
        {
            List<Reporte> reportes = null;

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"{_configuration["API_ROUTE"]}/{REPORTE_ROUTE}")
            {
                Headers = { { HeaderNames.Authorization, "Bearer " + _token } },
            };
            var httpClient = _httpClientFactory.CreateClient();
            try
            {
                var response = await httpClient.SendAsync(httpRequestMessage);
                if (response.IsSuccessStatusCode)
                {
                    reportes = await response.Content.ReadFromJsonAsync<List<Reporte>>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return reportes;
        }

        public async Task<List<IdentityUserViewModel>> GetUsersAsync()
        {
            List<IdentityUserViewModel> identityUserViewModelResponse = null;

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"{_configuration["API_ROUTE"]}/{USER_ROUTE}")
            {
                Headers = { { HeaderNames.Authorization, "Bearer " + _token } },
            };
            var httpClient = _httpClientFactory.CreateClient();
            try
            {
                var response = await httpClient.SendAsync(httpRequestMessage);
                if (response.IsSuccessStatusCode)
                {
                    identityUserViewModelResponse = await response.Content.ReadFromJsonAsync<List<IdentityUserViewModel>>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return identityUserViewModelResponse;
        }

        public async Task<IdentityUserViewModel> GetUsersByPhoneNumberAsync(string _PhoneNumber)
        {
            IdentityUserViewModel identityUserViewModelResponse = null;

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"{_configuration["API_ROUTE"]}/{USER_ROUTE}/{_PhoneNumber}"){
                Headers = { { HeaderNames.Authorization,"Bearer " + _token } },
            };
            var httpClient = _httpClientFactory.CreateClient();
            try
            {   
                var response = await httpClient.SendAsync(httpRequestMessage);
                if(response.IsSuccessStatusCode)
                {
                    identityUserViewModelResponse = await response.Content.ReadFromJsonAsync<IdentityUserViewModel>();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return identityUserViewModelResponse;
        }

        public async Task<LoginResponse> LoginAsync(LoginViewModel _login)
        {
            LoginResponse loginResponse = null;
            StringContent jsonBody = new (JsonSerializer.Serialize(_login), Encoding.UTF8,"application/json");
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, $"{_configuration["API_ROUTE"]}/{LOGIN_ROUTE}"){
                Content = jsonBody
            };
            var httpClient = _httpClientFactory.CreateClient();
            try
            {   
                var response = await httpClient.SendAsync(httpRequestMessage);
                if(response.IsSuccessStatusCode)
                {
                    loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return loginResponse;
        }

        public async Task<Conductor> PostConductorAsync(ConductorViewModel _conductor)
        {
            Conductor conductorResponse = null;
            StringContent jsonBody = new (JsonSerializer.Serialize(_conductor), Encoding.UTF8,"application/json");
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, $"{_configuration["API_ROUTE"]}/{CONDUCTOR_ROUTE}"){
                Headers = { { HeaderNames.Authorization,"Bearer " + _token } },
                Content = jsonBody
            };
            var httpClient = _httpClientFactory.CreateClient();
            try
            {   
                var response = await httpClient.SendAsync(httpRequestMessage);
                if(response.IsSuccessStatusCode)
                {
                    conductorResponse = await response.Content.ReadFromJsonAsync<Conductor>();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return conductorResponse;
        }

        public async Task<Poliza> PostPoliza(PolizaViewModel _poliza)
        {
            Poliza polizaResponse = null;
            StringContent jsonBody = new (JsonSerializer.Serialize(_poliza), Encoding.UTF8,"application/json");
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, $"{_configuration["API_ROUTE"]}/{POLIZA_ROUTE}"){
                Headers = { { HeaderNames.Authorization,"Bearer " + _token } },
                Content = jsonBody
            };
            var httpClient = _httpClientFactory.CreateClient();
            try
            {   
                var response = await httpClient.SendAsync(httpRequestMessage);
                if(response.IsSuccessStatusCode)
                {
                    polizaResponse = await response.Content.ReadFromJsonAsync<Poliza>();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return polizaResponse;
        }

        public async Task<Reporte> PostReporte(ReporteViewModel _reporte)
        {
            Reporte reporteResponse = null;
            StringContent jsonBody = new (JsonSerializer.Serialize(_reporte), Encoding.UTF8,"application/json");
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, $"{_configuration["API_ROUTE"]}/{REPORTE_ROUTE}"){
                Headers = { { HeaderNames.Authorization,"Bearer " + _token } },
                Content = jsonBody
            };
            var httpClient = _httpClientFactory.CreateClient();
            try
            {   
                var response = await httpClient.SendAsync(httpRequestMessage);
                if(response.IsSuccessStatusCode)
                {
                    reporteResponse = await response.Content.ReadFromJsonAsync<Reporte>();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return reporteResponse;
        }

        public async Task<Conductor> PutConductorAsync(ConductorViewModel _conductor)
        {
            Conductor conductorResponse = null;
            StringContent jsonBody = new (JsonSerializer.Serialize(_conductor), Encoding.UTF8,"application/json");
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, $"{_configuration["API_ROUTE"]}/{CONDUCTOR_ROUTE}"){
                Headers = { { HeaderNames.Authorization,"Bearer " + _token } },
                Content = jsonBody
            };
            var httpClient = _httpClientFactory.CreateClient();
            try
            {   
                var response = await httpClient.SendAsync(httpRequestMessage);
                if(response.IsSuccessStatusCode)
                {
                    conductorResponse = await response.Content.ReadFromJsonAsync<Conductor>();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return conductorResponse;
        }

        public async Task<Poliza> PutPoliza(PolizaViewModel _poliza)
        {
            Poliza polizaResponse = null;
            StringContent jsonBody = new (JsonSerializer.Serialize(_poliza), Encoding.UTF8,"application/json");
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, $"{_configuration["API_ROUTE"]}/{POLIZA_ROUTE}"){
                Headers = { { HeaderNames.Authorization,"Bearer " + _token } },
                Content = jsonBody
            };
            var httpClient = _httpClientFactory.CreateClient();
            try
            {   
                var response = await httpClient.SendAsync(httpRequestMessage);
                if(response.IsSuccessStatusCode)
                {
                    polizaResponse = await response.Content.ReadFromJsonAsync<Poliza>();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return polizaResponse;
        }

        public async Task<Reporte> PutReporte(ReporteViewModel _reporte)
        {
            Reporte reporteResponse = null;
            StringContent jsonBody = new (JsonSerializer.Serialize(_reporte), Encoding.UTF8,"application/json");
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, $"{_configuration["API_ROUTE"]}/{REPORTE_ROUTE}"){
                Headers = { { HeaderNames.Authorization,"Bearer " + _token } },
                Content = jsonBody
            };
            var httpClient = _httpClientFactory.CreateClient();
            try
            {   
                var response = await httpClient.SendAsync(httpRequestMessage);
                if(response.IsSuccessStatusCode)
                {
                    reporteResponse = await response.Content.ReadFromJsonAsync<Reporte>();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return reporteResponse;
        }
        public async Task<SignInResponse> SignInAsync(SignInViewModel _signIn)
        {
            SignInResponse signInResponse = null;
            StringContent jsonBody = new (JsonSerializer.Serialize(_signIn), Encoding.UTF8,"application/json");
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, $"{_configuration["API_ROUTE"]}/{SIGNIN_ROUTE}"){
                Content = jsonBody
            };
            var httpClient = _httpClientFactory.CreateClient();
            try
            {   
                var response = await httpClient.SendAsync(httpRequestMessage);
                if(response.IsSuccessStatusCode)
                {
                    signInResponse = await response.Content.ReadFromJsonAsync<SignInResponse>();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return signInResponse;
        }
    }
}