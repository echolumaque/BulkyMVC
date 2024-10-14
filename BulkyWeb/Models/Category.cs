﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    [DisplayName("Category Name")]
    [MaxLength(30)]
    public string Name { get; set; }

    [DisplayName("Display Order")]
    [Range(1, 100, ErrorMessage = "Display Order should be 1-100 only.")]
    public int DisplayOrder { get; set; }

}
