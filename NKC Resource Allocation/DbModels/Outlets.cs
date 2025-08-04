using NKC_Resource_Allocation.DbModels.Base;
using System.ComponentModel.DataAnnotations;

namespace NKC_Resource_Allocation.DbModels
{
    public class Outlets: BaseModel
    {
        [Key]
        public required string OutletId { get; set; }

        public required int OutletSerialNo { get; set; }

        public required string OutletName { get; set; }

        public required string OutletCode { get; set; }

        public required string Brand { get; set; }
    }
}
