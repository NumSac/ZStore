using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZStore.Domain.Models;

namespace ZStore.Domain.ViewModels
{
    public class ProductVM
    {

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(1, 1000, ErrorMessage = "Price must be between 1 and 1000.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }
        [ValidateNever]
        public string CompanyId { get; set; }
        [ValidateNever]
        public List<Category> Categories { get; set; }
    }

    public class CategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
