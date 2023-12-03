using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using ZStore.Domain.Common;

namespace ZStore.Domain.Models
{
    public class CompanyProfile : AuditableBaseEntity
    {
        public string CompanyLogoImage { get; set; } 
        public string CompanyDescription { get; set; } 
        public string CompanyBackgroundImage { get; set; } 
        public CompanyProfile(string companyLogoImage, 
            string companyDescription, 
            string companyBackgroundImage
            ) : base() 
        { 
            CompanyLogoImage = companyLogoImage;
            CompanyDescription = companyDescription;
            CompanyBackgroundImage = companyBackgroundImage;
        }
    }
}
