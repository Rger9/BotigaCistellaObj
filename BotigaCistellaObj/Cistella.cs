using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotigaCistellaObj
{
    /// <summary>
    /// Classe Cistella que representa una cistella amb una Botiga, una data, una taula de productes que estan a la cistella de la compra, un int nElements d'aquesta taula i un double de diners encara disponibles
    /// </summary>
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
        public Cistella(Botiga botiga, DateTime data, Producte[] productes, double diners) : this()
        {
            this.botiga = botiga;
            this.data = data;
            this.productes = new Producte[productes.Length];
            this.diners = diners;
            this.ComprarProducte(productes);
        }
        /// <summary>
        /// Constructor a partir un string en format csv
        /// </summary>
        /// <param name="liniaFitxer">String que compte tots els atributs d'una Cistella separats per "; "</param>
        /// <param name="b">Botiga amb clau "out" que permet obtenir la Botiga llegida en el parametre "liniaFitxer" fora del metode</param>
        public Cistella(string liniaFitxer, out Botiga b) : this()
        {
            string[] sub = liniaFitxer.Split("; ");
            b = new Botiga(sub[0]);
            this.botiga = b;
            this.data = Convert.ToDateTime(sub[1]);
            this.nElements = Convert.ToInt32(sub[2]);
            this.diners = Convert.ToDouble(sub[3]);
            this.productes = new Producte[sub.Length - 4];
            Console.WriteLine(this.productes.Length + " this.productes" + sub.Length);
            for (int i = 4; i < sub.Length; i++)
            {
                productes[i-4] = new Producte(sub[i]);
            }
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
            if (botiga.BuscarProducte(producte) && !ExisteixProducte(producte) && botiga[producte.Nom].Quantitat >= producte.Quantitat)
            {
                Console.WriteLine(nElements);
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
                int aux = botiga[producte.Nom].Quantitat - producte.Quantitat;
                //botiga[producte.Nom].Quantitat -= producte.Quantitat;
                productes[nElements] = new Producte(producte);
                productes[nElements].Quantitat = aux;
                diners -= botiga[producte.Nom].Preu() * producte.Quantitat;
                nElements++;
            }
        }
        /// <summary>
        /// Retorna cert o fals si existeix o no un Producte a la taula de productes de la cistella
        /// </summary>
        /// <param name="producte">Producte vàlid</param>
        /// <returns>True si a la taula de productes de la cistella existeix un producte amb el mateix nom que el producte entrat per parametre, fals altrament</returns>
        public bool ExisteixProducte(Producte producte)
        {
            bool existeix = false;
            int i = 0;
            while(!existeix && i < nElements)
            {
                existeix = this.productes[i].Nom == producte.Nom;
                i++;
            }
            return existeix;
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
        /// <summary>
        /// Ordena la taula de prodcutes segons el metode d'ordenacio de la bombolla
        /// </summary>
        public void OrdenarCistella()
        {
            for (int i = 0; i < nElements - 1; i++)
            {
                for (int j = 0; j < nElements - 1; j++)
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
        /// <summary>
        /// Escriu per pantalla el contingut de la cistella
        /// </summary>
        public void Mostra()
        {
            Console.WriteLine(this.ToString());
        }
        /// <summary>
        /// Calcula el cost total de tots els productes a la cistella
        /// </summary>
        /// <returns>Retorna el cost total de tots els productes a la cistella</returns>
        public double CostTotal()
        {
            double diners = 0;
            for(int i = 0; i < nElements; i++)
            {
                diners += productes[i].Preu() * productes[i].Quantitat;
            }
            return diners;
        }
        /// <summary>
        /// Metode de sobreescriptura del metode ToString() que converteix la cistella en format string
        /// </summary>
        /// <returns>El nom de la botiga i de tots els productes de la taula productes de la cistella en format string, com si fossin un ticket de la compra</returns>
        public override string ToString()
        {
            string s = "Comprant a " + botiga.NomBotiga + "\n";
            for (int i = 0; i < nElements; i++)
            {
                s += productes[i].ToString() + "\n";
            }
            return s;
        }
        /// <summary>
        /// Metode que transforma els atribut de la Cistella actual en un string amb format csv, separat per "; "
        /// </summary>
        /// <returns></returns>
        public string ToStringLine()
        {
            string s = "";
            s += this.botiga.ToStringLine() + "; " + this.Data.ToString("dd/MM/yyyy") + "; " + this.NElements + "; " + this.diners;
            for(int i = 0; i < nElements; i++)
            {
                if (this.botiga.BuscarProducte(this.productes[i]))
                    s += "; " + this.productes[i].ToStringLine();
            }
            return s;
        }
        /// <summary>
        /// Metode que escriu el contingut de la cistella en un fitxer d'escriptura en format csv
        /// </summary>
        /// <param name="sw">Fitxer d'escriptura</param>
        public void WriteLineToFile(StreamWriter sw)
        {
            sw.WriteLine(this.ToStringLine());
        }
    }
}
