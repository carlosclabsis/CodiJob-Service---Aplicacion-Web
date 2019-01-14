using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infraestructure.Persistencia
{
    public partial class CodiJobDbContext : DbContext
    {
        public CodiJobDbContext()
        {
        }

        public CodiJobDbContext(DbContextOptions<CodiJobDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TGrupo> TGrupo { get; set; }
        public virtual DbSet<TProyecto> TProyecto { get; set; }
        public virtual DbSet<TSkill> TSkill { get; set; }
        public virtual DbSet<TUsuariogrupo> TUsuariogrupo { get; set; }
        public virtual DbSet<TUsuarioperfil> TUsuarioperfil { get; set; }
        public virtual DbSet<TUsuarioproyecto> TUsuarioproyecto { get; set; }
        public virtual DbSet<TUsuskill> TUsuskill { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source = 172.23.0.209; initial catalog = CodiJob; user id = sa; password = desarrollo2012");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TGrupo>(entity =>
            {
                entity.ToTable("t_grupo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.GrupoFoto)
                    .HasColumnName("grupo_foto")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GrupoNom)
                    .HasColumnName("grupo_nom")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GrupoProm)
                    .HasColumnName("grupo_prom")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TProyecto>(entity =>
            {
                entity.HasKey(e => e.ProyId);

                entity.ToTable("t_proyecto");

                entity.Property(e => e.ProyId)
                    .HasColumnName("proy_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProyDesc)
                    .HasColumnName("proy_desc")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProyFecha)
                    .HasColumnName("proy_fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProyNom)
                    .HasColumnName("proy_nom")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProyUrl)
                    .HasColumnName("proy_url")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TSkill>(entity =>
            {
                entity.HasKey(e => e.SkillId);

                entity.ToTable("t_skill");

                entity.Property(e => e.SkillId)
                    .HasColumnName("skill_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.SkillNom)
                    .HasColumnName("skill_nom")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TUsuariogrupo>(entity =>
            {
                entity.HasKey(e => e.UsugrupoId);

                entity.ToTable("t_usuariogrupo");

                entity.Property(e => e.UsugrupoId)
                    .HasColumnName("usugrupo_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.GrupoId).HasColumnName("grupo_id");

                entity.Property(e => e.UsuId).HasColumnName("usu_id");

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.TUsuariogrupo)
                    .HasForeignKey(d => d.GrupoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_usuariogrupo_t_grupo");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.TUsuariogrupo)
                    .HasForeignKey(d => d.UsuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_usuariogrupo_t_usuarioperfil");
            });

            modelBuilder.Entity<TUsuarioperfil>(entity =>
            {
                entity.HasKey(e => e.UsuperId);

                entity.ToTable("t_usuarioperfil");

                entity.Property(e => e.UsuperId)
                    .HasColumnName("usuper_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.UsuperBlog)
                    .HasColumnName("usuper_blog")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuperDesc)
                    .HasColumnName("usuper_desc")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuperGit)
                    .HasColumnName("usuper_git")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuperWeb)
                    .HasColumnName("usuper_web")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TUsuarioproyecto>(entity =>
            {
                entity.HasKey(e => e.UsuproId);

                entity.ToTable("t_usuarioproyecto");

                entity.Property(e => e.UsuproId)
                    .HasColumnName("usupro_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProyId).HasColumnName("proy_id");

                entity.Property(e => e.UsuId).HasColumnName("usu_id");

                entity.HasOne(d => d.Proy)
                    .WithMany(p => p.TUsuarioproyecto)
                    .HasForeignKey(d => d.ProyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_usuarioproyecto_t_proyecto");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.TUsuarioproyecto)
                    .HasForeignKey(d => d.UsuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_usuarioproyecto_t_usuarioperfil");
            });

            modelBuilder.Entity<TUsuskill>(entity =>
            {
                entity.HasKey(e => e.UsuskillId);

                entity.ToTable("t_ususkill");

                entity.Property(e => e.UsuskillId)
                    .HasColumnName("ususkill_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.SkillId).HasColumnName("skill_id");

                entity.Property(e => e.UsuId).HasColumnName("usu_id");

                entity.Property(e => e.UsuskillNivel)
                    .HasColumnName("ususkill_nivel")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuskillVeri).HasColumnName("ususkill_veri");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.TUsuskill)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_ususkill_t_skill");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.TUsuskill)
                    .HasForeignKey(d => d.UsuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t_ususkill_t_usuarioperfil");
            });
        }
    }
}
