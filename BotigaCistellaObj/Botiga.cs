using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BotigaCistellaObj
{
    /// <summary>
    /// Classe Botiga que representa una botiga amb un nom, una taula de Productes i un int nElements d'aquesta taula
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
        /// <summary>
        /// Inicialitza la botiga a partir d'un string en format csv
        /// </summary>
        /// <param name="liniaFitxer">String que conte tots els atributs que componen una Botiga, en format csv separat per "/ "</param>
        public Botiga(string liniaFitxer)
        {
            string[] subs = liniaFitxer.Split("/ ");
            nomBotiga = subs[0];
            nElements = Convert.ToInt32(subs[1]);
            Producte[] productes = new Producte[subs.Length - 2];
            for(int i = 2; i < subs.Length; i++)
            {
                productes[i-2] = new Producte(subs[i]);
            }
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
        public int Capacitat
        {
            get { return productes.Length; }
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
            for (int i = 0; i < productes.Length && index == -1; i++)
            {
                if (productes[i] == null)
                {
                    index = i;
                }
            }
            return index;
        }
        /// <summary>
        /// Indexador que retorna l'índex d'un producte el qual coincideix amb el nom paràmetre.
        /// </summary>
        /// <param name="nom">Nom del producte a buscar.</param>
        /// <returns>Retorna el producte si el troba, si no el troba retorna null.</returns>
        public Producte this[string nom]
        {
            get
            {
                int i = 0, index = -1;
                while(i < productes.Length && index == -1)
                {

                    if (productes[i] != null && productes[i].Nom == nom)
                    {
                        index = i;
                    }
                    i++;
                }
                if (index == -1) return null;
                else return productes[index];
            }
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
                nElements++;
                return true;
            }
            else return false;
        }
        /// <summary>
        /// Afegeix un conjunt de productes a la botiga
        /// </summary>
        /// <param name="items">Taula de productes que afegirem a la botiga</param>
        /// <returns>True si s'ha pogut afegir tot el conjunt de productes,False en cas contrari.</returns>
        public bool AfegirProducte(Producte[] items)
        {
            int i = 0;
            for (int j = 0;  j <= productes.Length && i < items.Length; j++)
            {
                if (EspaiLliure() != -1)
                {
                    productes[EspaiLliure()] = items[i];
                    nElements++;
                    i++;
                }
            }
            return (i == items.Length);
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
        /// <summary>
        /// Busca un producte i en modifica el preu.
        /// </summary>
        /// <param name="producte">Producte a buscar.</param>
        /// <param name="cost">Nou cost del producte.</param>
        /// <returns>True si ha trobat el producte, el preu és vàlid i l'ha pogut modificar </returns>
        public bool ModificarPreu(string producte, double cost)
        {
            if (!BuscarProducte(producte))
            {
                return false;
            }
            else
            {
                this[producte].Preu_sense_iva = cost;
                return (cost > 0);
            }
        }
        /// <summary>
        /// Busca un producte
        /// </summary>
        /// <param name="producte">Producte a buscar</param>
        /// <returns>True si ha trobat el producte</returns>
        public bool BuscarProducte(Producte producte)
        {
            if (producte is null || producte.Nom is null)
            {
                return false;
            }
            return (this[producte.Nom] != null);
        }
        /// <summary>
        /// Busca un producte
        /// </summary>
        /// <param name="producte">Nom del producte a buscar</param>
        /// <returns>True si ha trobat el producte</returns>
        public bool BuscarProducte(string producte)
        {

            if(producte is null)
            {
                return false;
            }
            return (this[producte] != null);
        }
        /// <summary>
        /// Col·loca tots els Productes a l'esquerra de l'array, i els valors 'null' a la dreta
        /// </summary>
        /// <param name="productes">Array de productes</param>
        public void NullDreta()
        {
            int j = 0;
            Producte[] aux = new Producte[productes.Length];
            for (int i = 0; i < productes.Length; i++)
            {
                if (productes[i] != null)
                {
                    aux[j] = productes[i];
                    j++;
                }
            }
            productes = aux;
        }
        /// <summary>
        /// Ordena els productes de la botiga Alfabèticament.
        /// </summary>
        public void OrdenarProducte()
        {
            NullDreta();
            QuicksortProducte(productes, 0, NElements - 1);
        }
        /// <summary>
        /// Ordena els productes de la botiga de menys a més preu.
        /// </summary>
        public void OrdenarPreu()
        {
            NullDreta();
            QuicksortPreu(productes, 0, NElements - 1);
        }
        /// <summary>
        /// Ordena els Productes alfabèticament mitjançant el mètode QuickSort.
        /// </summary>
        /// <param name="productes">Array de productes.</param>
        /// <param name="leftIndex">Primera posició de l'array de productes (més a l'esquerra, el 0).</param>
        /// <param name="rightIndex">Última posició de l'array de productes (més a la dreta, la llargada de l'array menys 1).</param>
        /// <returns>Array de productes</returns>
        private Producte[] QuicksortProducte(Producte[] productes, int leftIndex, int rightIndex)
        {
            int i = leftIndex;
            int j = rightIndex;
            Producte pivot = productes[leftIndex];
            while (i <= j)
            {
                while (productes[i].Nom.CompareTo(pivot.Nom) == -1)
                {
                    i++;
                }

                while (productes[j].Nom.CompareTo(pivot.Nom) == 1)
                {
                    j--;
                }
                if (i <= j)
                {
                    Permutar(ref productes[i], ref productes[j]);
                    i++;
                    j--;
                }
            }
            if (leftIndex < j)
                QuicksortProducte(productes, leftIndex, j);
            if (i < rightIndex)
                QuicksortProducte(productes, i, rightIndex);
            return productes;
        }
        /// <summary>
        /// Ordena els Productes de menys a més spreu mitjançant el mètode QuickSort
        /// </summary>
        /// <param name="productes">Array de productes.</param>
        /// <param name="leftIndex">Primera posició de l'array de productes (més a l'esquerra, el 0).</param>
        /// <param name="rightIndex">Última posició de l'array de productes (més a la dreta, la llargada de l'array menys 1).</param>
        /// <returns>Array de Productes</returns>
        private Producte[] QuicksortPreu(Producte[] productes, int leftIndex, int rightIndex)
        {
            int i = leftIndex;
            int j = rightIndex;
            double pivot = productes[leftIndex].Preu();
            while (i <= j)
            {
                while (productes[i].Preu() < pivot)
                {
                    i++;
                }

                while (productes[j].Preu() > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    Permutar(ref productes[i], ref productes[j]);
                    i++;
                    j--;
                }
            }
            if (leftIndex < j)
                QuicksortProducte(productes, leftIndex, j);
            if (i < rightIndex)
                QuicksortProducte(productes, i, rightIndex);
            return productes;
        }
        /// <summary>
        /// Esborra un producte de la Botiga
        /// </summary>
        /// <param name="producte">Producte a borrar</param>
        /// <returns>True si s'ha borrat correctament</returns>
        public bool EsborrarProducte(Producte producte)
        {

            if (BuscarProducte(producte) == true)
            {
                for (int i = 0; i < nElements; i++)
                {
                    if (productes[i] != null && productes[i].Nom == producte.Nom)
                    {
                        productes[i] = null;
                        nElements--;
                    }
                }
                this.NullDreta();
                return true;
            }
            else return false;
        }
        /// <summary>
        /// Mostra per pantalla la botiga i els productes d'aquesta amb els seus respectius noms, preus i quantitats.
        /// </summary>
        public void Mostrar()
        {
            Console.WriteLine(this.ToString());
        }
        /// <summary>
        /// Transforma els productes de la botiga en un string, amb els seus respectius noms, preis i quantitats.
        /// </summary>
        /// <returns>String amb els valors dels productes.</returns>
        public override string ToString()
        {
            string text = "";
            text += $"- {NomBotiga.ToUpper()} -\n";
            for (int i = 0; i < productes.Length; i++)
            {
                if (productes[i] != null)
                    text +=
                        $"{(productes[i].Nom + " ").PadRight(25, '-')} {(productes[i].Preu().ToString() + " Euros ").PadRight(10, '-')} Quantitat: {productes[i].Quantitat}\n";
                else
                    text += "".PadRight(30, '-') + "\n";
            }
            return text;
        }
        /// <summary>
        /// Metode que transforma els atribut de la Botiga actual en un string amb format csv, separat per "/ "
        /// </summary>
        /// <returns>String de tots els atributs de la Botiga separats per "/ "</returns>
        public string ToStringLine()
        {
            string s = "";
            s += $"{NomBotiga}/ {nElements}";
            for (int i = 0; i< nElements ; i++)
            {
                s += $"/ {productes[i].ToStringLine()}";
            }
            return s;
        }
        /// <summary>
        /// Intercanvia dos Productes
        /// </summary>
        /// <param name="a">Producte vàlid</param>
        /// <param name="b">Producte vàlid</param>
        public void Permutar(ref Producte a, ref Producte b)
        {
            (a, b) = (b, a);

        }
    }
}
