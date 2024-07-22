namespace Jwt.Api.Security
{
    public class Token
    {
        public string AccesToken { get; set; }
        public DateTime Expration { get; set; }
        public string refreshtoken { get; internal set; }
    }
}
