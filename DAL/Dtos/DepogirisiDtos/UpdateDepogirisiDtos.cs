using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dtos.DepogirisiDtos
{
    public class UpdateDepogirisiDtos
    {
        public int ID { get; set; }
        public string? Ad { get; set; }
        public string? Marka { get; set; }
        public string? Model { get; set; }
        public int SeriNo { get; set; }
        public int Adet { get; set; }
        public DateFormat AlimTarihi { get; set; }
        public DateFormat GirisTarihi { get; set; }
        public string? Aciklama { get; set; }
    }
}
