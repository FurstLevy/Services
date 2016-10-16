using System;

namespace Services.Rest.Server.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNacimento { get; set; }
    }
}