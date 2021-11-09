using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Entities
{
    public class BASE_ENTITY
    {
        [Key]
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
