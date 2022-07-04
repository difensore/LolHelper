using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LolHelper
{
    public partial class LolHelperContext : DbContext
    {
        public static string ServerName { get; set; }
        public LolHelperContext()
        {
        }

        public LolHelperContext(DbContextOptions<LolHelperContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Champ> Champs { get; set; }
        public virtual DbSet<Contr> Contrs { get; set; }
        public virtual DbSet<ExtraRune> ExtraRunes { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<MainRune> MainRunes { get; set; }
        public virtual DbSet<Pick> Picks { get; set; }
        public virtual DbSet<Rune> Runes { get; set; }
        public virtual DbSet<RunesBuild> RunesBuilds { get; set; }
        public virtual DbSet<Spell> Spells { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer($"Server={ServerName};Database=LolHelper;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Champ>(entity =>
            {
                entity.ToTable("Champ");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.E)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Image)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.Passive)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Q)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.R)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.W)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Contr>(entity =>
            {
                entity.ToTable("Contr");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Contr1).HasColumnName("Contr");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.HasOne(d => d.ChampNavigation)
                    .WithMany(p => p.Contrs)
                    .HasForeignKey(d => d.Champ)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contr_Champ");

                entity.HasOne(d => d.Contr1Navigation)
                    .WithMany(p => p.Contrs)
                    .HasForeignKey(d => d.Contr1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contr_Pick");
            });

            modelBuilder.Entity<ExtraRune>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Image)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Image)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<MainRune>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Image)
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Pick>(entity =>
            {
                entity.ToTable("Pick");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.ChampNavigation)
                    .WithMany(p => p.Picks)
                    .HasForeignKey(d => d.Champ)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pick_Champ");

                entity.HasOne(d => d.FirstMainItemNavigation)
                    .WithMany(p => p.PickFirstMainItemNavigations)
                    .HasForeignKey(d => d.FirstMainItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pick_Item3");

                entity.HasOne(d => d.FirstSpellNavigation)
                    .WithMany(p => p.PickFirstSpellNavigations)
                    .HasForeignKey(d => d.FirstSpell)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pick_Spell1");

                entity.HasOne(d => d.FirstStartedItemNavigation)
                    .WithMany(p => p.PickFirstStartedItemNavigations)
                    .HasForeignKey(d => d.FirstStartedItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pick_Item");

                entity.HasOne(d => d.RunesBuildNavigation)
                    .WithMany(p => p.Picks)
                    .HasForeignKey(d => d.RunesBuild)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pick_RunesBuild");

                entity.HasOne(d => d.SecondMainItemNavigation)
                    .WithMany(p => p.PickSecondMainItemNavigations)
                    .HasForeignKey(d => d.SecondMainItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pick_Item4");

                entity.HasOne(d => d.SecondSpellNavigation)
                    .WithMany(p => p.PickSecondSpellNavigations)
                    .HasForeignKey(d => d.SecondSpell)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pick_Spell");

                entity.HasOne(d => d.SecondStartedItemNavigation)
                    .WithMany(p => p.PickSecondStartedItemNavigations)
                    .HasForeignKey(d => d.SecondStartedItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pick_Item1");

                entity.HasOne(d => d.ThirdMainItemNavigation)
                    .WithMany(p => p.PickThirdMainItemNavigations)
                    .HasForeignKey(d => d.ThirdMainItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pick_Item5");

                entity.HasOne(d => d.ThirdStartedItemNavigation)
                    .WithMany(p => p.PickThirdStartedItemNavigations)
                    .HasForeignKey(d => d.ThirdStartedItem)
                    .HasConstraintName("FK_Pick_Item2");
            });

            modelBuilder.Entity<Rune>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Image)
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.HasOne(d => d.MainRuneNavigation)
                    .WithMany(p => p.Runes)
                    .HasForeignKey(d => d.MainRune)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Runes_MainRunes");
            });

            modelBuilder.Entity<RunesBuild>(entity =>
            {
                entity.ToTable("RunesBuild");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.FirstExtraRuneNavigation)
                    .WithMany(p => p.RunesBuildFirstExtraRuneNavigations)
                    .HasForeignKey(d => d.FirstExtraRune)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RunesBuild_ExtraRunes");

                entity.HasOne(d => d.FirstRuneNavigation)
                    .WithMany(p => p.RunesBuildFirstRuneNavigations)
                    .HasForeignKey(d => d.FirstRune)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RunesBuild_Runes");

                entity.HasOne(d => d.FirstRuneSNavigation)
                    .WithMany(p => p.RunesBuildFirstRuneSNavigations)
                    .HasForeignKey(d => d.FirstRuneS)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RunesBuild_Runes4");

                entity.HasOne(d => d.FourthRuneNavigation)
                    .WithMany(p => p.RunesBuildFourthRuneNavigations)
                    .HasForeignKey(d => d.FourthRune)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RunesBuild_Runes3");

                entity.HasOne(d => d.MainrRuneNavigation)
                    .WithMany(p => p.RunesBuildMainrRuneNavigations)
                    .HasForeignKey(d => d.MainrRune)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RunesBuild_MainRunes");

                entity.HasOne(d => d.SecondExtraRuneNavigation)
                    .WithMany(p => p.RunesBuildSecondExtraRuneNavigations)
                    .HasForeignKey(d => d.SecondExtraRune)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RunesBuild_ExtraRunes1");

                entity.HasOne(d => d.SecondMainRuneNavigation)
                    .WithMany(p => p.RunesBuildSecondMainRuneNavigations)
                    .HasForeignKey(d => d.SecondMainRune)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RunesBuild_MainRunes1");

                entity.HasOne(d => d.SecondRuneNavigation)
                    .WithMany(p => p.RunesBuildSecondRuneNavigations)
                    .HasForeignKey(d => d.SecondRune)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RunesBuild_Runes1");

                entity.HasOne(d => d.SecondRuneSNavigation)
                    .WithMany(p => p.RunesBuildSecondRuneSNavigations)
                    .HasForeignKey(d => d.SecondRuneS)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RunesBuild_Runes5");

                entity.HasOne(d => d.ThirdExtraRuneNavigation)
                    .WithMany(p => p.RunesBuildThirdExtraRuneNavigations)
                    .HasForeignKey(d => d.ThirdExtraRune)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RunesBuild_ExtraRunes2");

                entity.HasOne(d => d.ThirdRuneNavigation)
                    .WithMany(p => p.RunesBuildThirdRuneNavigations)
                    .HasForeignKey(d => d.ThirdRune)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RunesBuild_Runes2");
            });

            modelBuilder.Entity<Spell>(entity =>
            {
                entity.ToTable("Spell");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Image)
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
