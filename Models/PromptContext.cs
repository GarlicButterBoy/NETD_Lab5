using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NETD_Lab5.Models
{
    public class PromptContext : DbContext
    {
        //Constructor for PromptContext
        public PromptContext(DbContextOptions<PromptContext> options) : base(options)
        { }

        public DbSet<Prompts> Prompts { get; set; }
        public DbSet<CompletedPrompts> CompletedPrompts { get; set; }
    }
}
