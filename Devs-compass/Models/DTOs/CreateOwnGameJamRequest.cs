namespace Devs_compass.Models.DTOs
{
    public class CreateOwnGameJamRequest
    {
        public required string Name { get; set; }
        public required string Motif { get; set; }

        public required DateTime StartDate { get; set; }

        public required int Duration { get; set; } = 24;

        public string? link { get; set; }

        public string? address { get; set; }

        public required int OrganizerId { get; set; }

        public required float Price { get; set; }
    }
}
