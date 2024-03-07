using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotigaCistellaObj
{
    /// <summary>
    /// 
    /// </summary>
    internal class Botiga
    {
        // ATRIBUTS
        private string nomBotiga;
        private Producte[] productes;
        private int nElements;

        // CONSTRUCTORS
        /// <summary>
        /// Inicialitza la botiga amb una taula de 10 productes i amb 0 elements.
        /// </summary>
        public Botiga() 
        {
            productes = new Producte[10];
            nElements = 0;
        }
        /// <summary>
        /// Inicialitza la botiga amb el nom donat i una taula amb tants productes com indica "nProductes" i 0 elements.
        /// </summary>
        /// <param name="nom">El nom de la botiga</param>
        /// <param name="nProductes">Capacitat de productes que té la taula "Producte[]" (no la quantitat)</param>
        public Botiga(string nom, int nProductes)
        {
            nomBotiga = nom;
            productes = new Producte[nProductes];
            nElements = 0;
        }
        /// <summary>
        /// Inicialitza la botiga amb el nom donat i una taula de productes, la qual assignarà la seva mida a nElements sense tenir en compte els valors nuls.
        /// </summary>
        /// <param name="nom">El nom de la botiga</param>
        /// <param name="productes">Taula de productes</param>
        public Botiga(string nom, Producte[] productes)
        {
            nomBotiga = nom;
            int j = 0;
            Producte[] productesAux = new Producte[productes.Length];

            for(int i = 0; i < productes.Length; i++)
            {
                if (productes[i] != null)
                {
                    productesAux[j] = productes[i];
                    j++;
                }
            }
            nElements = j + 1;
        }

        // PROPIETATS
        /// <summary>
        /// Retorna el nom de la botiga.
        /// </summary>
        public string NomBotiga
        {
            get { return nomBotiga; }
            set { nomBotiga = value; }
        }
        /// <summary>
        /// Retorna el número de productes que hi ha en la botiga.
        /// </summary>
        public int NElements
        {
            get { return nElements; }
            set { nElements = value; }
        }
        /// <summary>
        /// Retorna la taula de productes.
        /// </summary>
        public Producte[] Productes
        {
            get { return productes; }
            set { productes = value; }
        }

        // METODES
        /// <summary>
        /// Busca l'índex del primer espai lliure que trobi a la botiga.
        /// </summary>
        /// <returns>Un número enter que representa l'índex de l'espai lliure. Si no hi ha cap espai retorna -1.</returns>
        public int EspaiLliure()
        {
            int index = -1;
            for (int i = 0; i < productes.Length || index != -1; index++)
            {
                if (productes[index] == null)
                    index = i;
            }
            return index;
        }

        public Botiga this[int i]
        {
            get { return productes[i];  }
        }


        /// <summary>
        /// Afegeix el producte desitjat al primer espai lliure que trobi a la botiga.
        /// </summary>
        /// <param name="producte">Producte que volem afegir a la botiga.</param>
        /// <returns>True si hi ha un espai lliure i pot afegir el producte, False en cas contrari.</returns>
        public bool AfegirProducte(Producte producte)
        {
            if (EspaiLliure() != -1)
            {
                productes[EspaiLliure()] = producte;
                return true;
            }
            else return false;
        }
        /// <summary>
        /// Afegeix un conjunt de productes a la botiga
        /// </summary>
        /// <param name="productes">Taula de productes que afegirem a la botiga</param>
        /// <returns>True si s'ha pogut afegir tot el conjunt de productes,False en cas contrari.</returns>
        public bool AfegirProducte(Producte[] productes)
        {
            int i = 0;
            for (int j = 0;  j <= this.productes.Length || i < productes.Length; j++)
            {
                if (EspaiLliure() != -1)
                {
                    this.productes[EspaiLliure()] = productes[i];
                    i++;
                }
            }
            return (i == productes.Length);
        }
        /// <summary>
        /// Amplia la Botiga certa quantitat d'espais.
        /// </summary>
        /// <param name="ampliar">La quantitat d'espais que s'afegiran a la botiga.</param>
        public void AmpliarBotiga(int ampliar)
        {
            if (ampliar > 0)
            {
                Producte[] productes = new Producte[this.productes.Length + ampliar];
                for (int i = 0;  i < this.productes.Length; i++)
                {
                    productes[i] = this.productes[i];
                }
                this.productes = productes;
            }
        }

        //public bool ModificarPreus(string producte, double preu) 
        //{
            
        //}
        
    }
}
