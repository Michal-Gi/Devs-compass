namespace Devs_compass.Models.DTOs
{
    public class WinnerVM
    {
        public required int GroupId { get; set; }

        public required int SoftwareId { get; set; }

        public required string SoftwareName { get; set; }

        public required int GameJamId { get; set; }

        public required string GameJamName { get; set; }
        public required string GameJamMotif { get; set; }
    }
}
