namespace Prueba.Client.Servicios
{
    public class HttpRespuesta<T> //RESPUESTA GENERICA DE MUCHOS ELEMENTOS
    {

        //instancio la clase segun el tipo, y la respuesta(objeto) tiene que ser del mismo tipo
        public T Respuesta { get; }
        public bool Error { get; }
        public HttpResponseMessage HttpResponse { get; }
        public HttpRespuesta(T respuesta, bool error, HttpResponseMessage httpResponse)
        {
            //son propiedades, no campos
            Respuesta = respuesta;
            Error = error;
            HttpResponse = httpResponse;
        }

     
    }
}


//para automatizar respuestas que voy a recibir del servidor, o sea, de la API