namespace CRM.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public string? BateryType { get; set; }
        public string? BateryModel {  get; set; }
        public int Quantity { get; set; }
        public decimal SalesPrice { get; set;}
        public int CostumerId {  get; set; }
        public string? Notes {  get; set; }
        public DateTime SaleDate { get; set; }

        public Costumer? Costumer { get; set; }  

    }
}
