using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Yorum
    {
        public int ID { get; set; }
        public int MakaleID { get; set; }
        public int UyeID { get; set; }
        public string Icerik { get; set; }
        public DateTime EklemeTarih { get; set; }
        public bool Durum { get; set; }



    }
}
