using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Bolumler
    {
        public int ID { get; set; }

        public string? Ad { get; set; }

        public bool Aktif { get; set; }
        public required ICollection<Urunler> Urunlers { get; set; }
    }

    
}
