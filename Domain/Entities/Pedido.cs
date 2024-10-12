using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica_1_P2.Domain.Entities
{
    [Table("Pedidos")]
    public class Pedido
    {
        [Key]

        public int Id_Pedido { get; set; }
        public int UsuarioID { get; set; }
        // Usar array de enteros para almacenar los IDs de los productos
        [Column(TypeName = "json")] // Se almacena como JSON en la base de datos
        public int[] Productos { get; set; }
    }
}
