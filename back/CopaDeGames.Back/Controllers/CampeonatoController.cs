using System;
using System.Threading.Tasks;
using CopaDeGames.Back.Domain.Repositories.Data;
using CopaDeGames.Back.Domain.Services;
using CopaDeGames.Back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CopaDeGames.Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampeonatoController : ControllerBase
    {
        private readonly ICampeonatoRepository _campeonatoRepository;
        private readonly ICampeonatoService _campeonatoService;
        private readonly ILogger _logger;

        public CampeonatoController(ILogger<CampeonatoController> logger, ICampeonatoRepository campeonatoRepository, ICampeonatoService campeonatoService)
        {
            _logger = logger;
            _campeonatoRepository = campeonatoRepository;
            _campeonatoService = campeonatoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogTrace($"Inicio da execução do método Get().");
            var campeonatos = await _campeonatoRepository.Listar();

            if (campeonatos == null)
                return NotFound();

            _logger.LogTrace($"Fim da execução do método Get().");
            return Ok(campeonatos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            _logger.LogTrace($"Inicio da execução do método Get(Guid id).");

            var campeonato = await _campeonatoRepository.Buscar(id);

            if (campeonato == null)
                return NotFound();

            _logger.LogTrace($"Fim da execução do método Get(Guid id).");
            return Ok(campeonato);
        }

        [HttpPost]
        public async Task<IActionResult> Post(string[] request)
        {
            _logger.LogTrace($"Inicio da execução do método Post(string[] request).");

            var campeonato = await _campeonatoService.IniciarCampeonato(request);

            _logger.LogTrace($"Fim da execução do método Post(string[] request).");
            return Ok(new CampeonatoResult(campeonato));
        }
    }
}