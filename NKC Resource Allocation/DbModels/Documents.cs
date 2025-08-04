using NKC_Resource_Allocation.DbModels.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NKC_Resource_Allocation.DbModels
{
    public class Documents: BaseModel
    {
        [Key]
        public required string DocumentId { get; set; }

        [ForeignKey("Auditors")]
        public required string AuditorId { get; set; }
        public virtual Auditors? Auditors { get; set; }


        [ForeignKey("Outlets")]
        public required string OutletId { get; set; }
        public virtual Outlets? Outlets { get; set; }

        public string? BarrelAndCO2_Res_1 { get; set; }
        public string? BarrelAndCO2_Res_2 { get; set; }
        public string? BarrelAndCO2_Res_3 { get; set; }
        public string? BarrelAndCO2_Res_4 { get; set; }
        public string? BarrelAndCO2_Res_5 { get; set; }
        public string? BarrelAndCO2_Res_6 { get; set; }
        public string? BarrelAndCO2_Res_7 { get; set; }
        public string? BarrelAndCO2_Res_8 { get; set; }

        public string? Machine_Res_1 { get; set; }
        public string? Machine_Res_2 { get; set; }
        public string? Machine_Res_3 { get; set; }
        public string? Machine_Res_4 { get; set; }
        public string? Machine_Res_5 { get; set; }

        public string? AuditorNRCFront { get; set; }
        public string? AuditorNRCBack { get; set; }
    }
}
