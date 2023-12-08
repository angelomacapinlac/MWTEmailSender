namespace MissedWork.Models
{
    public class Company
    {
        public long CompanyId { get; set; }
        public string CompanyName { get; set;}
        public string? Email { get;set;}
        public int IsActive { get; set; }
    }
}
