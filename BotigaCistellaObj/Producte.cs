using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotigaCistellaObj
{
    /// <summary>
    /// Classe Producte representa un producte amb un nom, preu, iva i quantitat
    /// </summary>
    internal class Producte
    {
        //ATRIBUTS
        private string nom;
        private double preu_sense_iva;
        private int iva;
        private int quantitat;

        //CONSTRUCTORS
        /// <summary>
        /// Constructor per defecte, nom a cadena buida, preu_sense_iva i quantitat a 0, iva a 21.
        /// </summary>
        public Producte()
        {
            nom = "";
            preu_sense_iva = 0.0;
            iva = 21;
            quantitat = 0;
        }

        /// <summary>
        /// Constructor amb nom i preu.
        /// </summary>
        /// <param name="nom">String que ha de ser un nom valid.</param>
        /// <param name="preu_sense_iva">Double que ha de ser un preu valid (>0).</param>
        public Producte(string nom, double preu_sense_iva) : this ()
        {
            this.nom = nom;
            this.preu_sense_iva= preu_sense_iva;
        }

        /// <summary>
        /// Contructor complet.
        /// </summary>
        /// <param name="nom">String que ha de ser un nom valid.</param>
        /// <param name="preu_sense_iva">Double que ha de ser un preu valid (no negatiu).</param>
        /// <param name="iva">Int que ha de ser un iva valid (>0 i <21).</param>
        /// <param name="quantitat">Int que ha de ser una quantitat valida (>0).</param>
        public Producte(string nom, double preu_sense_iva, int iva, int quantitat) : this (nom, preu_sense_iva)
        {
            this.iva = iva;
            this.quantitat = quantitat;
        }
        /// <summary>
        /// Constructor copia
        /// </summary>
        /// <param name="p">Producte que no ha de ser null</param>
        public Producte(Producte p) : this ()
        {
            nom = p.nom;
            preu_sense_iva = p.preu_sense_iva;
            iva = p.iva;
            quantitat = p.quantitat;
        }
        /// <summary>
        /// Constructor a partir d'un string amb format csv
        /// </summary>
        /// <param name="liniaFitxer">String que compte tots els atributs d'un Producte separats per "."</param>
        public Producte(string liniaFitxer)
        {
            string[] sub = liniaFitxer.Split(". ");
            nom = sub[0];
            preu_sense_iva = Convert.ToInt32(sub[1]);
            iva = Convert.ToInt32(sub[2]);
            quantitat = Convert.ToInt32(sub[3]);
        }
        //PROPIETATS
        /// <summary>
        /// Get i Set del nom.
        /// </summary>
        public string Nom 
        { 
            get { return nom; } 
            set { nom = value; }
        }
        /// <summary>
        /// Get i Set del preu_sense_iva, ens assegurem que no assignem un valor negatiu.
        /// </summary>
        public double Preu_sense_iva
        {
            get { return preu_sense_iva; }
            set 
            {
                if (value < 0.0)
                    throw new ArgumentException("ERROR EL PREU_SENSE_IVA ASSIGNAT ES MENOR QUE 0.0");
                preu_sense_iva = value; 
            }
        }
        /// <summary>
        /// Get i Set del iva, ens assegurem que no assignem un valor negatiu ni major a 21.
        /// </summary>
        public int Iva
        {
            get { return iva; }
            set 
            {
                if (value < 0 || value > 21)
                    throw new ArgumentException("ERROR EL IVA ASSIGNAT ES MENOR QUE 0 O MAJOR QUE 21");
                iva = value; 
            }
        }
        /// <summary>
        /// Get i Set de la quantitat, ens assegurem que no assignem un valor negatiu.
        /// </summary>
        public int Quantitat
        {
            get { return quantitat; }
            set 
            {
                if (value < 0)
                    throw new ArgumentException("ERROR LA QUANTITAT ASSIGNADA ES MENOR QUE 0");
                quantitat = value; 
            }
        }
        
        //METODES
        /// <summary>
        /// Metode que retorna un double amb el preu amb l'iva inclos.
        /// </summary>
        /// <returns>Double que representa el preu del producte, amb l'iva inclos.</returns>
        public double Preu()
        {
            return Math.Round(preu_sense_iva * (100+iva) / 100, 2);
        }
        /// <summary>
        /// Metode que retorna un string continguent tota la informació del objecte producte.
        /// </summary>
        /// <returns>String que conté tota la informació del objecte.</returns>
        public override string ToString()
        {
            return $"Nom: {this.nom}\tPreu: {this.Preu()}\tQuantitat: {this.quantitat}";
        }
        /// <summary>
        /// Metode que transforma els atribut del Producte actual en un string amb format csv, separat per ". "
        /// </summary>
        /// <returns>String de tots els atributs del Producte separats per ". "</returns>
        public string ToStringLine()
        {
            return $"{nom}. {preu_sense_iva}. {iva}. {quantitat}";
        }
        /// <summary>
        /// operator > amb la propietat Nom
        /// </summary>
        /// <param name="p1">Un producte qualsevol</param>
        /// <param name="p2">Un producte qualsevol</param>
        /// <returns>true si p1.Nom es mes gran que p2.Nom</returns>
        public static bool operator>(Producte p1, Producte p2)
        {
            return p1.nom.CompareTo(p2.Nom) > 0;
        }
        /// <summary>
        /// operator < amb la propietat Nom
        /// </summary>
        /// <param name="p1">Un producte qualsevol</param>
        /// <param name="p2">Un producte qualsevol</param>
        /// <returns>true si p1.Nom es mes petit que p2.Nom</returns>
        public static bool operator <(Producte p1, Producte p2)
        {
            return p1.nom.CompareTo(p2.Nom) < 0;
        }
    }
}
