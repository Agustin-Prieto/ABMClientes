namespace ClientesABM.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Ciudades> Ciudades { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Facturas> Facturas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ciudades>()
                .HasMany(e => e.Clientes)
                .WithRequired(e => e.Ciudades)
                .HasForeignKey(e => e.Ciudad_Id);

            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.Facturas)
                .WithRequired(e => e.Clientes)
                .HasForeignKey(e => e.Cliente_Id);
        }
    }
}
