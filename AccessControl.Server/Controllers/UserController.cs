using AccessControl.Server.Data;
using AccessControl.Server.Extensions;
using AccessControl.Server.Models;
using AccessControl.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace AccessControl.Server.Controllers {
    [ApiController]
    public class UserController : ControllerBase {

        [HttpPost("v1/users")]
        public async Task<IActionResult> Post(
            [FromBody] UserViewModel model,
            [FromServices] AccessControlSystemDataContext context) {

            if (!ModelState.IsValid) {
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));
            }

            var user = new User {
                Name = model.Name,
                DateStartLimit = model.DateStartLimit,
                DateEndLimit = model.DateEndLimit,
                DataLastLog = model.DataLastLog,
                Pin = model.Pin,
                Card = model.Card
            };

            try {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                return StatusCode(201, new ResultViewModel<User>(user));
            }
            catch (DbUpdateException) {
                return StatusCode(400, new ResultViewModel<User>("Não é possivel cadastrar o usuario com esses dados"));
            }
            catch (Exception) {
                return StatusCode(500, new ResultViewModel<User>("Falha interna no servidor"));
            }
        }


        [HttpGet("v1/users")]
        public async Task<IActionResult> Get(
            [FromServices] AccessControlSystemDataContext context) {

            try {
                var users = await context.Users.ToListAsync();

                if (users == null) {
                    return StatusCode(404, new ResultViewModel<string>("Conteudo não encontrado"));
                }

                return StatusCode(200 , new ResultViewModel<List<User>>(users));

            }
            catch (DbUpdateException) {
                return StatusCode(400, new ResultViewModel<User>("Não é possivel listar usuarios"));
            }
            catch (Exception) {
                return StatusCode(500, new ResultViewModel<User>("Falha interna no servidor"));
            }
        }

        [HttpGet("v1/users/{id:long}")]
        public async Task<IActionResult> GetById(
            [FromRoute] long id,
            [FromServices] AccessControlSystemDataContext context) {

            try {
                var user = await context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (user == null) {
                    return StatusCode(404, new ResultViewModel<string>("Conteudo não encontrado"));
                }

                return StatusCode(200, new ResultViewModel<User>(user));

            }
            catch (DbUpdateException) {
                return StatusCode(400, new ResultViewModel<User>($"Não é possivel listar usuario ID: {id}"));
            }
            catch (Exception) {
                return StatusCode(500, new ResultViewModel<User>("Falha interna no servidor"));
            }
        }

        [HttpPut("v1/users/{id:long}")]
        public async Task<IActionResult> Put(
            [FromRoute] long id,
            [FromBody] UserViewModel model,
            [FromServices] AccessControlSystemDataContext context) {

            try {
                var user = await context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (user == null) {
                    return StatusCode(404, new ResultViewModel<string>("Conteudo não encontrado"));
                }

                user.Name = model.Name;
                user.DateStartLimit = model.DateStartLimit;
                user.DateEndLimit = model.DateEndLimit;
                user.DataLastLog = model.DataLastLog;
                user.Pin = model.Pin;
                user.Card = model.Card;

                context.Users.Update(user); 
                await context.SaveChangesAsync();

                return StatusCode(200, new ResultViewModel<User>(user));

            }
            catch (DbUpdateException) {
                return StatusCode(400, new ResultViewModel<User>($"Não é possivel atualizar usuario ID: {id}"));
            }
            catch (Exception) {
                return StatusCode(500, new ResultViewModel<User>("Falha interna no servidor"));
            }
        }

        [HttpDelete("v1/users/{id:long}")]
        public async Task<IActionResult> Delete(
            [FromRoute] long id,
            [FromServices] AccessControlSystemDataContext context) {

            try {
                var user = await context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (user == null) {
                    return StatusCode(404, new ResultViewModel<string>("Conteudo não encontrado"));
                }


                context.Users.Remove(user);
                await context.SaveChangesAsync();

                return StatusCode(200, new ResultViewModel<User>(user));

            }
            catch (DbUpdateException) {
                return StatusCode(400, new ResultViewModel<User>($"Não é possivel Remover usuario ID: {id}"));
            }
            catch (Exception) {
                return StatusCode(500, new ResultViewModel<User>("Falha interna no servidor"));
            }
        }
    }
}
