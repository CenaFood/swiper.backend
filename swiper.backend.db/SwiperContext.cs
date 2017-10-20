using ch.cena.swiper.backend.data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ch.cena.swiper.backend.data
{
    class SwiperContext: DbContext
    {
        public SwiperContext(DbContextOptions<SwiperContext> options) : base(options) { }

        public DbSet<Annotation> Annotations { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<ChallengeType> ChallengeTypes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Annotation>().ToTable("Annotations");
            modelBuilder.Entity<Answer>().ToTable("Answers");
            modelBuilder.Entity<Challenge>().ToTable("Challenges");
            modelBuilder.Entity<ChallengeType>().ToTable("ChallengeTypes");
            modelBuilder.Entity<Project>().ToTable("Projects");
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
