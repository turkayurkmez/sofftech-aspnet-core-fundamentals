using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Entities
{
    //[Table(name:"Urunler")]
    public class Product : IEntity
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        public string? Description { get; set; }
        public decimal Price { get; set; }
        public double? Rating { get; set; }
        public string ImageUrl { get; set; } = "https://cdn.dsmcdn.com/ty1018/product/media/images/prod/SPM/PIM/20231019/13/899e8cb7-16a0-3617-bae0-555eacd2e713/1_org.jpg";

        //Navigation Property
        public Category Category { get; set; }
        public int CategoryId { get; set; }

    }
}
