using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    [Table("SlideShow")]
    public class SlideShow
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PhotoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ButtonName { get; set; }
        public string ButtonLink { get; set; }
    }
}
