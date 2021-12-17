using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Boteco32.Models
{
    public partial class Boteco32Context : DbContext
    {
        public Boteco32Context()
        {
        }

        public Boteco32Context(DbContextOptions<Boteco32Context> options)
            : base(options)
        {
        }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<ItemPedido> ItemPedidos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Boteco32;Trusted_Connection=True;Connection Timeout=60;User ID=sa;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(120)
                    .HasColumnName("endereco");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("nome");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("senha");

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("telefone");
            });

            modelBuilder.Entity<ItemPedido>(entity =>
            {
                entity.ToTable("ItemPedido");

                entity.HasIndex(e => e.IdPedido, "IX_ItemPedido_idPedido");

                entity.HasIndex(e => e.IdProduto, "IX_ItemPedido_idProduto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdPedido).HasColumnName("idPedido");

                entity.Property(e => e.IdProduto).HasColumnName("idProduto");

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.ItemPedidos)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemPedido_Pedido");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.ItemPedidos)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemPedido_Produto");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("Pedido");

                entity.HasIndex(e => e.IdCliente, "IX_Pedido_idCliente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("data");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.Property(e => e.ValorTotal)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("valorTotal");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedido_Cliente");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("Produto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("nome");

                entity.Property(e => e.Preco)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("preco");

                entity.Property(e => e.SaldoEstoque).HasColumnName("saldoEstoque");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
