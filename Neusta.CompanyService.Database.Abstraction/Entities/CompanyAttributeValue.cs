namespace Neusta.CompanyService.Database.Entities
{
    public class CompanyAttributeValue
    {
        public long CompanyId { get; set; }
        public long CompanyAttributeId { get; set; }
        public string Value { get; set; }
    }
}