namespace BotigaCistellaObj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Producte platan = new Producte("platanocanarias", 3, 6, 5);
            Botiga fruiteria = new Botiga("frutas manolo", 10);
            fruiteria.AfegirProducte(platan);
            fruiteria.Mostrar();


        }
    }
}
