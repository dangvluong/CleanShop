namespace CleanShop.Domain.Common
{
    public class AuditableEntity
    {
        public string CreateBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
    }
}