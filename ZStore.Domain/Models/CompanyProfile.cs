﻿using ZStore.Domain.Common;

namespace ZStore.Domain.Models
{
    public class CompanyProfile : AuditableBaseEntity
    {
        public string CompanyLogoImage { get; set; } = string.Empty;
        public string CompanyDescription { get; set; } = string.Empty;  
        public string CompanyBackgroundImage { get; set; } = string.Empty;
    }
}
