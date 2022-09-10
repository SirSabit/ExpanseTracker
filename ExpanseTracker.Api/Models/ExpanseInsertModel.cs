namespace ExpanseTracker.Api.Models
{
    public class ExpanseInsertModel
    {
        public string? ExpanseName { get; set; }

        public decimal ExpanseAmount { get; set; }
        public DateTime ExpanseDate { get; set; }
        
    }
}
