using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CaseHandelApp.Models.Entities
{
    internal class StatusEntity
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string StatusName { get; set; } = null!;
        public ICollection<CaseEntity> Cases { get; set; } = new HashSet<CaseEntity>();
    }
}
