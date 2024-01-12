using System.ComponentModel.DataAnnotations;

namespace BTRS.Models
{
    public class Admin
    {
        [Key]
        public int Id { set; get; }
        [Required(ErrorMessage = "Should Be insert")]
        [StringLength(50)]
        public string username { set; get; }
        [Required(ErrorMessage = "Should Be insert")]
        [StringLength(50)]
        public string password { set; get; }
        [Required(ErrorMessage = "Should Be insert")]
        [StringLength(50)]
        public string fname { set; get; }
        public ICollection<Trip> trip { set; get; }


    }
}
