using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase14_Cartas_espaniolas
{
    internal class Tools
    {
        public string MenuCartas()
        {
            var lineMenu = new String('─', 30);
            var opcMenu = $"┌{lineMenu}┐\n";
            opcMenu += "│1 - Barajar                   │\n│2 - Mostrar siguiente carta   │\n│3 - Cuántas cartas disponibles│\n│4 - Dar cartas                │\n"
                + "│5 - Mostrar cartas del montón │\n│6 - Mostrar baraja            │\n│7 - Salir                     │\n";
            opcMenu += $"└{lineMenu}┘\n";
            return opcMenu;
        }

        public bool ctrlNumber(string fact)
        {   
            bool inNumber = Int32.TryParse(fact, out _);
            return inNumber;
        } 

        public void PausaContinuar(string aviso, int posX, int posY)
        {
            Console.SetCursorPosition(posX, posY);
            Console.WriteLine($"{aviso} Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
