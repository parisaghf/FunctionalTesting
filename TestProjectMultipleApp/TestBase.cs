using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using Xunit;

namespace TestProjectMultipleApp
{

    public abstract class TestBase
    {
        public LiveCodingServerX ServerX { get; }
        public LiveCodingServerY ServerY { get; }

        public HttpClient ClientX { get; }
        public HttpClient ClientY { get; }

        public TestBase()
        {
            ServerX = new LiveCodingServerX();
            ClientX = ServerX.CreateClient();

            ServerY = new LiveCodingServerY();
            ClientY = ServerY.CreateClient();
        }


    }

    public class LiveCodingServerX : WebApplicationFactory<Program>
    {
    }
    public class LiveCodingServerY : WebApplicationFactory<WebAPI.DN5.Startup>
    {
    }
}
