using System;
namespace proiect3.Models
{
    public class Produs
    {
        public int ProdusID { get; set; }
        public string Nume { get; set; }
        public decimal Pret { get; set; }
        public int Stoc { get; set; }
        public string Descriere { get; set; }
        public int CategorieId { get; set; }
        public int ReviewID { get; set; }
        public List<DetaliuComanda> DetaliiComanda { get; set; }
        public Categorie Categorii { get; set; } = null!;
        public Review Review { get; set; } = null!;
        public List<Comanda> Comenzi { get; set; }
    }


}

