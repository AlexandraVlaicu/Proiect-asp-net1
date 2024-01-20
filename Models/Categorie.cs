using System;
namespace proiect3.Models
{
    public class Categorie
    {
        public int CategorieID { get; set; }
        public string Nume { get; set; }
        public List<Produs> Produse { get; set; }

    }


}

