using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CaseHandelApp.Models.Entities
{
    internal class CommentEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Comments { get; set; } = null!;
        public Guid CaseId { get; set; }
        [ForeignKey("CaseId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public CaseEntity Case { get; set; } = null!;

        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public UserEntity User { get; set; } = null!;
    }
}
