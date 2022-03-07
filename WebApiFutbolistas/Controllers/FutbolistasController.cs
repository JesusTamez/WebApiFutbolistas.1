using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiFutbolistas.Entidades;

namespace WebApiFutbolistas.Controllers
{
    [ApiController]
    [Route("api/futbolistas")]
    public class FutbolistasController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public FutbolistasController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        [HttpGet("Listado")]
        [HttpGet("/ListadoEquipo")]
        public async Task<ActionResult<List<Futbolista>>> Get()
        {
            return await dbContext.Futbolistas.Include(x => x.equipos).ToListAsync();
        }

        [HttpGet("primero")]
        public async Task<ActionResult<Futbolista>> PrimerFutbolista([FromHeader] int valor, [FromQuery] string futbolista, [FromQuery] int futbolistaId)
        {
            return await dbContext.Futbolistas.FirstOrDefaultAsync();
        }

        [HttpGet("primero2")]
        public ActionResult<Futbolista> PrimerFutbolista()
        {
            return new Futbolista() { Nombre = "DOS" };
        }

        [HttpGet("{id:int}/{param}")]
        public async Task<ActionResult<Futbolista>> Get(int id, string param)
        {
            var futbolista = await dbContext.Futbolistas.FirstOrDefaultAsync(x => x.Id == id);

            if(futbolista == null)
            {
                return NotFound();
            }
            return futbolista;
        }

        
        [HttpGet("{nombre}")]
        public async Task<ActionResult<Futbolista>> Get([FromRoute] string nombre)
        {
            var futbolista = await dbContext.Futbolistas.FirstOrDefaultAsync(x => x.Nombre.Contains(nombre));

            if(futbolista == null)
            {
                return NotFound();
            }

            return futbolista;
        }


        [HttpPost]

        public async Task<ActionResult> Post(Futbolista futbolista)
        {
            dbContext.Add(futbolista);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Futbolista futbolista, int id)
        {
            if(futbolista.Id != id)
            {
                return BadRequest("El id del futbolista no coincide con el establecido en la url. ");
            }
            dbContext.Update(futbolista);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Futbolistas.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }
            dbContext.Remove(new Futbolista()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
