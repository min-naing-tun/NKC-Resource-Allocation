using NKC_Resource_Allocation.DbModels.Base;
using System.ComponentModel.DataAnnotations;

namespace NKC_Resource_Allocation.DbModels
{
    public class Auditors : BaseModel
    {
        [Key]
        public required string AuditorId { get; set; }

        public required string AuditorName { get; set; }

        public required string AuditorNRC { get; set; }

        public required string PhoneNumber { get; set; }

        public required DateTime NKCAuditDate { get; set; }

        public string Remark { get; set; } = string.Empty;
    }
}
