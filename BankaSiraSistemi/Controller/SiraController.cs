using System.Text.Json;
using BankaSiraSistemi.Services;
using BankaSiraSistemi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankaSiraSistemi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SiraController : ControllerBase
    {
        private readonly SiraYonetimi _siraYonetimi;

        public SiraController(SiraYonetimi siraYonetimi)
        {
            _siraYonetimi = siraYonetimi;
        }

        [HttpPost("sira-al")]
        public IActionResult SiraAl([FromBody] JsonElement body)
        {
            var tc = body.GetString();
            _siraYonetimi.SiraAl(tc);
            return Ok(new { Message = "Sıra alındı." }); // ✅ mesaj döner
        }

        [HttpPost("sira-cagir")]
        public IActionResult SiraCagir()
        {
            var musteri = _siraYonetimi.SiraCagir();
            if (musteri == null)
                return Ok(new { Message = "Bekleyen müşteri yok." }); // ✅ mesaj döner

            return Ok(musteri);
        }

        [HttpGet("sira-durumu")]
        public IActionResult SiraDurumu()
        {
            return Ok(_siraYonetimi.SiraDurumu());
        }
    }
}
