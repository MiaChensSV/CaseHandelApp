using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CaseHandelApp.Models.Entities
{
    internal class StatusEntity
    {
        public int Id { get; set; }
        public int StatusTypeCode { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string StatusName { get; set; } = null!;
        public ICollection<CaseEntity> Cases { get; set; } = new HashSet<CaseEntity>();
    }
}
