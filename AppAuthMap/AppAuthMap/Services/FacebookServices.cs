using AppAuthMap.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppAuthMap.Services
{
    /**
     * Clase encargada de enviar una petición al API Graph de FB con los campos necesarios
     * y que hayan sido previamente permitidos por el Scope. Agregando el token del usuario. 
     * Para luego guardar los datos devueltos en un modelo y usarlos.
     **/
    public class FacebookServices
    {

        public async Task<FacebookProfile> GetFacebookProfileAsync(string accessToken)
        {
            var requestUrl = $"https://graph.facebook.com/me?fields=name,picture,work,website,religion,location,locale,link,cover,age_range,birthday,devices,email,first_name,last_name,gender,hometown,is_verified,languages&access_token={accessToken}";

            var httpClient = new HttpClient();

            var userJson = await httpClient.GetStringAsync(requestUrl);

            var facebookProfile = JsonConvert.DeserializeObject<FacebookProfile>(userJson);

            return facebookProfile;
        }
    }
}
