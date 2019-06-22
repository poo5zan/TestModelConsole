using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseMicroService
{
    public interface IBaseMicroService
    {
        void Start(HostControl hostControl);
        void Stop();
        void Pause();
        void Continue();
        void Shutdown();
        void Resume();
        void TryRequest(Action action, int maxFailures, int startTimeoutMS = 100,
            int resetTimeout = 10000, Action<Exception> onError = null);
    }
}
