using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RealTimePoll.Models
{
    public partial class POLLBDContext : DbContext
    {
        public POLLBDContext()
        {
        }

        public POLLBDContext(DbContextOptions<POLLBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PulseSurveyDetail> PulseSurveyDetail { get; set; }
        public virtual DbSet<PulseSurveyMaster> PulseSurveyMaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-0UJFDQM\\SQLEXPRESS;Database=POLLBD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<PulseSurveyDetail>(entity =>
            {
                entity.HasKey(e => e.PulseSurveyDetail1);

                entity.ToTable("pulse_survey_detail");

                entity.Property(e => e.PulseSurveyDetail1)
                    .HasColumnName("pulse_survey_detail")
                    .ValueGeneratedNever();

                entity.Property(e => e.Answer).HasColumnName("answer");

                entity.Property(e => e.PulseSurveyMasterId).HasColumnName("pulse_survey_master_id");
            });

            modelBuilder.Entity<PulseSurveyMaster>(entity =>
            {
                entity.ToTable("pulse_survey_master");

                entity.Property(e => e.PulseSurveyMasterId)
                    .HasColumnName("pulse_survey_master_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateClose)
                    .HasColumnName("date_close")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Isdone).HasColumnName("isdone");

                entity.Property(e => e.QuestionName)
                    .IsRequired()
                    .HasColumnName("question_name")
                    .HasMaxLength(50);
            });
        }
    }
}
