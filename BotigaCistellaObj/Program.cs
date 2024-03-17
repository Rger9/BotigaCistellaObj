using System.Security;

namespace BotigaCistellaObj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Producte platan = new Producte("platanoCanarias", 5, 5, 5);
            Producte poma = new Producte("poma", 6, 5, 5);
            Producte pera = new Producte("pera", 4, 1, 5);
            Producte picsa = new Producte("picsa", 3, 5, 5);
            Producte[] fruites = [platan, poma, pera, picsa];
            Botiga fruiteria = new Botiga("frutas manolo", 10);

            char opcio = '0';
            while (opcio != 'q' && opcio != 'Q')
            {
                do
                {
                    Console.Clear();
                    PintarMenu(Menu());
                    opcio = Console.ReadKey().KeyChar;
                }
                while (!ValidarOpcio(opcio, '1', '2'));
                Console.Clear();

                if (opcio == '1')
                {
                    OpcionsAdmin(opcio, fruiteria);
                }
                else if (opcio == '2')
                {
                    OpcionsComprador(opcio);
                }
            }


        }
        // MÈTODES
        /// <summary>
        /// Crida el menú per escollir opcions
        /// </summary>
        /// <returns>Un string amb el menú escrit</returns>
        static string Menu()
        {
            string menu;

            menu =

               $"\n╔══════════════════════════════════╗\n" +
               $"║       Botiga/Cistella            ║\n" +
               $"╠══════════════════════════════════╣\n" +
               $"║  1 - Administrador               ║\n" +
               $"║  2 - Comprador                   ║\n" +
               $"║  q - exit                        ║\n" +
               $"╚══════════════════════════════════╝";

            return menu;
        }
        static string MenuAdministrador()
        {
            string menu;

            menu =

               $"\n╔══════════════════════════════════╗\n" +
               $"║            Botiga                ║\n" +
               $"╠══════════════════════════════════╣\n" +
               $"║  1 - Afegir producte/s           ║\n" +
               $"║  2 - Ampliar botiga              ║\n" +
               $"║  3 - Modificar Preu              ║\n" +
               $"║  4 - Ordenar botiga per preu     ║\n" +
               $"║  5 - Ordenar botiga per nom      ║\n" +
               $"║  6 - Mostrar botiga              ║\n" +
               $"║  q - torna enrere                ║\n" +
               $"╚══════════════════════════════════╝";

            return menu;
        }

        static string MenuComprador()
        {
            string menu;

            menu =

               $"\n╔═════════════════════════════════╗\n" +
               $"║            Cistella              ║\n" +
               $"╠══════════════════════════════════╣\n" +
               $"║  1 - Comprar producte/s          ║\n" +
               $"║  2 - Ordenar cistella            ║\n" +
               $"║  3 - Mostrar cistella            ║\n" +
               $"║  4 - Comprar cistella            ║\n" +
               $"║  q - torna enrere                ║\n" +
               $"╚══════════════════════════════════╝";

            return menu;
        }
        static void PintarMenu(string menu)
        {
            string linea = "", text = menu;
            while (text.Contains("\n"))
            {
                linea = text.Substring(0, text.IndexOf("\n"));
                Centrar(linea);
                text = text.Substring(text.IndexOf("\n") + 1);
            }
            Centrar(text);
        }
        static void PintarMenu(string menu, char i)
        {
            string linea = "", text = menu;
            while (text.Contains("\n"))
            {
                linea = text.Substring(0, text.IndexOf("\n"));
                Centrar(linea, i);
                text = text.Substring(text.IndexOf("\n") + 1);
            }
            Centrar(text);
        }

        // Mètode Centrar
        static void Centrar(string text)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(String.Format("{0," + ((Console.WindowWidth / 2) - (text.Length / 2) - 1) + "}", ""));
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Write(String.Format($"{text}"));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
        }

        static void Centrar(string text, char i)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(String.Format("{0," + ((Console.WindowWidth / 2) - (text.Length / 2) - 1) + "}", ""));
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            if (text.Contains((i)))
            {
                Console.Write(text.Substring(0, text.IndexOf(i)));
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(String.Format($"{text.Substring(3, text.Length - 4)}"));
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write('║');
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.Write(String.Format($"{text}"));
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
        }


        // Mètode Pintar
        static void Pintar(string text)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(String.Format("{0," + (text.Length - 1) + "}", ""));
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Write(String.Format($"{text}"));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
        }

        // Mètode PintarOpcio
        static void PintarOpcio(string menu, char i)
        {
            string menuMat = Menu();
            PintarMenu(Menu(), i);
            Thread.Sleep(1000);
            Console.Clear();
        }
        // Mètode ValidarOpció
        static bool ValidarOpcio(char lletra, char lletraInici, char lletraFinal)
        {
            return (lletra >= lletraInici && lletra <= lletraFinal || lletra == 'q' || lletra == 'Q');
        }
        static void PremPerContinuar()
        {
            Pintar($"\n\n\t-----------------------------------------");
            Console.WriteLine($"\tPrem qualsevol botó per tornar al menú...");
            char continuar = Console.ReadKey().KeyChar;
        }
        static void OpcionsAdmin(char opcio, Botiga botiga)
        {
            PintarOpcio(Menu(), '1');
            while (opcio != 'q' && opcio != 'Q')
            {
                do
                {
                    Console.Clear();
                    PintarMenu(MenuAdministrador());
                    opcio = Console.ReadKey().KeyChar;
                }
                while (!ValidarOpcio(opcio, '1', '6'));
                Console.Clear();
                SeleccionarAdministrador(opcio, botiga);
            }
        }
        static void OpcionsComprador(char opcio)
        {
            PintarOpcio(Menu(), '2');
            while (opcio != 'q' && opcio != 'Q')
            {
                do
                {
                    Console.Clear();
                    PintarMenu(MenuComprador());
                    opcio = Console.ReadKey().KeyChar;
                }
                while (!ValidarOpcio(opcio, '1', '4'));
                Console.Clear();
            }
        }
        static void SeleccionarAdministrador(char opcio, Botiga botiga)
        {
            PintarOpcio(MenuAdministrador(), opcio);
            switch (opcio)
            {
                case '1':
                    // AFEGIR PRODUCTE/S
                    string textProductes, textPreus;
                    string[] productes, preus;
                    // Preguntem pels productes que volem afegir amb els respectius preus.
                    do
                    {
                        Pintar("AFEGIR PRODUCTE/S");
                        Console.WriteLine("Escriu els productes que voldràs afegir (ex: pomes, peres, platans, melons)");
                        textProductes = Console.ReadLine();
                        Console.WriteLine("Escriu els preus respectius dels productes afegits(3.50, 4.20, 5.99, 6, 6.80)");
                        textPreus = Console.ReadLine();
                        productes = textProductes.Split(", ");
                        preus = textPreus.Split(", ");
                        if (productes.Length != preus.Length)
                        {
                            Console.WriteLine("ERROR: Has d'introduïr el mateix nombre de productes que de preus");
                            Thread.Sleep(3000);
                        }
                        Console.Clear();
                    }
                    while (productes.Length != preus.Length);
                    
                    if (productes.Length == 1)
                    {
                        Producte a = new Producte(productes[0], Convert.ToDouble(preus[0]));
                        if (botiga.NElements < botiga.Capacitat)
                        {
                            botiga.AfegirProducte(a);
                        }
                        else
                        {
                            BotigaPlena(botiga);
                        }
                    }
                    else
                    {
                        Producte[] items = new Producte[productes.Length];
                        for (int i = 0; i < productes.Length; i++)
                        {
                            Producte aux = new Producte(productes[i], Convert.ToDouble(preus[i]));
                            items[i] = aux;
                        }
                        if (botiga.NElements + items.Length < botiga.Capacitat)
                        {
                            botiga.AfegirProducte(items);
                        }
                        else
                        {
                            BotigaPlena(botiga);
                        }
                    }
                    break;
                case '2':
                    // AMPLIAR BOTIGA
                    Pintar("AMPLIAR BOTIGA");
                    Console.WriteLine("En quants espais vols ampliar la botiga?");
                    int espais = Convert.ToInt32(Console.ReadLine);
                    if (espais > 0) botiga.AmpliarBotiga(espais);
                    else Console.WriteLine("ERROR: Has d'introduïr un numero més gran que 0");
                    break;
                case '3':
                    // MODIFICAR PREU
                    Pintar("MODIFICAR PREU");
                    Console.WriteLine("Quin producte en voldries modificar el preu?");
                    string producte = Console.ReadLine();
                    Console.WriteLine("Quin en serà el nou preu?");
                    double preu = Convert.ToDouble(Console.ReadLine());
                    if (botiga.ModificarPreu(producte, preu)) Console.WriteLine("Preu del producte canviat exitosament!");
                    else Console.WriteLine("ERROR: No s'ha trobat el producte a modificar");
                    break;
                case '4':
                    // ORDENAR BOTIGA PREU
                    Pintar("BOTIGA ORDENADA PER PREU");
                    botiga.OrdenarPreu();
                    botiga.Mostrar();
                    break;
                case '5':
                    // ORDENAR BOTIGA NOM
                    Pintar("BOTIGA ORDENADA ALFABÈTICAMENT");
                    botiga.OrdenarProducte();
                    botiga.Mostrar();
                    break;
                case '6':
                    // MOSTRAR BOTIGA
                    botiga.Mostrar();
                    break;
                    PremPerContinuar();
            }
        }
        static void BotigaPlena(Botiga botiga)
        {
            char sn = ' ';
            while (sn != 's' && sn != 'n')
            {
                Console.WriteLine("La botiga està plena. Vols ampliar la capacitat de la botiga? (s/n)");
                sn = Convert.ToChar(Console.ReadLine());
                if (sn == 's')
                {
                    Console.WriteLine("Quants espais vols ampliar la botiga?");
                    int espais = Convert.ToInt32(Console.ReadLine());
                    botiga.AmpliarBotiga(espais);
                }
                else if (sn == 'n')
                {
                    Console.WriteLine("Tornant al menu...");
                }
                else
                {
                    Console.WriteLine("ERROR: Introdueix s o n");
                }
            }
            
        }
        static void SeleccionarComprador(char opcio)
        {
            PintarOpcio(MenuComprador(), opcio);
            switch (opcio)
            {
                case '1':
                    // COMPRAR PRODUCTE/S
                    break;
                case '2':
                    // ORDENAR CISTELLA
                    break;
                case '3':
                    // MOSTRAR CISTELLA
                    break;
                case '4':
                    // COMPRAR CISTELLA
                    break;
            }

        }
    }
}
