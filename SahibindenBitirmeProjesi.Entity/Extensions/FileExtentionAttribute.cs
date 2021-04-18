using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace SahibindenBitirmeProjesi.Entity.Extensions
{
    public class FileExtentionAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                string[] extentions = { "jpg", "png", "jpeg" };
                bool result = extentions.Any(x => extension.EndsWith(x));
                if (!result) new ValidationResult(ErrorMessage = "Allowed extension are jpg,png,jpeg");
            }

            return ValidationResult.Success;
        }
    }
}
