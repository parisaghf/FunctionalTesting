namespace TestProject
{
    public abstract class ApiTestBase
    {
        public LiveCodingServer Server { get; }

        public HttpClient Client { get; }

        public ApiTestBase()
        {
            Server = new LiveCodingServer();
            Client = Server.CreateClient();
        }
    }

    public class LiveCodingServer : WebApplicationFactory<Program>
    {
    }
    
}
    