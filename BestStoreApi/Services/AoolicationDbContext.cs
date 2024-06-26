﻿using BestStoreApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BestStoreApi.Serrvices
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) 
        { 
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
