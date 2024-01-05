using Aseguradora.Models;

namespace Aseguradora.Services.Backend
{
    public interface IAseguradoraService
    {
        public void ConfigureAcessToken(string token);
        //api/Login
        public Task<LoginResponse> LoginAsync(LoginViewModel _login);
        //api/SignIn
        public Task<SignInResponse> SignInAsync(SignInViewModel _signIn);
        //api/Conductor
        public Task<Conductor> GetConductorByIdAsync(string _Id);
        public Task<Conductor> DeleteConductorByIdAsync(string _Id);
        public Task<Conductor> PutConductorAsync(ConductorViewModel _conductor);
        public Task<Conductor> PostConductorAsync(ConductorViewModel _conductor);
        //api/User
        public Task<List<IdentityUserViewModel>> GetUsersAsync();
        public Task<IdentityUserViewModel> GetUsersByPhoneNumberAsync(string _PhoneNumber);
        //api/Reporte
        public Task<Reporte> GetReporteById(string _Id);
        public Task<List<Reporte>> GetReportes();
        public Task<Reporte> PostReporte(ReporteViewModel _reporte);
        public Task<Reporte> PutReporte(ReporteViewModel _reporte);
        public Task<Reporte> DeleteReporteById(string _Id);
        //api/Poliza
        public Task<List<Poliza>> GetPolizasByIdConductor(string _Id);
        public Task<Poliza> PostPoliza(PolizaViewModel _poliza);
        public Task<Poliza> PutPoliza(PolizaViewModel _poliza);
        public Task<Poliza> DeletePolizaById(string _Id);
    }
}
