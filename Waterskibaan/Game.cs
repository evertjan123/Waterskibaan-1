using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Waterskibaan
{
    class Game
    {
        private static Random _random = new Random();

        private Timer _timer;
        private int _counter;

        private Waterskibaan _waterskibaan;

        private InstructieGroep _instructieGroep;
        private WachtrijInstructie _wachtrijInstructie;
        private WachtrijStarten _wachtrijStarten;

        public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs args);
        public event NieuweBezoekerHandler NieuweBezoeker;

        public delegate void InstructieAfgelopenHandler(InstructieAfgelopenArgs args);
        public event InstructieAfgelopenHandler InstructieAfgelopen;

        public delegate void LijnenVerplaatstHandler();
        public event LijnenVerplaatstHandler LijnenVerplaatst;

        public Canvas BackgroundCanvas;
        private Polygon _lake;
        public PointCollection LakePoints { get; } = new PointCollection();

        public void Initialize()
        {
            _waterskibaan = new Waterskibaan();

            _instructieGroep = new InstructieGroep();
            _wachtrijInstructie = new WachtrijInstructie();
            _wachtrijStarten = new WachtrijStarten();

            SetTimer();

            NieuweBezoeker += OnNieuweBezoeker;
            InstructieAfgelopen += OnInstructieAfgelopen;
            LijnenVerplaatst += OnLijnenVerplaatst;

            BackgroundCanvas.Background = Brushes.LightGreen;
            _lake = new Polygon
            {
                Fill = Brushes.LightBlue,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            _lake.Points = LakePoints;
            BackgroundCanvas.Children.Add(_lake);
        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            _timer = new Timer(GetRandomTime());
            // Hook up the Elapsed event for the timer. 
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;

            _counter = 0;
        }
        private int GetRandomTime()
        {
            return _random.Next(500, 1501);
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            _counter++;
            _timer.Interval = GetRandomTime();

            if (_counter % 3 == 0)
            {
                Sporter sporter = new Sporter(MoveCollection.GetWillekeurigeMoves());
                NieuweBezoeker?.Invoke(new NieuweBezoekerArgs(sporter));
            }

            if (_counter % 4 == 0)
            {
                LijnenVerplaatst?.Invoke();
            }

            if (_counter % 20 == 0)
            {
                List<Sporter> sporters = _instructieGroep.SportersVerlatenRij(_wachtrijInstructie.GetAlleSporters().Count);
                InstructieAfgelopen?.Invoke(new InstructieAfgelopenArgs(sporters));
            }
            
        }


        private void OnNieuweBezoeker(NieuweBezoekerArgs e)
        {
            _wachtrijInstructie.SporterNeemPlaatsInRij(e.Sporter);
        }
        private void OnInstructieAfgelopen(InstructieAfgelopenArgs e)
        {
            foreach (Sporter sporter in e.Sporters)
            {
                _wachtrijStarten.SporterNeemPlaatsInRij(sporter);
            }

            List<Sporter> sporters = _wachtrijInstructie.SportersVerlatenRij(Math.Min(_wachtrijInstructie.GetAlleSporters().Count, _instructieGroep.MAX_LENGTE_RIJ));
            foreach (Sporter sporter in sporters)
            {
                _instructieGroep.SporterNeemPlaatsInRij(sporter);
            }
        }
        private void OnLijnenVerplaatst()
        {
            if (_waterskibaan.Kabel.IsStartPositieLeeg())
            {
                List<Sporter> sporters = _wachtrijStarten.SportersVerlatenRij(1);
                if (sporters.Count > 0)
                {
                    Sporter sporter = sporters[0];
                    sporter.Zwemvest = new Zwemvest();
                    sporter.Skies = new Skies();

                    LijnenVerplaatst += sporter.OnLijnenVerplaatst;

                    _waterskibaan.SporterStart(sporter);
                }
            }

            _waterskibaan.VerplaatsKabel();
        }
    }
}
