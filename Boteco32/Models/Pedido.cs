using System;

namespace Boteco32.Models
{
    public class Pedido
    {
        public long Id { get; set; }
        public int Numero { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorToal { get; set; }
    }
}
