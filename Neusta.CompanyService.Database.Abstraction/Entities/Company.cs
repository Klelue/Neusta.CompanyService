using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Neusta.CompanyService.Database.Entities
{
    public class Company
    {
        [Key]
        public long Id { get; set; }

        [DefaultValue(true)]
        public bool Visible { get; set; }

        [ForeignKey("CompanyId")]
        public List<CompanyAttributeValue> CompanyAttributeValues { get; set; }

    }
}