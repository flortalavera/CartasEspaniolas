using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase14_Cartas_espaniolas
{
    public class Carta
    {
        public int Numero { get; set; }
        public string Palo { get; set; }
        public string Color { get; set; }

        public void CargarMazo(List<string> mazo, List<string> cartasPalo)
        {
            for (int i = 0; i < cartasPalo.Count(); i++)
            {
                mazo.Add(cartasPalo[i]);
            }
        }
        public List<string> Barajar(List<string> mazo, int indiceMezcla)
        {
            var cambiador = new Random();

            for (int i = indiceMezcla; i < mazo.Count(); i++)
            {
                var pri = cambiador.Next(i, mazo.Count());
                string cartaA = mazo[pri];
                mazo[pri] = mazo[mazo.Count() - 1];
                mazo[mazo.Count() - 1] = cartaA;
            }
            return mazo;
        }

        public string SigCarta(List<string> mazo, string cartaActual)
        {
            var cartaSig = "";
            if (cartaActual == "")
            {
                cartaSig = mazo[0];
            }
            else
            {   
                int contador = 0;
                foreach (var item in mazo)
                {
                    if (cartaActual == item)
                    {
                        cartaSig = mazo[contador + 1];

                    }
                    contador++;
                }
            }
            return cartaSig;
        }
        public int CartasDisponibles(List<string> mazo, string cartaActual)
        {
            int cartasDisponibles = 0;
            List<string> disponibles = new List<string>();
            if (cartaActual == "")
            {
                for (int i = 0; i < mazo.Count(); i++) cartasDisponibles++;
            }
            else
            {
                int contador = 0;
                foreach (var item in mazo)
                {
                    if (cartaActual == item)
                    {
                        for (int i = contador; i < mazo.Count() - 1; i++) cartasDisponibles++;
                    }
                    contador++;
                }
            }
            return cartasDisponibles;
        }
        public List<string> DarCartas(List<string> mazo, int CantX, string cartaActual)
        {
            List<string> cartasQueSeDan = new List<string>();
            if (cartaActual == "")
            {
                for (int i = 0; i < CantX; i++)
                {
                    cartasQueSeDan.Add(mazo[i]);
                }
            }
            else
            {   
                int contador = 0;
                foreach (var item in mazo)
                {
                    if (cartaActual == item)
                    {
                        int dar = 0;
                        while (CantX != dar)
                        {
                            dar++;
                            cartasQueSeDan.Add(mazo[contador + dar]);
                        }
                    }
                    contador++;
                }
            }
            return cartasQueSeDan;
        }
        public List<string> MontonCartas(List<string> mazo, string cartaActual)
        {
            List<string> cartasMonton = new List<string>();
            // Se podría hacer con IndexOf
            //int a = mazo.IndexOf(cartaActual)
            int contador = 0;
            foreach (var item in mazo)
            {
                if (cartaActual == item)
                {
                    for (int i = 0; i <= contador; i++)
                    {
                        cartasMonton.Add(mazo[i]);
                    }
                }
                contador++;
            }
            return cartasMonton;    // Devuelve lista con las cartas ya jugadas
        }
        public List<string> MostrarCartas(List<string> mazo, string cartaActual)
        {
            List<string> cartasQuedan = new List<string>();
            if (cartaActual == "")
            {
                foreach (var item in mazo)
                {
                    cartasQuedan.Add(item);
                }
            }
            else
            {   
                int contador = 0;
                foreach (var item in mazo)
                {
                    if (cartaActual == item)
                    {
                        int dar = mazo.Count() - contador - 1;

                        while (dar > 0)
                        {
                            dar--;
                            contador++;
                            cartasQuedan.Add(mazo[contador]);
                        }
                    }
                    contador++;
                }
            }
            return cartasQuedan;
        }
        public string UltimaCarta(List<string> lista)
        {
            string cartaactual = "";
            if (lista.Count() != 0)
            {
                cartaactual = lista[lista.Count() - 1];
            }
            return cartaactual;
        }

    } // fin class
} // fin namespace
