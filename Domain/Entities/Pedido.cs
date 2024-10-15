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
        
        [Column(TypeName = "json")] 
        public int[] Productos { get; set; }
    }
}
