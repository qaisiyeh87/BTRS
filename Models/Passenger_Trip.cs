using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTRS.Models
{
    public class Passenger_Trip
    {
        [Key]
        public int ID { set; get; }

        [ForeignKey("FK_PassengerID")]
        public Passenger passenger { set; get; }
        public int passesngerID { set; get; }
        [ForeignKey("FK_TripID")]
        public Trip trip { set; get; }
    

    }
}
