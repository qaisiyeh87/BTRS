using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTRS.Models
{
    public class Bus
    {
        [Key]
        public int ID { set; get; }
        public String caption_name { set; get; }
        [Required(ErrorMessage = "Should Be insert")]
        [StringLength(50)]
        public string n_ofSeat { set; get; }
        [ForeignKey("FK_tripID")]
        public Trip trip { set; get; }
      
        [ForeignKey("FK_AdminID")]
        public Admin admin { set; get; }
     


    }
}
