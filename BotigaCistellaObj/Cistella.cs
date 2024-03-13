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
        public Cistella()
        {
            this.botiga = null;
            this.data = DateTime.Now;
            this.productes = new Producte[10];
            this.nElements = 0;
            this.diners = 0;
        }
        public Cistella(Botiga botiga, DateTime data, Producte[] productes, int[] quantitat, double diners)
        {
            if(productes.Length == quantitat.Length)
            {
                this.botiga = botiga;
                this.data = data;
                this.productes = new Producte[productes.Length];
                bool no_diners = false;
                int i;
                for (i = 0; i < productes.Length && !no_diners; i++)
                {
                    if (productes[i] != null)
                    {
                        if (botiga[productes[i].Nom] != null)
                        {
                            if (diners - botiga[productes[i].Nom].Preu() * quantitat[i] > 0.0)
                            {
                                diners -= botiga[productes[i].Nom].Preu() * quantitat[i];
                            }
                            else no_diners = true;
                        }
                    }
                }
                this.nElements = i + 1;
                this.diners = diners;
            }
            
        }
        //PROPIETATS
        public Botiga Botiga
        {
            get { return botiga; }
            set { botiga = value; } 
        }
        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }
        public Producte[] Productes
        {
            get { return this.productes; }
            set { this.productes = value; }
        }
        public int NElements
        {
            get { return this.nElements; }
        }
        public double Diners
        {
            get { return this.diners; }
            set { this.diners = value; }
        }
        
        //METODES PUBLICS
        public void ComprarProducte(Producte producte)
        {
            if(botiga.BuscarProducte(producte))
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
                nElements += 1;
                productes[nElements] = new Producte(producte);
            }
        }
        public void ComprarProducte(Producte[] productes)
        {
            if (nElements == this.productes.Length)
            {
                Array.Resize(ref this.productes, nElements + 10);
            }
            nElements += 1;
            productes[nElements] = producte;
        }
    }
}
