using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Waterskibaan
{
    class Game
    {
        private static Timer _timer;

        private Waterskibaan _waterskibaan;

        private InstructieGroep _instructieGroep;
        private WachtrijInstructie _wachtrijInstructie;
        private WachtrijStarten _wachtrijStarten;

        public void Initialize()
        {
            _waterskibaan = new Waterskibaan();

            _instructieGroep = new InstructieGroep();
            _wachtrijInstructie = new WachtrijInstructie();
            _wachtrijStarten = new WachtrijStarten();

            SetTimer();
        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            _timer = new Timer(1000);
            // Hook up the Elapsed event for the timer. 
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            _waterskibaan.SporterStart(new Sporter(MoveCollection.GetWillekeurigeMoves()));
            _waterskibaan.VerplaatsKabel();
            Console.WriteLine(_waterskibaan.ToString());
        }
    }
}
