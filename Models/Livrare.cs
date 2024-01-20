using System;
namespace proiect3.Models
{
	

        public class Livrare
        {
            public int LivrareID { get; set; }
            public int ComandaID { get; set; }
            public DateTime DataLivrare { get; set; }
            public string Stare { get; set; }
            // Alte proprietăți despre livrare
            public Comanda Comanda { get; set; }
        }

   }


