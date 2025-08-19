using NKC_Resource_Allocation.DbModels;

namespace NKC_Resource_Allocation.ViewModels
{
    public class FormDetailViewModel
    {
        public Outlets outlet { get; set; }
        public Auditors auditor { get; set; }
        public Documents document { get; set; }
    }
}
