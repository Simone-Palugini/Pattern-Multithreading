using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryTask
{
    public class WorkerAsync
    {
        CancellationTokenSource _cts;
        int _max;
        int _delay;

        //costruttore
        public WorkerAsync(int max, int delay, CancellationTokenSource cts)
        {
            this._max = max;
            this._delay = delay;
            this._cts = cts;
        }

        public async Task Start()
        {
            await Task.Factory.StartNew(DoWork);
        }

        private void DoWork()
        {
            for (int i = 0; i < _max; i++)
            {
                Thread.Sleep(_delay);
                if (_cts.IsCancellationRequested)
                    break;
            }
        }
    }
}
