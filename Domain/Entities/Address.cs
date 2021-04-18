using Domain.Common;

namespace Domain.Entities
{
    public class Address : BaseEntity
    {
        public int AddressId { get; set; }
        public string State { get; set; }
        public int PostCode { get; set; }

        public int UserId { get; set; }

    }
}
