using Microsoft.VisualBasic;

namespace Targaryen_PVI.Models
{
    public class Pedidos
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
    }
}
