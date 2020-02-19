
namespace AppAuthMap
{
    public class Configuration
    {
        //El id del Centro de desarrollador de FB
        public const string ClientId = "1156307137878733";
        //Los permisos que el usuario concederá, en esta pagina se encuentran https://developers.facebook.com/docs/facebook-login/permissions
        public const string Scope = "email";
        //El url que se ingresa en el centro de Desarrollador para manejar la respuesta
        public const string UrlRedirect = "https://www.facebook.com/connect/login_success.html";
    }
}
