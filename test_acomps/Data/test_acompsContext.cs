using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using test_acomps.Data.Models;

namespace test_acomps.Data
{
    public class test_acompsContext : DbContext
    {
        public test_acompsContext (DbContextOptions<test_acompsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Test1_model> Test1_model { get; set; }
        public DbSet<Test2_model> Test2_model { get; set; }
        public DbSet<Test3_model> Test3_model { get; set; }
    }
}
