using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

namespace CaseHandelApp.Models.Entities
{
    internal class UserEntity
    {
        public Guid Id { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string FirstName { get; set; } = null!;
        [Column(TypeName = "nvarchar(20)")]
        public string LastName { get; set; } = null!;
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; } = null!;
        [Column(TypeName = "char(10)")]
        public string PhoneNumber { get; set; } = null!;
        public int AddressId { get; set; }
        [ForeignKey("AddressId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public AddressEntity Address { get; set; } = null!;
        public ICollection<CaseEntity> Cases { get; set; } = new HashSet<CaseEntity>();
        public int UserTypeId { get; set; }
        [ForeignKey("UserTypeId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public UserTypeEntity UserType { get; set; } = null!;
    }
}
