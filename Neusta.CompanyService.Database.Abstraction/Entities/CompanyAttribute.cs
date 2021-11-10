using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Neusta.CompanyService.Database.Entities
{
    public class CompanyAttribute
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("CompanyAttributeId")]
        public List<CompanyAttributeValue> CompanyAttributeValues { get; set; }
    }
}