using System;
using System.Collections.Generic;
using System.Text;
using AdvancedWebsite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdvancedWebsite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //db set for video lessons
        public DbSet<VideoLesson> VideoLessons { get; set; }

    }
}
