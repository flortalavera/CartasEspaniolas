using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase14_Cartas_espaniolas
{
    public class Basto : Carta
    {
        public Basto()
        {
            Color = "Green";
            Palo = "Basto";
        }
        public List<string> CartasBasto()
        {
            var listaBasto = new List<string>();
            for (int i = 0; i < 12; i++)
            {
                if (i != 7 && i != 8)
                {
                    listaBasto.Add($"{i + 1} de {Palo}");
                }
            }
            return listaBasto;
        }
    }
}
