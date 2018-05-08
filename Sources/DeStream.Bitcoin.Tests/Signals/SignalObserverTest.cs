﻿using System;
using Microsoft.Extensions.Logging;
using NBitcoin;
using DeStream.Bitcoin.Signals;
using DeStream.Bitcoin.Tests.Logging;

namespace DeStream.Bitcoin.Tests.Signals
{
    public class SignalObserverTest : LogsTestBase
    {
        private SignalObserver<Block> observer;

        public SignalObserverTest()
        {
            this.observer = new TestBlockSignalObserver();
        }

        // the log was removed from the observer
        //[Fact]
        public void SignalObserverLogsSignalOnError()
        {
            var exception = new InvalidOperationException("This should not have occurred!");

            this.observer.OnError(exception);

            this.AssertLog(this.FullNodeLogger, LogLevel.Error, exception.ToString());
        }

        private class TestBlockSignalObserver : SignalObserver<Block>
        {
            public TestBlockSignalObserver()
            {
            }

            protected override void OnNextCore(Block value)
            {
            }
        }
    }
}