using System.Security;

namespace BotigaCistellaObj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Botiga fruiteria = new Botiga("Fruites Manolo", 10);
            Cistella cistella = new Cistella();
            cistella.Botiga = fruiteria;
            // PERSISTÈNCIA DE FITXERS: Si hi ha un fitxer ja creat amb dades de la botiga i cistella, se'l llegeix i guarda les dades
            if (File.Exists(@".\cistella.txt"))
            {
                StreamReader sR = new StreamReader(@".\cistella.txt");
                cistella = new Cistella(sR.ReadLine(), out fruiteria);
                sR.Close();
            }
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
                    OpcionsComprador(opcio, cistella);
                }
            }
            // PERSISTÈNCIA DE FITXERS: Quan sortim del menú amb la 'q', guardem les dades de la botiga i cistella al fitxer
            StreamWriter sW = new StreamWriter(@".\cistella.txt");
            cistella.WriteLineToFile(sW);
            sW.Close();

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
        /// <summary>
        /// Crida al menú de l'administrador
        /// </summary>
        /// <returns>Un string amb el menú escrit</returns>
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
        /// <summary>
        /// Crida al menú del comprador
        /// </summary>
        /// <returns>Un string amb el menú escrit</returns>
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
        /// <summary>
        /// Pinta el menú per dins
        /// </summary>
        /// <param name="menu">Un dels tres menús disponibles</param>
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
        /// <summary>
        /// Pinta el menú per dins i passa el paràmetre i al mètode Centrar
        /// </summary>
        /// <param name="menu">Un dels tres menus disponibles</param>
        /// <param name="i">caràcter amb la opció seleccionada del menu</param>
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

        /// <summary>
        /// Escriu una linia de text del menu centrada.
        /// </summary>
        /// <param name="text">Un string amb una linia de text</param>
        static void Centrar(string text)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(String.Format("{0," + ((Console.WindowWidth / 2) - (text.Length / 2) - 1) + "}", ""));
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Write(String.Format($"{text}"));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
        }
        /// <summary>
        /// Escriu una linia de text del menu centrada. Si es la linia amb la opció seleccionada, l'escriu de color groc.
        /// </summary>
        /// <param name="text">Un strign amb una linia de text</param>
        /// <param name="i">caràcter amb la opcio seleccionada del menú</param>
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
        /// <summary>
        /// Mostra per consola una linia de text amb el fons pintat
        /// </summary>
        /// <param name="text">String que es vol mostrar per pantalla</param>
        static void Pintar(string text)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(String.Format("{0," + (text.Length - 1) + "}", ""));
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Write(String.Format($"{text}"));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
        }
        /// <summary>
        /// Un cop cliques una opcio del menu, aquest mètode canvia la linia de la opció seleccionada de color durant un segon.
        /// </summary>
        /// <param name="menu">Un dels tres menus</param>
        /// <param name="i">caràcter amb la opcio que es vol pintar</param>
        static void PintarOpcio(string menu, char i)
        {
            PintarMenu(menu, i);
            Thread.Sleep(1000);
            Console.Clear();
        }
        /// <summary>
        /// Valida que el caràcter que s'entri sigui una opcio disponible al menu, o sigui 'Q' o 'q'.
        /// </summary>
        /// <param name="opcio">Caràcter amb la opcio seleccionada</param>
        /// <param name="lletraInici">Caràcter amb la opció més petita del menú/param>
        /// <param name="lletraFinal">Caràcter amb la opció més gran del menú</param>
        /// <returns></returns>
        static bool ValidarOpcio(char opcio, char lletraInici, char lletraFinal)
        {
            return (opcio >= lletraInici && opcio <= lletraFinal || opcio == 'q' || opcio == 'Q');
        }
        /// <summary>
        /// Pausa el programa fins que el faci clic a qualsevol botó
        /// </summary>
        static void PremPerContinuar()
        {
            Pintar($"\n\n\t-----------------------------------------");
            Console.WriteLine($"\tPrem qualsevol botó per tornar al menú...");
            char continuar = Console.ReadKey().KeyChar;
        }
        /// <summary>
        /// Crida al menu de l'administrador i permet seleccionar una nova opció
        /// </summary>
        /// <param name="opcio">Caràcter amb la opció a seleccionar</param>
        /// <param name="botiga">L'objecte del tipus Botiga</param>
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
        /// <summary>
        /// Crida al menu del comprador i permet seleccionar una nova opció
        /// </summary>
        /// <param name="opcio">Caràcter amb la opció a seleccionar</param>
        /// <param name="cistella">L'objecte del tipus Cistella</param>
        static void OpcionsComprador(char opcio, Cistella cistella)
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
                SeleccionarComprador(opcio, cistella);
            }
        }
        /// <summary>
        /// Accedeix a qualsevol de les opcions de l'administrador
        /// </summary>
        /// <param name="opcio">Caràcter opció seleccionat</param>
        /// <param name="botiga">Objecte del tipus Botiga</param>
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
                        if (botiga.NElements < botiga.Productes.Length)
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
                            items[i] = new Producte(productes[i], Convert.ToDouble(preus[i]));
                            items[i].Quantitat = 1;
                        }
                        if (botiga.NElements + items.Length < botiga.Productes.Length)
                        {
                            botiga.AfegirProducte(items);
                        }
                        else
                        {
                            BotigaPlena(botiga);
                            botiga.AfegirProducte(items);
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
                    
            }
            PremPerContinuar();
        }
        /// <summary>
        /// Quan la botiga està plena, pregunta si la vols ampliar
        /// </summary>
        /// <param name="botiga">Objecte del tipus botiga</param>
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
        /// <summary>
        /// Accecdeix a qualsevol de les opcions del comprador
        /// </summary>
        /// <param name="opcio">caràcter opcio seleccionat</param>
        /// <param name="cistella">Objecte del tipus Cistella</param>
        static void SeleccionarComprador(char opcio, Cistella cistella)
        {
            PintarOpcio(MenuComprador(), opcio);
            switch (opcio)
            {
                case '1':
                    // COMPRAR PRODUCTE/S
                    Producte[] items = new Producte[20];
                    string nomProducte="";
                    int i = 0;
                    Pintar("COMPRAR PRODUCTE/S");
                    Console.WriteLine("Quins productes vols comprar? (escriu '..' per deixar de comprar productes)");
                    while (nomProducte != "..")
                    {
                        nomProducte = Console.ReadLine();
                        if (!cistella.Botiga.BuscarProducte(nomProducte) && nomProducte != "..")
                        {
                            Console.WriteLine("ERROR: Has escrit malament el nom del producte. Torna-ho a intentar.");
                        }
                        else if (cistella.Botiga.BuscarProducte(nomProducte))
                        {
                            items[i] = cistella.Botiga[nomProducte];
                            i++;
                            Console.WriteLine($"{nomProducte} afegit a la cistella!");
                        }
                    }
                    cistella.ComprarProducte(items);
                    break;
                case '2':
                    // ORDENAR CISTELLA
                    Pintar("ORDENAR CISTELLA");
                    cistella.OrdenarCistella();
                    cistella.Mostra();
                    break;
                case '3':
                    // MOSTRAR CISTELLA
                    cistella.Mostra();
                    break;
                case '4':
                    // COMPRAR CISTELLA
                    Console.WriteLine("Compra finalitzada! S'ha buidat la cistella");
                    cistella.ComprarCistella();
                    break;
            }
            PremPerContinuar();

        }
    }
}
