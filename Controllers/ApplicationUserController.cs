using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ProcessusFormation.Data;
using ProcessusFormation.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ProcessusFormation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private SignInManager<ApplicationUser> _singInManager;
        private readonly ApplicationDbContext _context;
        private readonly ApplicationSettings _appSettings;
        //RoleManager<ApplicationUser> roleManager, 
        //creation d'un constructeur
        public ApplicationUserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context, IOptions<ApplicationSettings> appSettings)
        {
            _userManager = userManager;
            _singInManager = signInManager;
            _context = context;
            _appSettings = appSettings.Value;
            _roleManager = roleManager;
        }



        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Models", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
        //register user

        [HttpPost]
        [Route("Register")]
        public async Task<Object> PostApplicationUser(ApplicationUserModel model)
        {

            var applicationUser = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
                Valide = model.Valide,
                ImagePath = "",

            };
            try
            {
                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        // get allusers pour waiting registration
        [HttpGet]
        [Route("AllUsers")]
        public IEnumerable<Object> GetUserFalse()
        {

            var user = _userManager.Users;
            foreach (ApplicationUser element in user)
            {
                if (element.Valide == "false")
                {
                    yield return (element);

                };
            }
        }
        // get allusers pour waiting registration
        [HttpGet]
        [Route("All")]
        public IEnumerable<ApplicationUser> GetUser()
        {

            return _userManager.Users.ToList();
            //foreach (ApplicationUser element in user)
            //{
            //    if (element.Valide == "false")
            //    {
            //        yield return (element);

            //    };
            //}
        }

        [HttpGet]
        [Route("AllUsersTrue")]
        public IEnumerable<Object> GetUserTrue()
        {

            var user = _userManager.Users;
            foreach (var element in user)
            {
                if (element.Valide == "true")
                {
                    yield return (element);

                };
            }
        }
        //get user detail
        [HttpGet("{id}")]
        public async Task<object> GetUser([FromRoute] string id)
        {

            ApplicationUser applicationUser = await _userManager.FindByIdAsync(id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return (applicationUser);
        }

        //login user
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {

                var role = await _userManager.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
                return BadRequest(new { message = "Email or password is incorrect." });
        }

        //delete user
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApplicationUser>> DeleteUserDetail(string id)
        {
            var userDetail = await _context.ApplicationUsers.FindAsync(id);
            if (userDetail == null)
            {
                return NotFound();
            }

            _context.ApplicationUsers.Remove(userDetail);
            await _context.SaveChangesAsync();

            return userDetail;
        }

        //effacer un role
        [HttpDelete("role/{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ModelState.AddModelError("Error", "Role not found");
                return BadRequest(ModelState);
            }

            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
                return Ok(new { });

            foreach (var error in result.Errors)
                ModelState.AddModelError("Error", error.Description);

            return BadRequest(ModelState);
        }

        //?RoleName="dzdzdz"

        //ajouter un role a un utulisateur 
        [HttpPost]
        [Route("EditRoleUser/{id}")]
        public async Task<ActionResult> CreateRoleAsync(string id, string RoleName)
        {
            var applicationUser = await _userManager.FindByIdAsync(id);

            var result = await _userManager.AddToRoleAsync(applicationUser, RoleName);

            //var result = await _userManager.AddToNormalizedRoleName(applicationUser, RoleName);
           // var result = await _userManager.UpdateSecurityStampAsync(id);
            //   normalizedRoleName
            return Ok(result);

        }
        //  public string role = "admin";
        [HttpPost]
        [Route("EditRoleToUser/{id}")]
        public async Task<ActionResult> AttributRole(string id, ApplicationRole role)
        {
            // string role = "admin";
            var app = await _userManager.FindByIdAsync(id);
            app.Valide = "true";
            var approle = await _userManager.AddToRoleAsync(app, role.RoleName);
            //var rol= await _userManager.GetUsersInRoleAsync(role.RoleName); 
            //var userRoles = await _userManager.GetRolesAsync(user); efficace
            return Ok(approle);
        }

        //ajouter un nouveau  role
        [HttpPost]
        [Route("AddRole")]
        public async Task<ActionResult> CreateAsync(IdentityRole model)
        {
            var result = await _roleManager.CreateAsync(model);
            return Ok(result);

        }


        //get tout les roles
        [HttpGet]
        [Route("GetRole")]
        public IEnumerable<Object> GetAllRoles()
        {
            var roles = _roleManager.Roles;
            return (roles);
        }


        //get un role qui correspond a l'utilisateur x
        [HttpGet]
        [Route("GetRole/{id}")]
        public async Task<object> GetRole(string id)
        {

            var user = await _userManager.FindByIdAsync(id);
            var userRoles = await _userManager.GetRolesAsync(user);
            // var roles = _roleManager.Roles;
            return (userRoles);
        }


        //delete un role attribuer a l'utilisateur x
        [HttpDelete]
        [Route("DeleteRole/{id}")]
        public async Task<object> RemoveRole(string id, ApplicationRole model)
        {

            var user = await _userManager.FindByIdAsync(id);
            //   var userRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRoleAsync(user, model.RoleName);
            // var roles = _roleManager.Roles;
            return Ok(new { message = "delted succefully" });
        }



        // PUT: api/ApplicationUser/Update
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateUsers(ApplicationUserModel model)
        {

            var user = await _userManager.FindByIdAsync(model.Id.ToString());
            var userRoles = await _userManager.GetRolesAsync(user);
            user.UserName = model.UserName;
            user.FullName = model.FullName;
            user.Email = model.Email;
            user.Valide = "true";
            var result = await _userManager.UpdateAsync(user);
            return Ok(result);
        }

    }
}

