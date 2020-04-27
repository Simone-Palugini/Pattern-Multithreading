﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryTask
{
    public class Worker
    {
        CancellationTokenSource _cts;
        int _max;
        int _delay;

        //costruttore
        public Worker(int max, int delay, CancellationTokenSource cts)
        {
            this._max = max;
            this._delay = delay;
            this._cts = cts;
        }

        public void Start()
        {
            Task.Factory.StartNew(DoWork);
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
