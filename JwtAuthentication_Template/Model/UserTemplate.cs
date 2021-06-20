namespace JwtAuthentication_Template.Model
{
    public class UserTemplate
    {
        /// <summary>
        /// This file will create a user template.
        /// The point of all this is that you switch these templates
        /// And apply the code to your own database without having to write
        /// The same code over and over again
        /// </summary>
        
        //User ID
        public int Id { get; set; }
        
        //User Name 
        public string Username { get; set; }
        
        //User Password
        public string Password { get; set; }
    }
}