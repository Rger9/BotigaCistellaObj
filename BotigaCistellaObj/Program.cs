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
        }

    }
}
