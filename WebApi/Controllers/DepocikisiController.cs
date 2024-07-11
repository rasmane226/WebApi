using AutoMapper;
using DAL.Dtos.BolumlerDtos;
using DAL.Dtos.DepocikisiDtos;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepocikisiController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public DepocikisiController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetDepocikisi()
        {
            var depocikisi = _context.Depocikisis.ToList();
            return Ok(depocikisi);
        }

        [HttpGet("{ID}")]
        public IActionResult GetDepocikisi(int ID)
        {
            var depocikisi = _context.Depocikisis.Find(ID);
            if (depocikisi == null)
            {
                return NotFound("Bu id'ye ait bölum bulunmıyor!");
            }

            return Ok(depocikisi);
        }

        [HttpPost]
        public IActionResult CreateDepocikisi([FromBody] CreateDepocikisiDtos createdepocikisiDto)
        {
            if (ModelState.IsValid)
            {
                var depocikisi = _mapper.Map<Depocikisi>(createdepocikisiDto);

                _context.Depocikisis.Add(depocikisi);
                _context.SaveChanges();
                return Ok("Yeni Depocikisi ekendi");
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{ID}")]

        public IActionResult UpdateDepocikisi(int ID, [FromBody] UpdateDepocikisiDtos depocikisidtos)
        {

            var depocikisi = _context.Depocikisis.Find(ID);
            if (depocikisi == null)
            {
                return NotFound("Bu ID eşleşmiyor!");
            }
            _mapper.Map(depocikisidtos, depocikisi);
            _context.Entry(depocikisi).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(new { message = "Güncelleme Başarılı" });
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDepocikisi(int id)
        {
            var depocikisi = _context.Depocikisis.Find(id);
            if (depocikisi == null)
            {
                return NotFound("Bu depocikisi bulunmuyor.");
            }

            _context.Depocikisis.Remove(depocikisi);
            _context.SaveChanges();

            return Ok("Silme işlemi başarılı.");
        }
    }
}
