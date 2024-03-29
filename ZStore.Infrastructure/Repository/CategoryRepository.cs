﻿using ZStore.Domain.Models;
using ZStore.Infrastructure.Data;
using ZStore.Infrastructure.Repository.IRepository;

namespace ZStore.Infrastructure.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
