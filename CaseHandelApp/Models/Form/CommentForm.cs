using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseHandelApp.Models.Form
{
    internal class CommentForm
    {
        public Guid CaseId { get; set; }
        public string UserEmail { get; set; } = null!;
        public string Comment { get; set; } = null!;

    }
}
