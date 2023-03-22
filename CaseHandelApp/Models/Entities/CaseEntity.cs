using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

namespace CaseHandelApp.Models.Entities
{
    internal class CaseEntity
    {
        public CaseEntity()
        {
            Id = Guid.NewGuid();
            var _dateTime = DateTime.Now;
            Created = _dateTime;
            Updated = _dateTime;
            StatusTypeCode = 1;
        }
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public UserEntity User { get; set; } = null!;
        public ICollection<CommentEntity> Comments { get; set; } = new HashSet<CommentEntity>();
        public int StatusTypeCode { get; set; }

        [ForeignKey("StatusTypeCode")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public StatusEntity Status { get; set; } = null!;
    }
}
