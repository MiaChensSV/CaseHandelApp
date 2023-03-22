using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseHandelApp.Models.Form
{
    
    internal class CaseRegistrationForm:UserRegistrationForm
    {
        
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
