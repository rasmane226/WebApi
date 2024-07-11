using AutoMapper;
using DAL.Dtos.BolumlerDtos;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;


namespace WebApi.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class BolumlerController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public BolumlerController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetBolumler()
        {
            var bolumler = _context.Bolumlers.ToList();
            return Ok(bolumler);
        }

        [HttpGet("{ID}")]
        public IActionResult  GetBolumler(int ID)
        {
            var bolumler = _context.Bolumlers.Find(ID);
            if (bolumler == null)
            {
                return NotFound("Bu id'ye ait bölum bulunmıyor!");
            }

            return Ok(bolumler);
        }


        [HttpPost]
        public IActionResult CreateBolum([FromBody] CreateBolumlerDtos createBolumlerDto)
        {
            if (ModelState.IsValid)
            {
                var bolumler = _mapper.Map<Bolumler>(createBolumlerDto);

                _context.Bolumlers.Add(bolumler);
                _context.SaveChanges();
                return Ok("Yeni Bolüm ekendi");
            }
            return BadRequest(ModelState);
        }
       

        [HttpPut("{ID}")]
        
        public IActionResult UpdateBolumler(int ID, [FromBody] UpdateBolumlerDtos bolumdtos)
        {

            var bolumler =  _context.Bolumlers.Find(ID);
            if (bolumler == null)
            {
                return NotFound("Bu ID eşleşmiyor!");
            }
            _mapper.Map(bolumdtos, bolumler);
            _context.Entry(bolumler).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(new { message = "Güncelleme Başarılı" });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBolumler(int id)
        {
            var bolumler = _context.Bolumlers.Find(id);
            if (bolumler == null)
            {
                return NotFound("Bu bölüm bulunmuyor.");
            }

            _context.Bolumlers.Remove(bolumler);
            _context.SaveChanges();

            return Ok("Silme işlemi başarılı.");
        }
    }
}
