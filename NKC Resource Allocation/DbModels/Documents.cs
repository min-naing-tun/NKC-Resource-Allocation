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

        public string? BarrelAndCO2_Res_1_Name { get; set; }
        public string? BarrelAndCO2_Res_1_Value { get; set; }
        public string? BarrelAndCO2_Res_2_Name { get; set; }
        public string? BarrelAndCO2_Res_2_Value { get; set; }
        public string? BarrelAndCO2_Res_3_Name { get; set; }
        public string? BarrelAndCO2_Res_3_Value { get; set; }
        public string? BarrelAndCO2_Res_4_Name { get; set; }
        public string? BarrelAndCO2_Res_4_Value { get; set; }
        public string? BarrelAndCO2_Res_5_Name { get; set; }
        public string? BarrelAndCO2_Res_5_Value { get; set; }
        public string? BarrelAndCO2_Res_6_Name { get; set; }
        public string? BarrelAndCO2_Res_6_Value { get; set; }
        public string? BarrelAndCO2_Res_7_Name { get; set; }
        public string? BarrelAndCO2_Res_7_Value { get; set; }
        public string? BarrelAndCO2_Res_8_Name { get; set; }
        public string? BarrelAndCO2_Res_8_Value { get; set; }

        public string? Machine_Res_1_Name { get; set; }
        public string? Machine_Res_1_Value { get; set; }
        public string? Machine_Res_2_Name { get; set; }
        public string? Machine_Res_2_Value { get; set; }
        public string? Machine_Res_3_Name { get; set; }
        public string? Machine_Res_3_Value { get; set; }
        public string? Machine_Res_4_Name { get; set; }
        public string? Machine_Res_4_Value { get; set; }
        public string? Machine_Res_5_Name { get; set; }
        public string? Machine_Res_5_Value { get; set; }

        public string? AuditorNRCFront_Name { get; set; }
        public string? AuditorNRCFront_Value { get; set; }
        public string? AuditorNRCBack_Name { get; set; }
        public string? AuditorNRCBack_Value { get; set; }
    }
}
