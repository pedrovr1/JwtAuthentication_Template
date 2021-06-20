using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using JwtAuthentication_Template.Model;
using Microsoft.IdentityModel.Tokens;

namespace JwtAuthentication_Template.JwtResources
{
    public class JwtManager : IJwtManager
    {
        //Will hold the secret key for encryption.
        private readonly string secretKey;
        
        /// <summary>
        /// Constructor which will receive the secret key
        /// </summary>
        /// <param name="secretKey">The secret key to encryption purposes</param>
        
        public JwtManager(string secretKey)
        {
            this.secretKey = secretKey;
        }

        /// <summary>
        /// This is all dummy data.
        /// You should reimplement this with your own data storage,
        /// so that it becomes adequate to your own application.
        /// </summary>
  
        private readonly List<UserTemplate> DummyUsers = new List<UserTemplate>
        {
            new UserTemplate()
            {
                Id = 1,
                Username = "User1",
                Password = "User1"
            }
        };
        
        /// <summary>
        /// Before you use this you should make sure you encrypt your own passwords.
        /// This is just a template nothing more.
        /// This method is responsible for creating the JWT Token
        /// </summary>
        /// <param name="username">The username that is trying to login</param>
        /// <param name="pwd">The password of that user</param>
        /// <returns>Token</returns>
        public string Authenticate(string username, string pwd)
        {
            //Checks if there is any user with the provided credentials
            if (!DummyUsers.Any(x => x.Username == username && x.Password == pwd))
                return null;

            //Gets the user data
            var loadedUser = DummyUsers
                .FirstOrDefault(x => x.Username == username && x.Password == pwd);
            
            //Handler of the token that validates and creates the token
            var tokenHandling = new JwtSecurityTokenHandler();
            
            //Gets the secret key
            var encryptionKey = Encoding.ASCII.GetBytes(secretKey);
            
            //Contains data that is necessary in the creation of a token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //Payload of the JWT
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.SerialNumber, loadedUser.Id.ToString()),
                    new Claim(ClaimTypes.Name, loadedUser.Username)
                }),
                
                //Expiration date (adjust as you need) of the JWT
                Expires = DateTime.UtcNow.AddHours(3),
                
                //Encryption signature of the JWT
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(encryptionKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandling.WriteToken(tokenHandling.CreateToken(tokenDescriptor));
        }
    }
}