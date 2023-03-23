namespace CaseHandelApp.Models.Form
{
    
    internal class CaseRegistrationForm:UserRegistrationForm
    {
        public Guid CaseId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
