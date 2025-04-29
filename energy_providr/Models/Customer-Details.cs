namespace energy_providr.Models
{
    public class Customer_Details
    {
        public int Id { get; set; }

        public required string First_name { get; set; }
        public required string Last_name { get; set; }
        public required string phone_number { get; set; }
        public required string Title { get; set; }
        public required string DOB {  get; set; }


    }
}
