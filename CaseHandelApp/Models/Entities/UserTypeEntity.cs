using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CaseHandelApp.Models.Entities
{
    internal class UserTypeEntity
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string UserType { get; set; } = null!;
        public ICollection<UserEntity> Users { get; set; } = new HashSet<UserEntity>();
    }
}
