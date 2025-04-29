using Microsoft.Data.SqlClient.DataClassification;

namespace energy_providr.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeOnly Time { get; set; }
    }
}
