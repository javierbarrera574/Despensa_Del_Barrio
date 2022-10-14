using System.Text.Json;

namespace Prueba.Client.Servicios
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient http;

        
        public HttpService(HttpClient Http)
        {
            //comunica el backend con el fronted, conectando los controladores de la API
            //con los componentes de razor en el frontend

            this.http = Http;
        }

        public async Task<HttpRespuesta<T>> Get<T>(string url)//direccion url del controlador(lo que llega)
        {

            //esta respuesta es recibida por el componente razor de lista administradores

            var Http_Respuesta = await http.GetAsync(url);


            if (Http_Respuesta.IsSuccessStatusCode)
            {
                var respuesta = await DeserializarRespuesta<T>(Http_Respuesta);

                //si la respuesta , devuelve el codigo correcto, deserializo
                //y obtengo la respuesta desde T en respuesta

                return new HttpRespuesta<T>(respuesta, false, Http_Respuesta);

            }
            else
            {
                return new HttpRespuesta<T>(default, true, Http_Respuesta);//por si hubo error
            }


        }

        private async Task<T> DeserializarRespuesta<T>(HttpResponseMessage Response)
        {
            var respuestaString = await Response.Content.ReadAsStringAsync();

            //Response es la respuesta que vino desde el Get<T> desde servidor
            //si la respuesta , devuelve el codigo correcto, deserializo

            //y a esta respuesta la tengo que serializar

            return JsonSerializer.Deserialize<T>(respuestaString,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                });

        }
    }

}
