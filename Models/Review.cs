using System;
namespace proiect3.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int ClientID { get; set; } // ID-ul utilizatorului care a scris recenzia
        public string Comentariu { get; set; }
        public int Rating { get; set; } // Scorul dat produsului
        public DateTime DataReview { get; set; }
        public List <Produs> Produse { get; set; }
        public Client Client { get; set; }

    }
}
