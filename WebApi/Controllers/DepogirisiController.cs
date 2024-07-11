using AutoMapper;
using DAL.Dtos.DepogirisiDtos;
using DAL.Dtos.UrunlerDtos;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepogirisiController : ControllerBase
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public DepogirisiController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetDepogirisi()
        {
            var depogirisi = _context.Depogirisis.ToList();
            return Ok(depogirisi);
        }

        [HttpGet("{id}")]
        public IActionResult GetDepogirisi(int id)
        {
            var depogirisi = _context.Depogirisis.Find(id);
            if (depogirisi == null)
            {
                return NotFound("Bu id'ye ait Urun bulunmıyor!");
            }

            return Ok(depogirisi);
        }
        [HttpPost]
        public IActionResult CreateDepo([FromBody] CreateDepogirisiDtos createdepogiriDto)
        {
            if (ModelState.IsValid)
            {
                var depogirisi = _mapper.Map<Depogirisi>(createdepogiriDto);

                _context.Depogirisis.Add(depogirisi);
                _context.SaveChanges();
                return Ok("Yeni Depogirisi ekendi");
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{ID}")]

        public IActionResult UpdateDepogirisi(int ID, [FromBody] UpdateDepogirisiDtos depogirisidtos)
        {

            var depogirisi = _context.Depogirisis.Find(ID);
            if (depogirisi == null)
            {
                return NotFound("Bu ID eşleşmiyor!");
            }
            _mapper.Map(depogirisidtos, depogirisi);
            _context.Entry(depogirisi).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(new { message = "Güncelleme Başarılı" });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepogirisi(int id)
        {
            var depogirisi = _context.Depogirisis.Find(id);
            if (depogirisi == null)
            {
                return NotFound("Bu depo bulunmuyor.");
            }

            _context.Depogirisis.Remove(depogirisi);
            _context.SaveChanges();

            return Ok("Silme işlemi başarılı.");
        }
    }
}
