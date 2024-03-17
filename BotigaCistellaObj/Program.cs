namespace BotigaCistellaObj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Producte platan = new Producte("platanoCanarias", 5, 5, 15);
            Producte poma = new Producte("poma", 6, 5, 15);
            Producte pera = new Producte("pera", 4, 5, 15);
            Producte picsa = new Producte("picsa", 3, 5, 15);

            Producte[] fruites = [platan, poma, pera, picsa];
            Botiga fruiteria = new Botiga("frutas manolo", 10);
            fruiteria.AfegirProducte(fruites);
            fruiteria.EsborrarProducte(poma);
            //fruiteria.ModificarPreu("pera", 10);

            fruiteria.OrdenarPreu();
            fruiteria.Mostrar();

            Console.WriteLine(fruiteria.NElements);
            Console.WriteLine(fruiteria.ToStringLine());
            Botiga fruiteria1 = new Botiga("frutas manolo", 10);
            fruiteria1.AfegirProducte(fruites);
            Producte[] p = new Producte[10];
            p[0] = new Producte(platan);
            p[1] = new Producte(poma);
            p[2] = new Producte(pera);
            p[3] = new Producte(picsa);
            p[0].Quantitat = 5;
            p[1].Quantitat = 5;
            p[2].Quantitat = 5;
            p[3].Quantitat = 5;
            Cistella cistella1 = new Cistella(fruiteria1, DateTime.Now, p, 120.76);
            
            Console.WriteLine(cistella1.ToString());
            Console.WriteLine(cistella1.CostTotal());
            cistella1.Productes[0].Preu_sense_iva = 3;
            cistella1.ComprarProducte(platan);
            cistella1.OrdenarCistella();
            Console.WriteLine(cistella1.CostTotal());
            Console.WriteLine(cistella1.ToString());
            StreamReader sr = new StreamReader(@".\test.txt");
            Cistella aux = new Cistella(sr.ReadToEnd(), out Botiga botiga_out);
            Console.WriteLine(aux.ToString());
            Console.WriteLine("test aux.tostring fet");
            aux.OrdenarCistella();
            Console.WriteLine(aux.ToString());
            sr.Close();
            Thread.Sleep(100000);
            if (File.Exists(@".\test.txt"))
                File.Delete(@".\test.txt");
            StreamWriter swTest = new StreamWriter(new FileStream(@".\test.txt", FileMode.Append));
            swTest.WriteLine(cistella1.ToStringLine());


            swTest.Close();
            //StreamReader sr = new StreamReader(@".\test.txt");
            //Console.WriteLine(sr.ReadToEnd());
            //sr.Close();



            
        }
    }
}
