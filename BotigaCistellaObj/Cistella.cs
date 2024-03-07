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
        private int[] quantitat;
        private int nElements;
        private double diners;
        
        //CONTRUCTORS
        Cistella()
        {
            this.botiga = null;
            this.data = DateTime.Now;
            this.productes = new Producte[10];
            this.quantitat = new int[10];
            this.nElements = 0;
            this.diners = 0;
        }
        Cistella(Botiga botiga, DateTime data, Producte[] productes, int[] quantitat, double diners)
        {
            if (productes.Length == quantitat.Length)
            {
                this.botiga = botiga;
                this.data = data;
                this.productes = new Producte[productes.Length];
                this.quantitat = new int[quantitat.Length];
                this.nElements = productes.Length;
                this.diners = diners;
            }
            else throw new ArgumentException("ERROR LA LENGTH DE LA TAULA DE PRODUCTES I QUANTITAT ES DIFERENT");
            
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
        public int[] Quantitat
        {
            get { return this.quantitat; }
            set { this.quantitat = value; }
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
    }
}
