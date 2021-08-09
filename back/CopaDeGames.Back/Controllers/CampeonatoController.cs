using System;
using System.Threading.Tasks;
using CopaDeGames.Back.Domain.Repositories.Data;
using CopaDeGames.Back.Domain.Services;
using CopaDeGames.Back.Models;
using Microsoft.AspNetCore.Mvc;

namespace CopaDeGames.Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampeonatoController : ControllerBase
    {
        private readonly ICampeonatoRepository _campeonatoRepository;
        private readonly ICampeonatoService _campeonatoService;

        public CampeonatoController(ICampeonatoRepository campeonatoRepository, ICampeonatoService campeonatoService)
        {
            _campeonatoRepository = campeonatoRepository;
            _campeonatoService = campeonatoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var campeonatos = await _campeonatoRepository.Listar();

            if (campeonatos == null)
                return NotFound();

            return Ok(campeonatos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var campeonato = await _campeonatoRepository.Buscar(id);

            if (campeonato == null)
                return NotFound();

            return Ok(campeonato);
        }

        [HttpPost]
        public async Task<IActionResult> Post(string[] request)
        {   
            var campeonato = await _campeonatoService.IniciarCampeonato(request);   
            return Ok(new CampeonatoResult(campeonato));
        }
    }
}