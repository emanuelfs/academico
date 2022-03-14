using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace academico.Models
{
    public partial class academicoContext : DbContext
    {
        public academicoContext()
        {
        }

        public academicoContext(DbContextOptions<academicoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAluno> TbAlunos { get; set; } = null!;
        public virtual DbSet<TbAvaliacao> TbAvaliacaos { get; set; } = null!;
        public virtual DbSet<TbDisciplina> TbDisciplinas { get; set; } = null!;
        public virtual DbSet<TbProfessor> TbProfessors { get; set; } = null!;
        public virtual DbSet<TbTurma> TbTurmas { get; set; } = null!;
        public virtual DbSet<TbrAlunoTurma> TbrAlunoTurmas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=academico;Trusted_Connection=True;TrustServerCertificate=True;User Id=sa;Password=P@ssw0rd;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAluno>(entity =>
            {
                entity.ToTable("tb_aluno");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<TbAvaliacao>(entity =>
            {
                entity.ToTable("tb_avaliacao");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Conceito)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("conceito");

                entity.Property(e => e.IdAlunoTurma).HasColumnName("id_aluno_turma");

                entity.HasOne(d => d.IdAlunoTurmaNavigation)
                    .WithMany(p => p.TbAvaliacaos)
                    .HasForeignKey(d => d.IdAlunoTurma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_avaliacao_tbr_aluno_turma");
            });

            modelBuilder.Entity<TbDisciplina>(entity =>
            {
                entity.ToTable("tb_disciplina");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<TbProfessor>(entity =>
            {
                entity.ToTable("tb_professor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<TbTurma>(entity =>
            {
                entity.ToTable("tb_turma");

                entity.HasIndex(e => new { e.Ano, e.Semestre, e.IdDisciplina, e.IdProfessor }, "UK_tb_turma")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ano).HasColumnName("ano");

                entity.Property(e => e.IdDisciplina).HasColumnName("id_disciplina");

                entity.Property(e => e.IdProfessor).HasColumnName("id_professor");

                entity.Property(e => e.Semestre).HasColumnName("semestre");

                entity.HasOne(d => d.IdDisciplinaNavigation)
                    .WithMany(p => p.TbTurmas)
                    .HasForeignKey(d => d.IdDisciplina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_turma_tb_disciplina");

                entity.HasOne(d => d.IdProfessorNavigation)
                    .WithMany(p => p.TbTurmas)
                    .HasForeignKey(d => d.IdProfessor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_turma_tb_professor");
            });

            modelBuilder.Entity<TbrAlunoTurma>(entity =>
            {
                entity.ToTable("tbr_aluno_turma");

                entity.HasIndex(e => new { e.IdAluno, e.IdTurma }, "UK_tbr_aluno_turma")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ConceitoFinal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("conceito_final");

                entity.Property(e => e.IdAluno).HasColumnName("id_aluno");

                entity.Property(e => e.IdTurma).HasColumnName("id_turma");

                entity.Property(e => e.Situacao)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("situacao");

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.TbrAlunoTurmas)
                    .HasForeignKey(d => d.IdAluno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbr_aluno_turma_tbr_aluno_turma");

                entity.HasOne(d => d.IdTurmaNavigation)
                    .WithMany(p => p.TbrAlunoTurmas)
                    .HasForeignKey(d => d.IdTurma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbr_aluno_turma_tb_turma");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
