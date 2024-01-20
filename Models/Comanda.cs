using System;
using Microsoft.Extensions.DependencyModel;

namespace proiect3.Models
{
    public class Comanda
    {
        public int ComandaID { get; set; }
        public int ClientID { get; set; } // ID-ul utilizatorului care a plasat comanda
        public DateTime DataPlasare { get; set; }
        public string Status { get; set; }
        // Alte proprietăți despre comenzi
        public List<Produs> Produse { get; set; }
        public List<DetaliuComanda> DetaliiComanda { get; set; }
        public Livrare Livrare { get; set; } // Relație one-to-one cu Livrare
        public Client Client { get; set; }

    }

}

