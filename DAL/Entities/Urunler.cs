using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Urunler
    {
        public int ID { get; set; }

        public string? Ad { get; set; }

        public bool Aktif { get; set; }
        public int BolumlerId { get; set; }
        public required Bolumler Bolumler { get; set; }
        public required ICollection<Markalar> Markalars { get; set; }
    }
}
