using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CompratodoUI.Models
{
    public partial class BDCatalogoContext : DbContext
    {
        public BDCatalogoContext()
        {
        }

        public BDCatalogoContext(DbContextOptions<BDCatalogoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Denuncias> Denuncias { get; set; }
        public virtual DbSet<Notificaciones> Notificaciones { get; set; }
        public virtual DbSet<PaginaTipoUsuarios> PaginaTipoUsuarios { get; set; }
        public virtual DbSet<Paginas> Paginas { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<TipoUsuarios> TipoUsuarios { get; set; }
        public virtual DbSet<Vendedores> Vendedores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.  
                string conexionLocal = "Server=LAPTOP-AG12FGOC; database=BDCatalogo;Integrated security=true";
                string conexionRemota = "Data Source=SQL5063.site4now.net;Initial Catalog=DB_A65937_BDCatalogo;User Id=DB_A65937_BDCatalogo_admin;Password=bryan2020";
                optionsBuilder.UseSqlServer(conexionLocal);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.Iidcategoria)
                    .HasName("PK__Categori__B57A3B9F78928C8B");

                entity.Property(e => e.Iidcategoria).HasColumnName("IIDCATEGORIA");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Denuncias>(entity =>
            {
                entity.HasKey(e => e.Iiddenuncia)
                    .HasName("PK__Denuncia__953390E9C1F883C4");

                entity.Property(e => e.Iiddenuncia).HasColumnName("IIDDENUNCIA");

                entity.Property(e => e.Iidproducto).HasColumnName("IIDPRODUCTO");

                entity.Property(e => e.Motivo)
                    .IsRequired()
                    .HasColumnName("MOTIVO")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Ndenuncias).HasColumnName("NDENUNCIAS");

                entity.HasOne(d => d.IidproductoNavigation)
                    .WithMany(p => p.Denuncias)
                    .HasForeignKey(d => d.Iidproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Denuncias__IIDPR__4222D4EF");
            });

            modelBuilder.Entity<Notificaciones>(entity =>
            {
                entity.HasKey(e => e.Iidnotificacion)
                    .HasName("PK__Notifica__7DA9A90A59FB3806");

                entity.Property(e => e.Iidnotificacion).HasColumnName("IIDNOTIFICACION");

                entity.Property(e => e.Iiddenuncia).HasColumnName("IIDDENUNCIA");

                entity.Property(e => e.Notificacionleida).HasColumnName("NOTIFICACIONLEIDA");

                entity.HasOne(d => d.IiddenunciaNavigation)
                    .WithMany(p => p.Notificaciones)
                    .HasForeignKey(d => d.Iiddenuncia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificac__IIDDE__44FF419A");
            });

            modelBuilder.Entity<PaginaTipoUsuarios>(entity =>
            {
                entity.HasKey(e => e.Iidpaginatipousuario)
                    .HasName("PK__PaginaTi__80FD031605592FF0");

                entity.Property(e => e.Iidpaginatipousuario).HasColumnName("IIDPAGINATIPOUSUARIO");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");

                entity.Property(e => e.Iidpagina).HasColumnName("IIDPAGINA");

                entity.Property(e => e.Iidtipousuario).HasColumnName("IIDTIPOUSUARIO");

                entity.HasOne(d => d.IidpaginaNavigation)
                    .WithMany(p => p.PaginaTipoUsuarios)
                    .HasForeignKey(d => d.Iidpagina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PaginaTip__IIDPA__49C3F6B7");

                entity.HasOne(d => d.IidtipousuarioNavigation)
                    .WithMany(p => p.PaginaTipoUsuarios)
                    .HasForeignKey(d => d.Iidtipousuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PaginaTip__IIDTI__4AB81AF0");
            });

            modelBuilder.Entity<Paginas>(entity =>
            {
                entity.HasKey(e => e.Iidpagina)
                    .HasName("PK__Paginas__8E759E4EE8DD971A");

                entity.Property(e => e.Iidpagina).HasColumnName("IIDPAGINA");

                entity.Property(e => e.Accion)
                    .IsRequired()
                    .HasColumnName("ACCION")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");

                entity.Property(e => e.Controlador)
                    .IsRequired()
                    .HasColumnName("CONTROLADOR")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Mensaje)
                    .IsRequired()
                    .HasColumnName("MENSAJE")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(e => e.Iidproducto)
                    .HasName("PK__Producto__158EDF302C28C982");

                entity.Property(e => e.Iidproducto).HasColumnName("IIDPRODUCTO");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Estadoventa).HasColumnName("ESTADOVENTA");

                entity.Property(e => e.Foto)
                    .IsRequired()
                    .HasColumnName("FOTO")
                    .IsUnicode(false);

                entity.Property(e => e.Iidcategoria).HasColumnName("IIDCATEGORIA");

                entity.Property(e => e.Iidvendedor).HasColumnName("IIDVENDEDOR");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Precio)
                    .HasColumnName("PRECIO")
                    .HasColumnType("money");

                entity.HasOne(d => d.IidcategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Iidcategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Productos__IIDCA__3E52440B");

                entity.HasOne(d => d.IidvendedorNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Iidvendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Productos__IIDVE__3F466844");
            });

            modelBuilder.Entity<TipoUsuarios>(entity =>
            {
                entity.HasKey(e => e.Iidtipousuario)
                    .HasName("PK__TipoUsua__A05A9116674640C1");

                entity.Property(e => e.Iidtipousuario).HasColumnName("IIDTIPOUSUARIO");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vendedores>(entity =>
            {
                entity.HasKey(e => e.Iidvendedor)
                    .HasName("PK__Vendedor__6C5F7483A4A740C3");

                entity.Property(e => e.Iidvendedor).HasColumnName("IIDVENDEDOR");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasColumnName("APELLIDOS")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasColumnName("CONTRASEÑA")
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnName("CORREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Iidtipousuario).HasColumnName("IIDTIPOUSUARIO");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombreusuario)
                    .IsRequired()
                    .HasColumnName("NOMBREUSUARIO")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Telefonocelular)
                    .IsRequired()
                    .HasColumnName("TELEFONOCELULAR")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IidtipousuarioNavigation)
                    .WithMany(p => p.Vendedores)
                    .HasForeignKey(d => d.Iidtipousuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Vendedore__IIDTI__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
