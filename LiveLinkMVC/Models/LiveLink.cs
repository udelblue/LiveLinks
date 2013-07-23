using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveLinkMVC.Models
{
    public class LiveLink
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
    
        public string Link { get; set; }
        [DataType(DataType.Date)]
        public DateTime Begin { get; set; }
        [DataType(DataType.Date)]
        public DateTime End { get; set; }
        public string Owner { get; set; }
    }
}
