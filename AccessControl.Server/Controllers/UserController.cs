using AccessControl.Server.Data;
using AccessControl.Server.Models;
using AccessControl.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.Server.Controllers {
    [ApiController]
    public class UserController : ControllerBase {

        [HttpPost("v1/users")]
        public async Task<IActionResult> Post(
            [FromBody] UserViewModel model,
            [FromServices] AccessControlSystemDataContext context) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                var user = new User {
                    Name = model.Name,
                    DateStartLimit = null,
                    DateEndLimit = null,
                    DataLastLog = null,
                    Pin = null,
                    Card = null
                };

                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                return Ok( "User created");
            }
            catch (DbUpdateException) {
                return StatusCode(400, "Não é possivel cadastrar o usuario com esses dados");
            }
            catch (Exception) {
                return StatusCode(500, "Falha interna no servidor");
            }
        }
    }
}
