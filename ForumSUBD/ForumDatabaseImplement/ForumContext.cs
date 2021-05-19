using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ForumDatabaseImplement.Models
{
    public partial class ForumContext : DbContext
    {
        public ForumContext()
        {
        }

        public ForumContext(DbContextOptions<ForumContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Forum> Forum { get; set; }
        public virtual DbSet<ForumReports> ForumReports { get; set; }
        public virtual DbSet<Forumtype> Forumtype { get; set; }
        public virtual DbSet<Reports> Reports { get; set; }
        public virtual DbSet<Speakers> Speakers { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Forum;Username=Lachugina;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Forum>(entity =>
            {
                entity.ToTable("forum");

                entity.Property(e => e.Forumid).HasColumnName("forumid");

                entity.Property(e => e.Forumtypeid).HasColumnName("forumtypeid");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("date");

                entity.Property(e => e.Themeforum)
                    .IsRequired()
                    .HasColumnName("themeforum")
                    .HasMaxLength(255);

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Forumtype)
                    .WithMany(p => p.Forum)
                    .HasForeignKey(d => d.Forumtypeid)
                    .HasConstraintName("forum1fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Forum)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("forum2fk");
            });

            modelBuilder.Entity<ForumReports>(entity =>
            {
                entity.HasKey(e => new { e.Forumid, e.Reportid })
                    .HasName("forum_reports_pkey");

                entity.ToTable("forum_reports");

                entity.Property(e => e.Forumid).HasColumnName("forumid");

                entity.Property(e => e.Reportid).HasColumnName("reportid");

                entity.HasOne(d => d.Forum)
                    .WithMany(p => p.ForumReports)
                    .HasForeignKey(d => d.Forumid)
                    .HasConstraintName("forumfk");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.ForumReports)
                    .HasForeignKey(d => d.Reportid)
                    .HasConstraintName("reportsfk");
            });

            modelBuilder.Entity<Forumtype>(entity =>
            {
                entity.ToTable("forumtype");

                entity.Property(e => e.Forumtypeid).HasColumnName("forumtypeid");

                entity.Property(e => e.Nametype)
                    .IsRequired()
                    .HasColumnName("nametype")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Reports>(entity =>
            {
                entity.HasKey(e => e.Reportid)
                    .HasName("reportspk");

                entity.ToTable("reports");

                entity.Property(e => e.Reportid).HasColumnName("reportid");

                entity.Property(e => e.Speakerid).HasColumnName("speakerid");

                entity.Property(e => e.Themereport)
                    .IsRequired()
                    .HasColumnName("themereport")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Speaker)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.Speakerid)
                    .HasConstraintName("reportsfk");
            });

            modelBuilder.Entity<Speakers>(entity =>
            {
                entity.HasKey(e => e.Speakerid)
                    .HasName("speakerspk");

                entity.ToTable("speakers");

                entity.Property(e => e.Speakerid).HasColumnName("speakerid");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.Namespeaker)
                    .IsRequired()
                    .HasColumnName("namespeaker")
                    .HasMaxLength(255);

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasColumnName("nickname")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("userspk");

                entity.ToTable("users");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(255);
            });

            modelBuilder.HasSequence("forum_seq").StartsAt(400);

            modelBuilder.HasSequence("forumtype_seq").StartsAt(500);

            modelBuilder.HasSequence("reports_seq").StartsAt(300);

            modelBuilder.HasSequence("speakers_seq").StartsAt(200);

            modelBuilder.HasSequence("users_seq").StartsAt(100);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
