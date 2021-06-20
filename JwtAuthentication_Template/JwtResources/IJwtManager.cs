namespace JwtAuthentication_Template.JwtResources
{
    /// <summary>
    /// Interface for the Jwt Manager
    /// </summary>
    public interface IJwtManager
    {
        // Implement this as the method to authenticate the user
        string Authenticate(string username, string pwd);
    }
}