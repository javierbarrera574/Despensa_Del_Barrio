namespace Prueba.Client.Servicios
{
    public interface IHttpService
    {
        Task<HttpRespuesta<T>> Get<T>(string url);
    }
}


//es para hacer la inyeccion de la clase HttpService dentro de Program

//que responde a las caracteristicas de IHttpService