using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTRS.Models
{
    public class Trip
    {
        [Key]
        public int Id { set; get; }
        [Required(ErrorMessage = "Should Be insert")]
        [StringLength(50)]
        public string trip_dist { set; get; }
        [Required(ErrorMessage = "Should Be insert")]
        [StringLength(50)]
        public string S_date { set; get; }
        [Required(ErrorMessage = "Should Be insert")]
        [StringLength(50)]
        public string E_date { set; get; }
        [ForeignKey("fk_ID_admin")]
       
        public ICollection<Bus>bus { set; get; }
        public ICollection<Passenger_Trip> passenger_trip { set; get; }
        public Admin?Admin { get; set; }
    }
}
