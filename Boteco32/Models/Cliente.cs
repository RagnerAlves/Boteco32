using System;
using System.Collections.Generic;

namespace Boteco32.Models
{
    public partial class Cliente : Usuario
    {
        public Cliente()
        {
            Pedidos = new HashSet<Pedido>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
