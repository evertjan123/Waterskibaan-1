using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Waterskibaan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game _game;
        public MainWindow()
        {
            InitializeComponent();

            _game = new Game()
            {
                BackgroundCanvas = BackgroundCanvas
            };
            _game.Initialize();
            
        }

        static void TestOpdracht2()
        {
            Kabel kabel = new Kabel();

            Lijn lijn1 = new Lijn();
            Lijn lijn2 = new Lijn();
            Lijn lijn3 = new Lijn();
            Lijn lijn4 = new Lijn();
            Lijn lijn5 = new Lijn();
            Lijn lijn6 = new Lijn();

            kabel.NeemLijnInGebruik(lijn1);
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(lijn2);
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(lijn3);
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(lijn4);
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(lijn5);
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(lijn6);
            kabel.VerschuifLijnen();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Opdracht 2:");
            Console.ResetColor();
            Console.WriteLine($"{kabel}\n");
        }
        static void TestOpdracht3()
        {
            Lijn lijn7 = new Lijn();
            Lijn lijn8 = new Lijn();
            Lijn lijn9 = new Lijn();
            Lijn lijn10 = new Lijn();

            LijnenVoorraad lijnenvoorraad = new LijnenVoorraad();

            lijnenvoorraad.LijnToevoegenAanRij(lijn7);
            lijnenvoorraad.LijnToevoegenAanRij(lijn8);
            lijnenvoorraad.VerwijderEersteLijn();
            lijnenvoorraad.LijnToevoegenAanRij(lijn9);
            lijnenvoorraad.LijnToevoegenAanRij(lijn10);
            lijnenvoorraad.VerwijderEersteLijn();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Opdracht 3:");
            Console.ResetColor();
            Console.WriteLine($"{lijnenvoorraad}\n");
        }
        static void TestOpdracht8()
        {
            Sporter sporter1 = new Sporter(MoveCollection.GetWillekeurigeMoves());
            Sporter sporter2 = new Sporter(MoveCollection.GetWillekeurigeMoves())
            {
                Zwemvest = new Zwemvest(),
                Skies = new Skies()
            };
            Waterskibaan waterskibaan = new Waterskibaan();


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Opdracht 8:");
            Console.ResetColor();

            foreach (Sporter s in new Sporter[] { sporter1, sporter2 })
            {
                try
                {
                    waterskibaan.SporterStart(s);
                }
                catch (Exception)
                {
                    Console.WriteLine("Geen Zwemvest of Skies");
                }
            }

            Console.WriteLine("");

        }
        static void TestOpdracht10()
        {
            WachtrijInstructie wachtrijInstructie = new WachtrijInstructie();
            InstructieGroep instructieGroep = new InstructieGroep();
            WachtrijStarten wachtrijStarten = new WachtrijStarten();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Opdracht 10:");
            Console.ResetColor();

            for (int i = 0; i < 100; i++)
            {
                wachtrijInstructie.SporterNeemPlaatsInRij(new Sporter(MoveCollection.GetWillekeurigeMoves()));
            }

            Console.WriteLine($"{wachtrijInstructie.Type}: {wachtrijInstructie.GetAlleSporters().Count}");

            List<Sporter> sporters = wachtrijInstructie.SportersVerlatenRij(5);

            foreach (Sporter sporter in sporters)
            {
                instructieGroep.SporterNeemPlaatsInRij(sporter);
            }

            Console.WriteLine($"{instructieGroep.Type}: {instructieGroep.GetAlleSporters().Count}\n");
        }
        static void TestOpdracht11()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Opdracht 11:");
            Console.ResetColor();

            Game game = new Game();
            game.Initialize();
        }
        static void TestOpdracht12()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Opdracht 12:");
            Console.ResetColor();

            Game game = new Game();
            game.Initialize();
        }

        private void BackgroundCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                double x = e.GetPosition(this).X;
                double y = e.GetPosition(this).Y;
                Console.WriteLine($"new Point({x}, {y}),");
                _game.LakePoints.Add(new Point(x, y));
            }
        }
    }
}
