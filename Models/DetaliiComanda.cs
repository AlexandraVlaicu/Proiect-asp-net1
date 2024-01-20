using System;
namespace proiect3.Models
{
    public class DetaliuComanda

    {   public int DetaliuComandaID { get; set; }
        public int ComandaID { get; set; }
        public int ProdusID { get; set; }
        public int Cantitate { get; set; }
        public decimal PretUnitar { get; set; }
        // Alte proprietăți despre detalii comandă
        public Comanda Comanda { get; set; } = null!;
        public Produs Produs { get; set; } = null!;
    }

}

