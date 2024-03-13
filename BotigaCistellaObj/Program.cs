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

        }
    }
}
