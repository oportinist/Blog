using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Models.DTOs
{
    public class CategoryDto 
    {
        public int? Id { get; set; }
        [DisplayName("Kategori Adı")]
        [Required(ErrorMessage ="{0} boş geçilemez")]
        [MaxLength(70,ErrorMessage = "{0} {1} karakterden fazla olamaz")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olamaz")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
