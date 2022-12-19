using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BE.U1_W1_D1.Azienda_Edile.Classi
{
    public class Dipendente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cognome { get; set;}

        public string Indirizzo { get; set; }

        public string CF { get; set; }

        public bool Coniugato { get; set; }

        public int Figli { get; set; }

        public string Mansione { get; set; }

        public string TipoStipendio { get; set; }

        public double IdStipendio { get; set; }

        public double StipendioMensile { get; set; }  

        public double ImportoPagamento { get ; set; }

        public DateTime DataPagamento { get; set; }

        public double UltimoStipendio()
        {
            return StipendioMensile - ImportoPagamento;
        }
    }
}