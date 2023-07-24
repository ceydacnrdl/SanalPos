using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamProject.Models
{
    public class SanalPosModel
    {
        public string ClientId { get; set; }
        public string Oid { get; set; }
        public string Amount { get; set; }
        public string OkUrl { get; set; }
        public string FailUrl { get; set; }
        public string Islemtipi { get; set; }
        public string Taksit { get; set; }
        public string Rnd { get; set; }
        public string Hash { get; set; }
    }
}
