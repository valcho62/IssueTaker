
using IssueTakerApp.Data;
using SimpleHttpServer;
using SimpleMVC;

namespace IssueTakerApp
{
    class StartUp
    {
        static void Main()
        {
            //var contex = new IssueTakerContex();
            //contex.Database.Initialize(true);
            HttpServer server = new HttpServer(80, RouteTable.Routes);
            MvcEngine.Run(server, "IssueTakerApp");
        }
    }
}
