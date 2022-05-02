using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

namespace _5I_Frisoni_Differenze.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class TrovaDifferenzeController : ControllerBase
    {
        private readonly DbTrovaLeDifferenze _context;

        public TrovaDifferenzeController(DbTrovaLeDifferenze context)
        {
            _context = context;
        }

        // GET: api/Differenze
        [HttpGet("Random")]
        public async Task<ActionResult<DomandaImmagineDTO>> GetDomanda()
        {
            List<DomandaImmagine> elencoDomande = await _context.DomandeImmagine.ToListAsync();
            return await elencoDomande.OrderBy(o => Guid.NewGuid()).First().GetDTO(_context);
        }
    }
}
