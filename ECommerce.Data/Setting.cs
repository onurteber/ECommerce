using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    [Table("Setting")]
    public class Setting
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(128)]
        public string Key { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
