using Nam.EFCore.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nam.DTO.Dto
{
    public class ProductDto : Entity
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }
        public string SlugUrl { get; set; }

        public long GroupProductId { get; set; }
    }
}
