namespace NKC_Resource_Allocation.DbModels.Base
{
    public class BaseModel
    {
        public DateTime? CreatedDate { get; set; }

        public string? CreatedUser { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedUser { get; set; }
    }
}
