namespace CRM.Entities
{
    public class Visit
    {
        public int Id { get; set; }
        public int CostumerId { get; set; }
        public DateTime VisitDate { get; set; }
        public string? Notes { get; set; }

        public Costumer? Costumer { get; set; }

    }
}
