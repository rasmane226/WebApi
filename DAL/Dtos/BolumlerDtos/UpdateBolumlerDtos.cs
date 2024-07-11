using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dtos.BolumlerDtos
{
    public class UpdateBolumlerDtos
    {
       
        public int ID { get; set; }
        public string? Ad { get; set; }

        public bool Aktif { get; set; }
    }
}
