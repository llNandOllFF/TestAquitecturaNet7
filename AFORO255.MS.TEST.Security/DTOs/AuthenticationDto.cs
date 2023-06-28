namespace AFORO255.MS.TEST.Security.DTOs
{
    public record AuthenticationRequest (string username, string password);
    public record AuthenticationResponse (string token,string exp);
}
