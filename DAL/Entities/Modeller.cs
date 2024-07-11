using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Modeller
    {
        public int ID { get; set; }

        public string? Ad { get; set; }

        public int Adet { get; set; }

        public bool Aktif { get; set; }
        public int MarkalarId { get; set; }
        public required Markalar Markalar { get; set; }
    }
}
