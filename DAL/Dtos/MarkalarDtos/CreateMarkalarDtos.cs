using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dtos.MarkalarDtos
{
    public class CreateMarkalarDtos
    {

        public string? Ad { get; set; }

        public bool Aktif { get; set; }
        public int UrunlerId { get; set; }
    }
}
