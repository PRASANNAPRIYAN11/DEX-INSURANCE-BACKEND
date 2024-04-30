using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsuranceApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly InsuranceContext _context;

        public InsuranceController(InsuranceContext context)
        {
            _context = context;
        }

        // GET: api/Insurance/credentials
        [HttpGet("credentials")]
        public async Task<ActionResult<IEnumerable<Credential>>> GetCredentials()
        {
            return await _context.Credentials.ToListAsync();
        }

        // GET: api/Insurance/pol
        [HttpGet("pol")]
        public async Task<ActionResult<IEnumerable<Pol>>> GetPol()
        {
            return await _context.Pol.ToListAsync();
        }

        // POST: api/Insurance/credentials
        [HttpPost("credentials")]
        public async Task<IActionResult> PostCredential(Credential credential)
        {
            _context.Add(credential);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // POST: api/Insurance/pol
        [HttpPost("pol")]
        public async Task<IActionResult> PostPol(Pol pol)
        {
            _context.Add(pol);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // PUT: api/Insurance/credentials
        [HttpPut("credentials")]
        public async Task<IActionResult> PutCredential(Credential credentialData)
        {
            if (credentialData == null || credentialData.UserId == 0)
                return BadRequest();

            var credential = await _context.Credentials.FindAsync(credentialData.UserId);
            if (credential == null)
                return NotFound();

            credential.UserName = credentialData.UserName;
            credential.Password = credentialData.Password;

            await _context.SaveChangesAsync();
            return Ok();
        }

        // PUT: api/Insurance/pol
        [HttpPut("pol")]
        public async Task<IActionResult> PutPol(Pol polData)
        {
            if (polData == null || polData.UserId == 0)
                return BadRequest();

            var pol = await _context.Pol.FindAsync(polData.UserId);
            if (pol == null)
                return NotFound();

            pol.UserName = polData.UserName;
            pol.Polic = polData.Polic;

            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE: api/Insurance/credentials/5
        [HttpDelete("credentials/{UserId}")]
        public async Task<IActionResult> DeleteCredential(int UserId)
        {
            if (UserId < 1)
                return BadRequest();

            var credential = await _context.Credentials.FindAsync(UserId);
            if (credential == null)
                return NotFound();

            _context.Credentials.Remove(credential);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE: api/Insurance/pol/5
        [HttpDelete("pol/{UserId}")]
        public async Task<IActionResult> DeletePol(int UserId)
        {
            if (UserId < 0)
                return BadRequest();

            var pol = await _context.Pol.FindAsync(UserId);
            if (pol == null)
                return NotFound();

            _context.Pol.Remove(pol);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login(Credential model)
        {
            var user = _context.Credentials.FirstOrDefault(u => u.UserName == model.UserName && u.Password == model.Password);

            if (user != null)
            {
                return Ok(new { message = "Login successful" });
            }

            return Unauthorized(new { message = "Login failed. Invalid credentials." });
        }
        // GET: api/Insurance/pol/{username}
        [HttpGet("pol/{username}")]
        public async Task<IActionResult> GetUserDetails(string username)
        {
            var user = await _context.Pol.FirstOrDefaultAsync(u => u.UserName == username);

            if (user != null)
            {
                return Ok(new { UserName = user.UserName, Polic = user.Polic });
            }
            else
            {
                return NotFound(new { message = "User not found" });
            }
        }
        // POST: api/Insurance/cards
        [HttpPost("cards")]
        public async Task<IActionResult> PostCard(Cards card)
        {
            _context.Add(card);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("cards")]
        public async Task<ActionResult<IEnumerable<Cards>>> GetCards()
        {
            return await _context.Cards.ToListAsync();
        }
        // DELETE: api/Cards/{userName}
        [HttpDelete("{userName}")]
        public async Task<ActionResult<Cards>> DeleteCardByUsername(string userName)
        {
            var card = await _context.Cards.FirstOrDefaultAsync(c => c.UserName == userName);
            if (card == null)
            {
                return NotFound();
            }

            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();

            return card;
        }
        // PUT: api/Insurance/cards/username
        [HttpPut("cards/{cardNumber}")]
        public async Task<IActionResult> UpdateCard(int cardNumber, Cards updatedCard)
        {
            var existingCard = await _context.Cards.FirstOrDefaultAsync(c => c.CardNumber == cardNumber);

            if (existingCard == null)
            {
                return NotFound();
            }

            existingCard.UserName = updatedCard.UserName;
            existingCard.CardNumber = updatedCard.CardNumber;
            existingCard.Expiry = updatedCard.Expiry;
            // Add other fields as needed

            await _context.SaveChangesAsync();
            return Ok(existingCard);
        }


    }
}

