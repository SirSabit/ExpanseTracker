namespace ExpanseTracker.Dto
{
    public class ExpanseDto
    {
        public int ID { get; set; }

        public string? ExpanseName { get; set; }

        public decimal ExpanseAmount { get; set; }
        public DateTime ExpanseDate { get; set; }

        public string ExpanseDateEdited => ExpanseDate.ToString("yyyy-MM-dd");

        public bool IsDeleted { get; set; } = false;
    }
}
