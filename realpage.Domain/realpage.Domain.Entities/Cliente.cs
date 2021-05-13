using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace realpage.Domain.Entities
{
    public class Cliente 
    {
        [Key]
        public int Id { get; set; }
        public string CodigoCliente { get; set; }
        public string NombreCliente { get; set; }
        public int Edad { get; set; }
        public string DireccionCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public string DescripcionCliente { get; set; }
        public DateTime? FechaIngreso { get; set; }

        //public virtual List<FacturaVenta> FacturaVenta { get; set; }
    }
}
