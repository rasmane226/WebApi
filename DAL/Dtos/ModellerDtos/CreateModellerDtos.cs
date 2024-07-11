using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dtos.ModellerDtos
{
    public class CreateModellerDtos
    {
        

        public string? Ad { get; set; }

        public int Adet { get; set; }

        public bool Aktif { get; set; }
        public int MarkalarId { get; set; }
    }
}
