namespace Prueba.Client.Servicios
{
    public class HttpRespuesta<T> //RESPUESTA GENERICA DE MUCHOS ELEMENTOS
    {

        //instancio la clase segun el tipo, y la respuesta(objeto) tiene que ser del mismo tipo
        public T Respuesta { get; }
        public bool Error { get; }
        public HttpResponseMessage HttpResponseMessage { get; }
        public HttpRespuesta(T respuesta, bool error, HttpResponseMessage httpResponseMessage)
        {
            //son propiedades, no campos
            Respuesta = respuesta;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }

     
    }
}


//para automatizar respuestas que voy a recibir del servidor, o sea, de la API