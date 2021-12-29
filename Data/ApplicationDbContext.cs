using MeetingNotes.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingNotes.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region ApplicationUser
            modelBuilder.Entity<ApplicationUser>()
                .Property(ap => ap.FullName).HasColumnType("varchar(200)");
            #endregion

            #region Meetings
            modelBuilder.Entity<Meeting>().HasKey(m => m.Id);
            modelBuilder.Entity<Meeting>().Ignore(m => m.CreatedBy);

            //modelBuilder.Entity<Meeting>()
            //    .HasOne(m => m.CreatedBy)
            //    .WithMany()
            //    .HasForeignKey(m => m.CreatedByName);

            modelBuilder.Entity<Meeting>(m =>
            {
                m.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
                m.Property(e => e.DateCreated).IsRequired();
                m.Property(e => e.CreatedByName).IsRequired();
                m.Property(e => e.DateUpdated).IsRequired();
                m.Property(e => e.MeetingDate).IsRequired();
                m.Property(e => e.MeetingStatus).IsRequired();
                m.Property(e => e.Title).HasColumnType("varchar(100)").IsRequired();
                m.Property(e => e.ExternalParticipants).HasColumnType("varchar(500)").IsRequired();
            });

            #endregion

            #region MeetingParticipants
            modelBuilder.Entity<MeetingParticipant>().HasKey(mp => mp.Id);
            modelBuilder.Entity<MeetingParticipant>().Ignore(mp => mp.Meeting);
            modelBuilder.Entity<MeetingParticipant>().Ignore(mp => mp.Participant);

            modelBuilder.Entity<MeetingParticipant>()
                .HasOne(mp => mp.Meeting)
                .WithMany(m => m.MeetingParticipants)
                .HasForeignKey(mp => mp.MeetingId);

            modelBuilder.Entity<MeetingParticipant>()
                .HasOne(mp => mp.Participant)
                .WithOne()
                .HasForeignKey<MeetingParticipant>(mp => mp.ParticipantId);

            modelBuilder.Entity<MeetingParticipant>(mp =>
            {
                mp.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
                mp.Property(e => e.MeetingId).IsRequired();
                mp.Property(e => e.ParticipantId).IsRequired();
            });
            #endregion

            #region MeetingItems
            modelBuilder.Entity<MeetingItem>().HasKey(mi => mi.Id);
            modelBuilder.Entity<MeetingItem>().Ignore(mi => mi.Meeting);
            modelBuilder.Entity<MeetingItem>().Ignore(mi => mi.RiskLevel);

            modelBuilder.Entity<MeetingItem>()
                .HasOne(mi => mi.Meeting)
                .WithMany(m => m.MeetingItems)
                .HasForeignKey(mi => mi.MeetingId);

            modelBuilder.Entity<MeetingItem>()
                .HasOne(mi => mi.RiskLevel)
                .WithMany()
                .HasForeignKey(mi => mi.RiskLevelId);

            modelBuilder.Entity<MeetingItem>(mi =>
            {
                mi.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
                mi.Property(e => e.MeetingId).IsRequired();
                mi.Property(e => e.Description).HasColumnType("varchar(500)").IsRequired();
                mi.Property(e => e.VissibleInMinutes).IsRequired();
            });
            #endregion

            #region RiskLevels

            modelBuilder.Entity<RiskLevel>().HasKey(rl => rl.Id);

            modelBuilder.Entity<RiskLevel>(m =>
            {
                m.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
                m.Property(e => e.Name).IsRequired();
            });
            #endregion
        }

        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingItem> MeetingItems { get; set; }
        public DbSet<MeetingParticipant> MeetingParticipants { get; set; }
        public DbSet<RiskLevel> RiskLevels { get; set; }
    }
}
