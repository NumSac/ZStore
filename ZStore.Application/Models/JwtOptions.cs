﻿namespace ZStore.Application.Models
{
    public class JwtOptions
    {
        public string SecretKey { get; set; }
        public int ExpiryMinutes { get; set; } = 5;
        public string Issuer { get; set; }
    }
}