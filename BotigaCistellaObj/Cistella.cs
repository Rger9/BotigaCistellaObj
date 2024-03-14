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
        public Cistella(Botiga botiga, DateTime data, Producte[] productes, double diners)
        {
            this.botiga = botiga;
            this.data = data;
            this.productes = new Producte[productes.Length];
            bool no_diners = false;
            int i;
            for (i = 0; i < productes.Length && !no_diners; i++)
            {
                if (botiga.BuscarProducte(productes[i]))
                {
                    if (diners - botiga[productes[i].Nom].Preu() * productes[i].Quantitat > 0.0)
                    {
                        this.productes[i] = new Producte(botiga[productes[i].Nom]);
                        this.productes[i].Quantitat = productes[i].Quantitat;
                        diners -= botiga[productes[i].Nom].Preu() * productes[i].Quantitat;
                    }
                    else no_diners = true;
                }
            }
            this.nElements = i + 1;
            this.diners = diners;
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
            set
            {
                this.productes = new Producte[value.Length];
                bool no_diners = false;
                int i;
                for (i = 0; i < productes.Length && !no_diners; i++)
                {
                    if (botiga.BuscarProducte(value[i]))
                    {
                        if (diners - botiga[value[i].Nom].Preu() * value[i].Quantitat > 0.0)
                        {
                            this.productes[i] = new Producte(botiga[value[i].Nom]);
                            this.productes[i].Quantitat = value[i].Quantitat;
                            diners -= botiga[value[i].Nom].Preu() * value[i].Quantitat;
                        }
                        else no_diners = true;
                    }
                }
                this.nElements = i + 1;
            }
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
                nElements += 1;
                productes[nElements] = new Producte(producte);
                productes[nElements].Quantitat = botiga[productes[nElements].Nom].Quantitat;
            }
        }
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
    }    
}
