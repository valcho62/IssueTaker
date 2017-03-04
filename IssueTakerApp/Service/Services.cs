
using IssueTakerApp.Data;

namespace IssueTakerApp.Service
{
    public class Services
    {
        public abstract class Service
        {

            public IssueTakerContex Contex { get; }
            protected Service()
            {
                this.Contex = Data.Data.Contex;
            }
        }
    }
}
