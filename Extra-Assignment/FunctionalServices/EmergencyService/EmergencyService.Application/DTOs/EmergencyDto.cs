namespace EmergencyService.Application.DTOs
{
    public record ReportEmergencyRequest(string Description, string Location);
    public record UpdateEmergencyRequest(string? Description, string? Location, string? Status);
}
