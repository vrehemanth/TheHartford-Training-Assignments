namespace HospitalService.Domain.Entities
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int AvailableBeds { get; set; }
        public int TotalBeds { get; set; }
        public bool HasICU { get; set; }
        public string ContactNumber { get; set; } = string.Empty;
    }
}
