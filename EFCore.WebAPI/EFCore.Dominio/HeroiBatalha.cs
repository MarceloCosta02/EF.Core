using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Dominio
{
    public class HeroiBatalha
    {
        public int HeroiId { get; set; }
        public Heroi Heroi { get; set; }

        // Aplica nessa classe o relacionamento n pra n para as 2

        public int BatalhaId { get; set; }
      
        public Batalha Batalha { get; set; }
    }
}
