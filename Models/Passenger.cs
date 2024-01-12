using System.ComponentModel.DataAnnotations;

namespace BTRS.Models
{
    public class Passenger
    {
        [Key]
        public int ID { set; get; }
        [Required(ErrorMessage = "Should Be insert")]
        [StringLength(50)]
        public string name { set; get; }
        [Required(ErrorMessage = "Should Be insert")]
        [StringLength(50)]
        public  string password { set; get; }
        [Required(ErrorMessage = "Should Be insert")]
        [StringLength(50)]
        public string Gender { set; get; }
        [Required(ErrorMessage = "Should Be insert")]
        [StringLength(50)]
        public string username { set; get; }
        [Required(ErrorMessage = "Should Be insert")]
        [StringLength(50)]
        public string email { set; get; }
        [Required(ErrorMessage = "Should Be insert")]
        [StringLength(50)]
        public string phone_n { set; get; }
        public ICollection<Passenger_Trip> passenger_Trip { set; get; }


    }
}
