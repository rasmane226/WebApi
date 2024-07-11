using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dtos.DepocikisiDtos
{
    public class CreateDepocikisiDtos
    {
        
        public string? Ad { get; set; }
        public string? Marka { get; set; }
        public string? Model { get; set; }
        public int SeriNo { get; set; }
        public int Adet { get; set; }
        public DateFormat TeslimTarihi { get; set; }
        public string? VerilenBirimi { get; set; }
        public string? VerilenPersonel { get; set; }
        public string? Aciklama { get; set; }
    }
}
