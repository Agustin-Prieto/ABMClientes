namespace ClientesABM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Facturas
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        [Required]
        [StringLength(200)]
        public string Detalle { get; set; }

        public decimal Importe { get; set; }

        public int Cliente_Id { get; set; }

        public virtual Clientes Clientes { get; set; }
    }
}
