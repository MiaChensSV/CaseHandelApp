using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CaseHandelApp.Models.Entities
{
    internal class AddressEntity
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string StreetName { get; set; } = null!;
        [Required]
        [Column(TypeName = "char(6)")]
        public string PostalCode { get; set; } = null!;
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; } = null!;
        public ICollection<UserEntity> Users { get; set; } = new HashSet<UserEntity>();
    }
}
