using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotigaCistellaObj
{
    internal class Producte
    {
        //ATRIBUTS
        private string nom;
        private double preu_sense_iva;
        private int iva;
        private int quantitat;

        //CONSTRUCTORS
        Producte()
        {
            nom = "";
            preu_sense_iva = 0.0;
            iva = 21;
            quantitat = 0;
        }
        Producte(string nom, double preu_sense_iva)
        {
            this.nom = nom;
            this.preu_sense_iva= preu_sense_iva;
        }
    }
}
