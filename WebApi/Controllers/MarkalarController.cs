using AutoMapper;
using DAL.Dtos.MarkalarDtos;
using DAL.Dtos.UrunlerDtos;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkalarController : ControllerBase
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public MarkalarController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetMarkalar()
        {
            var markalar = _context.Markalars.ToList();
            return Ok(markalar);
        }
        [HttpGet("{id}")]
        public IActionResult GetMarkalar(int id)
        {
            var markalar = _context.Markalars.Find(id);
            if (markalar == null)
            {
                return NotFound("Bu id'ye ait Marka bulunmuyor!");
            }

            return Ok(markalar);
        }

        [HttpPost]
        public IActionResult CreateMarka([FromBody] CreateMarkalarDtos createmarkalarDto)
        {
            if (ModelState.IsValid)
            {
                var markalar = _mapper.Map<Markalar>(createmarkalarDto);

                _context.Markalars.Add(markalar);
                _context.SaveChanges();
                return Ok("Yeni Marka ekendi");
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{ID}")]

        public IActionResult UpdateMarkalar(int ID, [FromBody] UpdateMarkalarDtos markadtos)
        {

            var markalar = _context.Markalars.Find(ID);
            if (markalar == null)
            {
                return NotFound("Bu ID eşleşmiyor!");
            }
            _mapper.Map(markadtos, markalar);
            _context.Entry(markalar).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(new { message = "Güncelleme Başarılı" });
        }

        [HttpDelete("{ID}")]
        public IActionResult DeleteMarkalar(int ID)
        {
            var markalar = _context.Markalars.Find(ID);
            if (markalar == null)
            {
                return NotFound("Bu marka bulunmuyor.");
            }

            _context.Markalars.Remove(markalar);
            _context.SaveChanges();

            return Ok("Silme işlemi başarılı.");
        }

    }
}
