using AutoMapper;
using DAL.Dtos.BolumlerDtos;
using DAL.Dtos.UrunlerDtos;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunlerController : ControllerBase
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UrunlerController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetUrunler()
        {
            var Urunler= _context.Urunlers.ToList();
            return Ok(Urunler);
        }

        [HttpGet("{id}")]
        public IActionResult GetUrunler(int id)
        {
            var urunler = _context.Urunlers.Find(id);
            if (urunler == null)
            {
                return NotFound("Bu id'ye ait Urun bulunmıyor!");
            }

            return Ok(urunler);
        }

        [HttpPost]
        public IActionResult CreateUrun([FromBody] CreateUrunlerDtos createurunlerDto)
        {
            if (ModelState.IsValid)
            {
                var urunler = _mapper.Map<Urunler>(createurunlerDto);

                _context.Urunlers.Add(urunler);
                _context.SaveChanges();
                return Ok("Yeni Urun ekendi");
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{ID}")]

        public IActionResult UpdateUrunler(int ID, [FromBody] UpdateUrunlerDtos urundtos)
        {

            var urunler = _context.Urunlers.Find(ID);
            if (urunler == null)
            {
                return NotFound("Bu ID eşleşmiyor!");
            }
            _mapper.Map(urundtos, urunler);
            _context.Entry(urunler).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(new { message = "Güncelleme Başarılı" });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUrunler(int id)
        {
            var urunler = _context.Urunlers.Find(id);
            if (urunler == null)
            {
                return NotFound("Bu urun bulunmuyor.");
            }

            _context.Urunlers.Remove(urunler);
            _context.SaveChanges();

            return Ok("Silme işlemi başarılı.");
        }


    }
}
