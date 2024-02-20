namespace SearchFunction.Models
{
    public class _BaseEntity
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public _BaseEntity()
        {
            this.CreatedDate = DateTime.Now;
        }
    }
}
