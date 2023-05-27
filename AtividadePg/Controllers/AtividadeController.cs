using AtividadePg.Data;
using AtividadePg.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtividadePg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtividadeController : ControllerBase
    {
        private readonly APIDbContext _context;

        public AtividadeController (APIDbContext context)
        {
            _context = context; 
        }
        [HttpGet]
        public ActionResult<List<Atividade>> GetAll()
        {
            List<Atividade> atividades = _context.atividade.ToList();
            return Ok(atividades);
        }

        [HttpGet("{id}")]
        public ActionResult<Atividade> GetById(Guid id)
        {
            Atividade atividade = _context.atividade.FirstOrDefault(a => a.Id == id);
            if (atividade == null)
            {
                return NotFound();
            }
            return Ok(atividade);
        }

        [HttpPost]
        public ActionResult<Atividade> Create([FromBody] Atividade novaAtividade)
        {
            _context.atividade.Add(novaAtividade);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = novaAtividade.Id }, novaAtividade);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Atividade atividadeAtualizada)
        {
            Atividade atividadeExistente = _context.atividade.FirstOrDefault(a => a.Id == id);
            if (atividadeExistente == null)
            {
                return NotFound();
            }

            atividadeExistente.Nome = atividadeAtualizada.Nome;
            atividadeExistente.Status = atividadeAtualizada.Status;
            atividadeExistente.DataFinalizacao = atividadeAtualizada.DataFinalizacao;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            Atividade atividade = _context.atividade.FirstOrDefault(a => a.Id == id);
            if (atividade == null)
            {
                return NotFound();
            }

            _context.atividade.Remove(atividade);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut("/Finalizar/{id}")]
        public IActionResult FinalizarAtividade(Guid id)
        {
            Atividade atividadeExistente = _context.atividade.FirstOrDefault(a => a.Id == id);
            if (atividadeExistente == null)
            {
                return NotFound();
            }

            atividadeExistente.Status = "Finalizada";

            _context.SaveChanges();
            return NoContent();
        }
    }
}
