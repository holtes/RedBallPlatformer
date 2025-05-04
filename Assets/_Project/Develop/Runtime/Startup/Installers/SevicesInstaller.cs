using _Project.Develop.Runtime.Domain.Shared;

namespace _Project.Develop.Runtime.Startup.Installers
{
    public class ServicesInstaller
    {
        public TimeService TimeService;

        public ServicesInstaller()
        {
            TimeService = new TimeService();
        }
    }
}