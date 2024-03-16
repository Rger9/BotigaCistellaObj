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
            fruiteria.AfegirProducte(fruites);
            fruiteria.EsborrarProducte(poma);
            fruiteria.ModificarPreu("pera", 10);
            fruiteria.OrdenarPreu();
            fruiteria.Mostrar();

            Console.WriteLine(fruiteria.NElements);
            Console.WriteLine(fruiteria.ToStringLine());
            Botiga fruiteria1 = new Botiga("frutas manolo", 10);
            fruiteria1.AfegirProducte(fruites);
            File.Delete(@".\botigues.txt");
            string s111 = Console.ReadLine();
            StreamWriter sw = new StreamWriter(new FileStream(@".\botigues.txt", FileMode.Append));
            fruiteria1.WriteLineToFile(sw);
            sw.Close();
        }
    }
}
