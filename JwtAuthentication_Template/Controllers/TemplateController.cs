using JwtAuthentication_Template.JwtResources;
using JwtAuthentication_Template.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthentication_Template.Controllers
{
    /// <summary>
    /// This is a template for a controller that will use JWT.
    /// There will be a template method for each CRUD operation.
    /// There will be a Authenticate method in the end of this file.
    /// CREATED BY : Okqwii
    /// </summary>
    [Authorize]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        //This is the jwt manager.
        private readonly IJwtManager _JwtManager;
    
        
        //Template constructor
        public TemplateController(IJwtManager jwtManager)
        {
            this._JwtManager = jwtManager;
        }
        
        
        /// <summary>
        /// Template for a get endpoint
        /// Feel free to change the return type to adapt to your needs.
        /// </summary>
        /// <returns>ActionResult</returns>
        [HttpGet("/api/get")]
        public ActionResult Get()
        {
            //Do as you must
            return Ok("Ok");
        }
        
        /// <summary>
        /// Template for a post endpoint
        /// Feel free to change the return type to adapt to your needs.
        /// </summary>
        /// <returns>ActionResult</returns>
        [HttpPost("/api/post")]
        public ActionResult Post()
        {
            return Ok("Ok");
        }
        
        /// <summary>
        /// Template for a put endpoint
        /// Feel free to change the return type to adapt to your needs.
        /// </summary>
        /// <returns>ActionResult</returns>
        [HttpPut("/api/put")]
        public ActionResult Put()
        {
            return Ok("Ok");
        }
        
        /// <summary>
        /// Template for a delete endpoint
        /// Feel free to change the return type to adapt to your needs.
        /// </summary>
        /// <returns>ActionResult</returns>
        [HttpDelete("/api/delete")]
        public ActionResult Delete()
        {
            return Ok("Ok");
        }

        /// <summary>
        /// This is the authenticate endpoint
        /// AllowAnonymous makes it possible to authenticate without the token
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("/api/authenticate")]
        public ActionResult Authenticate([FromBody] UserTemplate userTemplate)
        {
           //Tries to get the token
           var token = _JwtManager.Authenticate(userTemplate.Username, userTemplate.Password);

           //If the token is null it means that the credentials are invalid.
           if (token == null)
               return Unauthorized("Invalid credentials");
           
           return Ok(token);
        }
        
    }
}