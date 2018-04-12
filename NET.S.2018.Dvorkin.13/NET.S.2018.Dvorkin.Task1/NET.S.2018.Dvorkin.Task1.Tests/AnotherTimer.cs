using System;

namespace NET.S._2018.Dvorkin.Task1.Tests
{
    public class AnotherTimer
    {
        public AnotherTimer(TimerManager timerManager)
        {
            timerManager.Timer += TimerMsg;
        }

        private void TimerMsg(object sender, TimerEventArgs eventArgs)
        {
            Console.WriteLine($"Message from another timer - {eventArgs.Message}. Info - {eventArgs.Info}");
        }

        public void UnRegister(TimerManager timerManager)
        {
            timerManager.Timer -= TimerMsg;
        }
    }
}