using API_Web.Data;
using API_Web.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateurController : ControllerBase
    {
        private DataContext _context;

        public UtilisateurController(DataContext context)
        {
            _context = context;
        }

        // GET: api/<UtilisateurController>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilisateur>>> GetUtilisateur()
        {
            return Ok(await _context.Utilisateurs.ToListAsync());
        }

        // GET api/<UtilisateurController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Utilisateur>> Get(int id)
        {
            try
            {
                // Récupération de l'utilisateur via le _context de manière asynchrone
                var utilisateur = await _context.Utilisateurs.FindAsync(id);

                // Vérification si l'utilisateur existe
                if (utilisateur == null)
                {
                    // Retourne une réponse NotFound si l'utilisateur n'est pas trouvé
                    return NotFound($"Utilisateur avec l'ID {id} non trouvé");
                }

                // Retourne l'utilisateur trouvé
                return Ok(utilisateur);
            }
            catch (Exception ex)
            {
                // Gestion des exceptions (log, retour d'une erreur générique, etc.)
                return StatusCode(500, $"Erreur lors de la récupération de l'utilisateur : {ex.Message}");
            }
        }
 

        // POST api/<UtilisateurController>
        [HttpPost]
        public async Task<ActionResult<Utilisateur>> PostUtilisateur(Utilisateur utilisateur)
        {
            _context.Utilisateurs.Add(utilisateur);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUtilisateur), new { id = utilisateur.Id }, utilisateur);
        }

        // POST api/<UtilisateurController>/login
        [HttpPost("login")]
        public async Task<IActionResult> Post(int log, [FromBody] string pass)
        {
            // Use LINQ to query the database
            var utilisateur = await _context.Utilisateurs
                .Where(u => u.Id == log && u.Pass == pass)
                .FirstOrDefaultAsync();

            if (utilisateur == null)
            {
                // User not found or password incorrect
                return BadRequest("Invalid credentials");
            }

            // Authentication successful
            // You can perform additional actions or return a success response
            return Ok("Authentication successful");
        }

        /*
         * Implémente une fonction qui sera accessible en POST sur l'URL </login> du controller
         * Elle prendra en paramètre l'identifiant de l'utilisateur ainsi que le pass.
         * Utilise FirstOrDefaultAsync et regarde comment on fait une query LINQ*/

        // DELETE api/<UtilisateurController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
