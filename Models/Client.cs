using System;
namespace proiect3.Models
{
    public class Client
    {
        public int ClientID { get; set; }// ID-ul utilizatorului asociat cu clientul
        public string Nume { get; set; }
        public string Adresa { get; set; }
        // Alte proprietăți despre clienți
        public List<Comanda> Comenzi { get; set; }
        public List <Review> Reviews { get; set; }
    }

}

