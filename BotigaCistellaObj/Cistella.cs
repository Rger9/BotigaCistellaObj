using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotigaCistellaObj
{
    internal class Cistella
    {
        //ATRIBUTS
        private Botiga botiga;
        private DateTime data;
        private Producte[] productes;
        private int nElements;
        private double diners;

        //CONTRUCTORS
        /// <summary>
        /// Constructor Per defecte
        /// </summary>
        public Cistella()
        {
            this.botiga = null;
            this.data = DateTime.Now;
            this.productes = new Producte[10];
            this.nElements = 0;
            this.diners = 0;
        }
        /// <summary>
        /// Constructor Complet
        /// </summary>
        /// <param name="botiga">Objecte Botiga</param>
        /// <param name="data">Objecte Datatime de la data</param>
        /// <param name="productes">Taula de productes, comprova que cada producte existeixi a botiga abans de copiarlo</param>
        /// <param name="diners">Double de diners, a cada producte inserit comprova que té suficients diners i els resta a aquest parametre</param>
        public Cistella(Botiga botiga, DateTime data, Producte[] productes, double diners)
        {
            this.botiga = botiga;
            this.data = data;
            this.productes = new Producte[productes.Length];
            this.diners = diners;
            this.nElements = productes.Length;
            this.ComprarProducte(productes);
        }

        //PROPIETATS
        /// <summary>
        /// Get i Set de Botiga
        /// </summary>
        public Botiga Botiga
        {
            get { return botiga; }
            set { botiga = value; }
        }
        /// <summary>
        /// Get i set de Data
        /// </summary>
        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }
        /// <summary>
        /// Get i Set de la taula Productes, només fa el set si el producte existeix a la botiga i te suficients diners per comprar-lo
        /// </summary>
        public Producte[] Productes
        {
            get { return this.productes; }
            set
            {
                this.ComprarProducte(value);
            }
        }
        /// <summary>
        /// Get de nElements
        /// </summary>
        public int NElements
        {
            get { return this.nElements; }
        }
        /// <summary>
        /// Get i set de diners
        /// </summary>
        public double Diners
        {
            get { return this.diners; }
            set { this.diners = value; }
        }

        //METODES PUBLICS
        /// <summary>
        /// Afegeix un producte a la taula de productes si es que existeix a botiga i tens suficients diners
        /// </summary>
        /// <param name="producte">Producte que volem comprar</param>
        public void ComprarProducte(Producte producte)
        {
            if (botiga.BuscarProducte(producte))
            {
                if (nElements == this.productes.Length)
                {
                    Console.WriteLine("La cistella esta plena, quant la vols ampliar?");
                    int num_ampliar;
                    while (!int.TryParse(Console.ReadLine(), out num_ampliar) || num_ampliar < 0)
                    {
                        Console.WriteLine("Num mal escrit! La cistella esta plena, quant la vols ampliar?");
                    }
                    Array.Resize(ref this.productes, nElements + num_ampliar);
                }
                while (diners - botiga[producte.Nom].Preu() * producte.Quantitat < 0.0)
                {
                    Console.WriteLine($"No et queden diners, quants diners vols afegir? (et falten {Math.Round((botiga[producte.Nom].Preu() * producte.Quantitat - diners),2)} euros)");
                    if (Double.TryParse(Console.ReadLine(), out double result) && result > 0.0)
                        this.diners += result;
                }
                productes[nElements] = new Producte(producte);
                productes[nElements].Quantitat = botiga[productes[nElements].Nom].Quantitat;
                nElements++;
                diners -= botiga[producte.Nom].Preu() * producte.Quantitat;
                //nElements++;
                //productes[nElements] = new Producte(producte);
                //productes[nElements].Quantitat = botiga[productes[nElements].Nom].Quantitat;
            }
        }
        /// <summary>
        /// Afegeix una taula de productes al atribut de la taula de productes
        /// </summary>
        /// <param name="productes"></param>
        public void ComprarProducte(Producte[] productes)
        {
            if (productes is not null)
            {
                for (int i = 0; i < productes.Length; i++)
                {
                    ComprarProducte(productes[i]);
                }
            }
        }
        public void OrdenarCistella() //ordena bombolla
        {
            for (int i = 0; i < productes.Length - 1; i++)
            {
                for (int j = 0; j < productes.Length - 1; j++)
                {
                    if (productes[j] > productes[j + 1])
                    {
                        Producte p = new Producte(productes[j]);
                        productes[j] = new Producte(productes[j + 1]);
                        productes[j + 1] = new Producte(p);
                    }
                }
            }
        }
 
        public void Mostra()
        {
            Console.WriteLine(this.ToString());
        }
        public double CostTotal()
        {
            double diners = 0;
            for(int i = 0; i < nElements; i++)
            {
                diners += productes[i].Preu() * productes[i].Quantitat;
            }
            return diners;
        }
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < nElements; i++)
            {
                s += productes[i].ToString() + "\n";
            }
            return s;
        }
        public string ToStringLine()
        {
            string s = "";
            s += this.botiga.NomBotiga + "; " + this.Data.ToString("dd/MM/yyyy") + "; " + this.NElements + "; " + this.diners;
            for(int i = 0; i < nElements; i++)
            {
                if (this.botiga.BuscarProducte(this.productes[i]))
                    s += "; " + this.productes[i].ToStringLine();
            }
            return s;
        }
        public void WriteLineToFile(StreamWriter sw)
        {
            sw.WriteLine(this.ToStringLine());
        }
    }
}
