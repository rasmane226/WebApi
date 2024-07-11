using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Markalar
    {
        public int ID { get; set; }

        public string? Ad { get; set; }

        public bool Aktif { get; set; }
        public int UrunlerId { get; set; }
        public required Urunler Urunler { get; set; }
        public required ICollection<Modeller> Modellers { get; set; }
    }
}
