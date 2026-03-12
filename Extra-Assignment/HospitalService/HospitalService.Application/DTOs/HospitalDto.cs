namespace HospitalService.Application.DTOs
{
    public record AddHospitalRequest(string Name, string Location, int TotalBeds, bool HasICU, string ContactNumber);
    public record UpdateBedsRequest(int AvailableBeds);
}
