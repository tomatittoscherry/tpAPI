using tpAPI.Domain.Request;
using tpAPI.Domain.Response;
using tpAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace tpAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //api/Director
    public class ActoresController : ControllerBase
    {
        private readonly IDBM_5Context _context; //inyección de dependencia
        public ActoresController(IDBM_5Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetActores([FromQuery] GetActoresRequest request) //ver cuales te queres saltear y cuales queres tomar
        {
            //Paginado => no hacer un select all
            int Skip = request.skip;
            int Take = request.take;

            //var result = _context.Directores.ToList(); //select * from Directores => select all, no se suele hacer un ToList para no traer toda la info de una
            //return Ok(new { Director = "algún nombre" });
            var result = _context.Actores.Skip(Skip).Take(Take).ToList();
            int count = _context.Actores.Count();

            var response = new GetActoresResponse()
            {
                Actores = result,
                Total = count,
            };

            return Ok(response);
        }

        [HttpGet("{ID}")]
        public IActionResult GetActorById([FromRoute] int ID)
        {
            var result = _context.Actores.FirstOrDefault(f => f.IdActor == ID); //es similar al Where

            if (result == null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(new { Error = $"no se encontró el ID {ID}" });
            }
        }

        [HttpGet("Actuaciones")]
        public IActionResult GetAcuacionesByActores([FromQuery] int idActor)
        {
            var result = _context.Actores.Where(w => w.IdActor == idActor).Include(i => i.Actuaciones).ToList();

            return Ok(result);
        }
    }
}