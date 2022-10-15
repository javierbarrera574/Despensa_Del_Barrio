namespace Prueba.Client.Servicios
{
    public interface IHttpService
    {
        Task<HttpRespuesta<T>> Get<T>(string url);
        Task<HttpRespuesta<object>> Post<T>(string url, T enviar);
    }
}


//es para hacer la inyeccion de la clase HttpService dentro de Program

//que responde a las caracteristicas de IHttpService