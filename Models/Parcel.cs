using System.ComponentModel.DataAnnotations;

namespace Belsis_Parselasyon_Backend.Models
{
    public class Parcel
    {
        [Key]
        public int id { get; set; }
        public string il { get; set; }
        public string ilce { get; set; }
        public string wkt { get; set; }

    }
}
