namespace EmergencyService.Application.Common.Interfaces
{
    public interface IHospitalClient
    {
        Task<bool> CheckHospitalAvailabilityAsync(int hospitalId);
        Task<bool> ReserveBedAsync(int hospitalId);
    }
}
