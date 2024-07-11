using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dtos.UrunlerDtos
{
    public class CreateUrunlerDtos
    {
       
        public string? Ad { get; set; }

        public bool Aktif { get; set; }
        public int BolumlerId { get; set; }
    }
}
