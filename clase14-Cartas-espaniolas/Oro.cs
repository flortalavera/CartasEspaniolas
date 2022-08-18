using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase14_Cartas_espaniolas
{
    public class Oro: Carta
    {
        public Oro()
        {
            Color = "Yellow";
            Palo = "Oro";
        }
        public List<string> CartasOro()
        {
            var listaOro = new List<string>();
            for (int i = 0; i < 12; i++)
            {
                if (i != 7 && i != 8)
                {
                    listaOro.Add($"{i + 1} de {Palo}");
                }
            }
            return listaOro;
        }
    }
}
