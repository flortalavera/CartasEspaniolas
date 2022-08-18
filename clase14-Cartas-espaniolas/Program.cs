using clase14_Cartas_espaniolas;

Carta espaniolas = new Carta();
Oro oro = new Oro();
Espada espada = new Espada();
Copa copa = new Copa();
Basto basto = new Basto();
Tools tools = new Tools();

var listaMazo = new List<string>();
string ultimaCarta = "";

espaniolas.CargarMazo(listaMazo, oro.CartasOro());
espaniolas.CargarMazo(listaMazo, espada.CartasEspada());
espaniolas.CargarMazo(listaMazo, copa.CartasCopa());
espaniolas.CargarMazo(listaMazo, basto.CartasBasto());

bool continuar = true;  
do  
{      
    Console.Clear();
    Console.WriteLine(tools.MenuCartas());
    bool seguir = false;    
    int eleccion = 0;
    do   
    {
        Console.Write("Ingrese su opción: -> ");

        string ingreso = Console.ReadLine();

        bool esNumero = tools.ctrlNumber(ingreso);
        if (esNumero)
        {
            Console.Write("                      ");
            Console.SetCursorPosition(0, 14);
            seguir = false;
            eleccion = int.Parse(ingreso);
        }
        else
        {
            tools.PausaContinuar("Solo se permiten números.", Console.CursorLeft, Console.CursorTop);
        }
    } while (seguir);

    string mensaje = "";

    // OPCIONES DEL MENÚ
    switch (eleccion)
    {
        case 1: // Mezcla las cartas
            List<string> disponibles = espaniolas.MostrarCartas(listaMazo, ultimaCarta);
            int largoLista = disponibles.Count();

            if (largoLista == 0)
            {
                mensaje = "No hay cartas disponibles para barajar.";
            }
            else
            {
                int indiceMezcla = listaMazo.Count() - disponibles.Count();
                listaMazo = espaniolas.Barajar(listaMazo, indiceMezcla);
                mensaje = "Cartas mezcladas...";
            }
            tools.PausaContinuar(mensaje, Console.CursorLeft, Console.CursorTop);
            break;

        case 2: // Devuelve siguiente carta                

            int cant = espaniolas.MostrarCartas(listaMazo, ultimaCarta).Count();

            switch (cant)
            {
                case 0:
                    mensaje = "No se pueden mostrar la siguiente carta, ya no hay cartas en el mazo.";
                    break;

                default:
                    ultimaCarta = espaniolas.SigCarta(listaMazo, ultimaCarta);
                    Console.WriteLine($"Ésta es la siguiente carta... \n{ultimaCarta}");
                    mensaje = "";
                    break;
            }
            tools.PausaContinuar(mensaje, Console.CursorLeft, Console.CursorTop);
            break;

        case 3: // Devuelve el número de cartas disponibles en el mazo para jugar
            int disponibles2 = espaniolas.CartasDisponibles(listaMazo, ultimaCarta);

            if (disponibles2 == 0)
            {
                mensaje = "No hay más cartas en el mazo.";
            }
            else
            {
                mensaje = $"Las disponibles son: {disponibles2} cartas.";
            }

            tools.PausaContinuar(mensaje, Console.CursorLeft, Console.CursorTop);
            break;

        case 4: // Reparte cartas
            bool reingresarCantidad = true;
            int colPausa2 = 0;
            List<string> disponibles3 = espaniolas.MostrarCartas(listaMazo, ultimaCarta);
            largoLista = disponibles3.Count();
            if (largoLista == 0)
            {
                mensaje = "Ya no hay cartas en el mazo.";
            }
            else
            {
                do
                {
                    Console.Write("¿Cuántas cartas desea?: ");
                    string ingreso = Console.ReadLine();
                    bool esNro = tools.ctrlNumber(ingreso);
                    if (esNro)
                    {
                        int cantX = int.Parse(ingreso);

                        if (largoLista >= cantX)
                        {
                            List<string> susCartas = espaniolas.DarCartas(listaMazo, cantX, ultimaCarta);
                            ultimaCarta = espaniolas.UltimaCarta(susCartas);

                            Console.WriteLine("Éstas son sus cartas...\n");
                            int posX2 = Console.CursorLeft; 
                            int posY2 = Console.CursorTop;
                            int sigCol2 = posX2;
                            int sigRow2 = posY2;

                            foreach (var item in susCartas)
                            {
                                if ((sigRow2 - posY2) == 10)
                                {
                                    if (sigCol2 == 0) colPausa2 = sigRow2 + 1;
                                    sigCol2 += 15;
                                    sigRow2 = posY2;
                                }
                                Console.SetCursorPosition(sigCol2, sigRow2);
                                Console.WriteLine(item);
                                sigRow2++;
                            }
                            reingresarCantidad = false;
                        }
                        else
                        {
                            mensaje = $"No se pueden dar {cantX} de cartas, sólo hay {disponibles3} cartas en el mazo.";
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sólo se permiten números.");
                        break;
                    }
                } while (reingresarCantidad);
            }

            tools.PausaContinuar(mensaje, Console.CursorLeft, colPausa2);
            break;

        case 5: // Muestra las cartas que ya se jugaron (no disponibles para jugar)

            if (ultimaCarta == "")
            {
                mensaje = "No hay montón. Aún no se dio ninguna carta.";
            }
            else
            {
                List<string> montonCartas = espaniolas.MontonCartas(listaMazo, ultimaCarta);
                Console.WriteLine("Estas son las cartas que ya se han jugado.\n");
                int posX1 = Console.CursorLeft;
                int posY1 = Console.CursorTop;
                int sigCol1 = posX1;
                int sigRow1 = posY1;
                int colPausa1 = 0;
                foreach (var item in montonCartas)
                {
                    if ((sigRow1 - posY1) == 10)
                    {
                        if (sigCol1 == 0) colPausa1 = sigRow1 + 1;
                        sigCol1 += 15;
                        sigRow1 = posY1;
                    }
                    Console.SetCursorPosition(sigCol1, sigRow1);
                    Console.WriteLine(item);
                    sigRow1++;
                }
            }
            tools.PausaContinuar(mensaje, 43, 14);
            break;


        case 6: // Muestra las cartas restantes del mazo (disponibles para jugar)
            List<string> muestraCartas = espaniolas.MostrarCartas(listaMazo, ultimaCarta);

            Console.WriteLine("Estas cartas quedan en el mazo.\n");

            int posX = Console.CursorLeft;
            int posY = Console.CursorTop;
            int sigCol = posX;
            int sigRow = posY;
            int colPausa = 0;

            foreach (var item in muestraCartas)
            {
                if ((sigRow - posY) == 10)
                {
                    if (sigCol == 0) colPausa = sigRow + 1;
                    sigRow = posY;
                    sigCol += 15;
                }
                else { colPausa = sigRow + 1; }

                Console.SetCursorPosition(sigCol, sigRow);
                Console.WriteLine(item);
                sigRow++;
            }
            tools.PausaContinuar("", 33, 14);
            break;

        case 7:
            Console.WriteLine("Fin del juego. Presione una tecla para salir...");
            Console.ReadKey();
            continuar = false;
            break;
    }
} while (continuar);

Console.ReadKey();