using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;

namespace Devs_compass.Models
{
    public class Software
    {
        [Required, Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public List<Opinion> Opinions { get; set; }

        public float Score
        {
            get
            {
                var final = 0f;
                foreach (Opinion opinion in Opinions)
                    final += opinion.Score;
                return final / Opinions.Count;
            }
        }

        public string? UseLicense { get; set; }

        public float? TimeToBeat { get; set; }
    }
}
