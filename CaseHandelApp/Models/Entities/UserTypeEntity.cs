using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
