namespace BotigaCistellaObj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Producte platan = new Producte("platanoCanarias", 5, 5, 5);
            Producte poma = new Producte("poma nuhuhn", 5, 5, 5);
            Producte pera = new Producte("pera de dsio", 5, 5, 5);
            Producte picsa = new Producte("picsa con piña", 5, 5, 5);

            Producte[] fruites = [platan, poma, pera, picsa];
            Botiga fruiteria = new Botiga("frutas manolo", 10);
            fruiteria.AfegirProducte(fruites);
            fruiteria.EsborrarProducte(pera);
            fruiteria.Mostrar();
            Console.WriteLine(fruiteria.NElements);
            Console.WriteLine(fruiteria.ToStringLine());
            Botiga fruiteria1 = new Botiga("frutas manolo", 10);
            fruiteria1.AfegirProducte(fruites);
            File.Delete(@".\botigues.txt");
            StreamWriter sw = new StreamWriter(new FileStream(@".\botigues.txt", FileMode.Append));
            fruiteria1.WriteLineToFile(sw);
            sw.Close();
        }
    }
}
