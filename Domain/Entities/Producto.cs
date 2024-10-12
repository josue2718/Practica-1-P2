using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica_1_P2.Domain.Entities
{
    [Table("Productos")]
    public class Producto
    {
        [Key]

        public int Id_Producto { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }

    }
}
