using System.Diagnostics;

Dictionary<string, Planta> plantas = new Dictionary<string, Planta>(); 
List<string> categorias = new List<string>();
int opcion;
bool continuar;
do
{
    Console.WriteLine("MENÚ PRINCIPAL");
    Console.WriteLine("1) Ver menú de plantas");
    Console.WriteLine("2) Ver menú de productos");
    Console.WriteLine("3) Salir del programa");
    continuar = int.TryParse(Console.ReadLine(), out opcion);
    Console.Clear();
    if (continuar)
    {
        switch (opcion)
        {
            case 1:
                MenuPlantas();
                break;
            default:
                Console.WriteLine("Asegurese de ingresar una opción válida\n");
                break;
        }
    }
    else
    {
        Console.WriteLine("Asegurese de ingresar un número entero\n");
    }
} while (opcion!=3);
void MenuPlantas()
{
    do
    {
        Console.WriteLine("MENÚ DE PLANTAS");
        Console.WriteLine("1) Ingresar nueva planta");
        Console.WriteLine("2) Buscar planta");
        Console.WriteLine("3) Ver todas las plantas");
        Console.WriteLine("4) Modificar planta");
        Console.WriteLine("5) Modificar categoría");
        Console.WriteLine("6) Volver al menú principal");
        continuar = int.TryParse (Console.ReadLine(), out opcion);
        Console.Clear();
        if (continuar)
        {
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("¿Cuál es el nombre de la planta?");
                    string nombre = Console.ReadLine();
                    string categoria="";
                    do
                    {
                        Console.WriteLine("\n¿De qué categoría es la planta?");
                        Console.WriteLine("1) Ingresar nueva categoría");
                        Console.WriteLine("2) Asignar categoría ya existente");
                        Console.WriteLine("3) No especificar");
                        continuar = int.TryParse(Console.ReadLine(),out opcion);
                        Console.Clear();
                        if (continuar)
                        {
                            switch (opcion)
                            {
                                case 1:
                                    Console.WriteLine("¿Cuál será el nombre de la categoría para la planta "+nombre+"?");
                                    categoria = Console.ReadLine();
                                    categorias.Add (categoria);
                                    Console.Clear();
                                    Console.WriteLine("La categoría se ha creado y asignado correctamente\n");
                                    break;
                                case 2:
                                    if (categorias.Count == 0)
                                    {
                                        Console.WriteLine("Aún no existen categorías. Ingrese una nueva");
                                        continuar = false;
                                    }
                                    else
                                    {
                                        do
                                        {
                                            int contador = 1;
                                            foreach (string cat in categorias)
                                            {
                                                Console.WriteLine(contador + ") " + cat);
                                                contador++;
                                            }
                                            Console.WriteLine("\nIngrese el número que corresponda a la categoría\nque desea asignar a la planta " + nombre);
                                            continuar = int.TryParse(Console.ReadLine(), out opcion);
                                            if (continuar)
                                            {
                                                if (opcion > 0 && opcion < contador)
                                                {
                                                    categoria = categorias[opcion-1];
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Asegurese de ingresar una opción válida");
                                                    continuar = false;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Asegurese de ingresar un número entero");
                                            }
                                        } while (!continuar);
                                    }
                                    break;
                                case 3:
                                    categoria = "No especificada";
                                    break;
                                default:
                                    Console.WriteLine("\nAsegurese de ingresar una opción válida");
                                    continuar = false;
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nAsegurese de ingresar un número entero");
                        }
                    } while (!continuar);
                    int cantidad;
                    do
                    {
                        Console.WriteLine("¿Cuántas plantas "+nombre+" adquirió?");
                        continuar = int.TryParse(Console.ReadLine(),out cantidad);
                        Console.Clear();
                        if (continuar)
                        {
                            if (cantidad <= 0)
                            {
                                Console.WriteLine("Asegurese de ingresar una cantidad real\n");
                                continuar = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Asegurese de ingresar un número entero\n");
                        }
                    } while (!continuar);
                    double precio;
                    do
                    {
                        Console.WriteLine("¿Cuál es el precio de la planta "+nombre+" en quetzales?");
                        continuar = double.TryParse(Console.ReadLine(),out precio);
                        Console.Clear();
                        if (continuar)
                        {
                            if (precio < 0)
                            {
                                Console.WriteLine("Asegurese de ingresar un precio real\n");
                                continuar = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Asegurese de ingresar solo números\n");
                        }
                    } while (!continuar);
                    Planta p = new Planta(nombre, cantidad, categoria, precio);
                    plantas.Add(nombre, p);
                    Console.WriteLine("La planta se ha añadido correctamente\n");
                    break;
                case 2:
                    do
                    {
                        Console.WriteLine("¿Qué método de búsqueda desea utilizar?");
                        Console.WriteLine("1) Buscar por nombre");
                        Console.WriteLine("2) Buscar por código");
                        Console.WriteLine("3) Buscar por categoría");
                        Console.WriteLine("4) Regresar al menú de plantas");
                        continuar = int.TryParse(Console.ReadLine(), out opcion);
                        Console.Clear();
                        if (continuar)
                        {
                            switch (opcion)
                            {
                                case 1:
                                    Console.WriteLine("¿Cuál es el nombre de la planta que desea buscar?");
                                    string buscar = Console.ReadLine();
                                    Console.Clear();
                                    bool encontrado = false;
                                    foreach(var b in plantas)
                                    {
                                        if (b.Key == buscar)
                                        {
                                            encontrado = true;
                                            break;
                                        }
                                    }
                                    if (encontrado)
                                    {
                                        do
                                        {
                                            plantas[buscar].VerInfo();
                                            Console.WriteLine("¿Qúe desea hacer?");
                                            Console.WriteLine("1) Ver más datos sobre esta planta");
                                            Console.WriteLine("2) Ver los productos que funcionan con esta planta");
                                            Console.WriteLine("3) Volver al menú de plantas");
                                            continuar=int.TryParse(Console.ReadLine(), out opcion);
                                            Console.Clear();
                                            if (continuar)
                                            {
                                                switch (opcion)
                                                {
                                                    case 1:
                                                        Console.WriteLine("- Esta planta debe regarse cada 3 días");
                                                        Console.WriteLine("- Esta planta debe estar en sombra\n");
                                                        break;
                                                    case 2:
                                                        Console.WriteLine("- Abono tal");
                                                        Console.WriteLine("- tierra tal");
                                                        Console.WriteLine("- Insecticida tal\n");
                                                        break;
                                                    default:
                                                        Console.WriteLine("Asegurese de ingresar una opción válida");
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Asegurese de ingresar un número entero");
                                            }
                                        } while (opcion!=3);
                                    }
                                    else
                                    {
                                        Console.WriteLine("La planta ingresada no existe en el listado\n");
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Asegurese de ingresar una opción válida\n");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Asegurese de ingresar un número entero");
                        }
                    } while (opcion!=4);
                    break;
                case 3:
                    Console.WriteLine("LISTADO COMPLETO DE PLANTAS INGRESADAS\n");
                    foreach (var plan in plantas)
                    {
                        plan.Value.VerInfo();
                    }
                    break;
                default:
                    Console.WriteLine("Asegurese de ingresar una opción válida\n");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Asegurese de ingresar un número entero\n");
        }
    } while (opcion!=6);
}
class Planta
{
    private string nombre;
    private int cantidad;
    private string categoria;
    private double precio;

    public Planta(string nombre, int cantidad, string categoria, double precio)
    {
        this.nombre = nombre;
        this.cantidad = cantidad;
        this.categoria = categoria ;
        this.precio = precio ;
    }
    public void VerInfo()
    {
        Console.WriteLine("Nombre: "+nombre);
        Console.WriteLine("Categoría: "+categoria);
        Console.WriteLine("Cantidad en posesión: "+cantidad);
        Console.WriteLine("Precio: Q"+precio+"\n");
    }
}