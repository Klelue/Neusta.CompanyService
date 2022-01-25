using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Neusta.CompanyService.Database.Entities
{
    public class CompanyAttribute
    {
        [Key] 
        public long Id { get; set; }

        [Required]
        [DefaultValue("Kein Name angegeben")]
        public string Name { get; set; }

        public int OrderNumber { get; set; }

        [DefaultValue(true)]
        public bool Visible { get; set; }

        [ForeignKey("CompanyAttributeId")] 
        public List<CompanyAttributeValue> CompanyAttributeValues { get; set; }
    }
}