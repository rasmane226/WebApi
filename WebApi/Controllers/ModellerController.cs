using AutoMapper;
using DAL.Dtos.MarkalarDtos;
using DAL.Dtos.ModellerDtos;
using DAL.Dtos.UrunlerDtos;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModellerController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ModellerController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetModeller()
        {
            var modeller = _context.Modellers.ToList();
            return Ok(modeller);
        }
        [HttpGet("{id}")]
        public IActionResult GetModeller(int id)
        {
            var modeller = _context.Modellers.Find(id);
            if (modeller == null)
            {
                return NotFound("Bu id'ye ait Model bulunmuyor!");
            }

            return Ok(modeller);
        }
        [HttpPost]
        public IActionResult CreateModel([FromBody] CreateModellerDtos createmodellerDto)
        {
            if (ModelState.IsValid)
            {
                var modeller = _mapper.Map<Modeller>(createmodellerDto);

                _context.Modellers.Add(modeller);
                _context.SaveChanges();
                return Ok("Yeni Model ekendi");
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{ID}")]

        public IActionResult UpdateModeller(int ID, [FromBody] UpdateModellerDtos modeldtos)
        {

            var modeller = _context.Modellers.Find(ID);
            if (modeller == null)
            {
                return NotFound("Bu ID eşleşmiyor!");
            }
            _mapper.Map(modeldtos, modeller);
            _context.Entry(modeller).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(new { message = "Güncelleme Başarılı" });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteModeller(int id)
        {
            var modeller = _context.Modellers.Find(id);
            if (modeller == null)
            {
                return NotFound("Bu model bulunmuyor.");
            }

            _context.Modellers.Remove(modeller);
            _context.SaveChanges();

            return Ok("Silme işlemi başarılı.");
        }

    }
}
