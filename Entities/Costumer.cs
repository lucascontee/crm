namespace CRM.Entities
{
    public class Costumer
    {
        public int Id { get; set; }
        public string? StoreName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public string? Region { get; set; }
        public string? Phone { get; set; }
        public int NumberSales { get; set; }
        public decimal TotalSalesValue { get; set; }
        public int NumberVisits { get; set; }
        public string? MainInformation {  get; set; }
    }
}
