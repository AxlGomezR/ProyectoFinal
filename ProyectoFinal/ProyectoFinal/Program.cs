using System.Diagnostics;

Dictionary<int, Planta> plantas = new Dictionary<int, Planta>(); 
List<string> categorias = new List<string>();
int opcion;
bool continuar;
bool encontrado;
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
            case 3:
                Console.WriteLine("Ha salido del programa");
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
        Console.WriteLine("4) Ver resumen de inventario");
        Console.WriteLine("5) Modificar información");
        Console.WriteLine("6) Volver al menú principal");
        continuar = int.TryParse (Console.ReadLine(), out opcion);
        Console.Clear();
        if (continuar)
        {
            switch (opcion)
            {
                case 1:
                    IngresarPlanta();
                    break;
                case 2:
                    MenuBuscar();
                    break;
                case 3:
                    Console.WriteLine("LISTADO COMPLETO DE PLANTAS INGRESADAS\n");
                    foreach (var plan in plantas)
                    {
                        plan.Value.VerInfo();
                    }
                    break;
                case 5:
                    ModificarPlanta();
                    break;
                default:
                    if (opcion != 6)
                    {
                        Console.WriteLine("Asegurese de ingresar una opción válida\n");
                    }
                    break;
            }
        }
        else
        {
            Console.WriteLine("Asegurese de ingresar un número entero\n");
        }
    } while (opcion!=6);
}

void IngresarPlanta()
{
    Console.WriteLine("¿Cuál es el nombre de la planta?");
    string nombre = Console.ReadLine();
    string categoria = "";
    do
    {
        Console.WriteLine("\n¿De qué categoría es la planta?");
        Console.WriteLine("1) Ingresar nueva categoría");
        Console.WriteLine("2) Asignar categoría ya existente");
        Console.WriteLine("3) No especificar");
        continuar = int.TryParse(Console.ReadLine(), out opcion);
        Console.Clear();
        if (continuar)
        {
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("¿Cuál será el nombre de la categoría para la planta " + nombre + "?");
                    categoria = Console.ReadLine();
                    Console.Clear();
                    encontrado = false;
                    foreach (string cate in categorias)
                    {
                        if (cate==categoria)
                        {
                            encontrado = true;
                            break;
                        }
                    }
                    if (encontrado)
                    {
                        Console.WriteLine("La categoría se ha asignado correctamente");
                        Console.WriteLine("Puede asignar categorías que ya existan desde la opción 2\n");
                    }
                    else
                    {
                        categorias.Add(categoria);
                        Console.Clear();
                        Console.WriteLine("La categoría se ha creado y asignado correctamente\n");
                    }
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
                                    categoria = categorias[opcion - 1];
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
        Console.WriteLine("¿Cuántas plantas " + nombre + " adquirió?");
        continuar = int.TryParse(Console.ReadLine(), out cantidad);
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
        Console.WriteLine("¿Cuál es el precio de la planta " + nombre + " en quetzales?");
        continuar = double.TryParse(Console.ReadLine(), out precio);
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
    int codigo;
    int contador2=1;
    foreach(string cat in categorias)
    {
        if (cat == categoria)
        {
            break;
        }
        contador2++;
    }
    int cantidadPlantas = 0;
    foreach(var cant in plantas)
    {
        if (cant.Value.Categoria == categoria)
        {
            cantidadPlantas++;
        }
    }
    codigo = (1000 * contador2) + cantidadPlantas;
    do
    {
        continuar = true;
        foreach (var c in plantas)
        {
            if (c.Key == codigo)
            {
                codigo++;
                continuar = false;
                break;
            }
        }
    } while (!continuar);
    Planta p = new Planta(codigo,nombre, cantidad, categoria, precio);
    plantas.Add(codigo, p);
    Console.WriteLine("La planta se ha añadido correctamente\n");
}
void MenuBuscar()
{
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
            if (opcion >= 1 && opcion <= 3)
            {
                BuscarPlanta("buscar",opcion);
            }
            else if (opcion!=4)
            {
                Console.WriteLine("Asegurese de ingresar una opción válida\n");
                continuar = false;
            }
        }
        else
        {
            Console.WriteLine("Asegurese de ingresar un número entero\n");
        }
    } while (opcion != 4);
}
void BuscarPlanta(string accion, int seleccion)
{
    switch (seleccion)
    {
        case 1:
            Console.WriteLine("¿Cuál es el nombre de la planta que desea "+accion+"?");
            string buscar = Console.ReadLine();
            Console.Clear();
            encontrado = false;
            int llave = 0;
            foreach (var b in plantas)
            {
                if (b.Value.Nombre == buscar)
                {
                    encontrado = true;
                    llave = b.Key;
                    break;
                }
            }
            if (encontrado)
            {
                plantas[llave].VerInfo();
            }
            else
            {
                Console.WriteLine("La planta ingresada no existe en el listado\n");
            }
            break;
        case 2:
            int codigo = 0;
            do
            {
                Console.WriteLine("Ingrese el código de la planta que desea "+accion);
                continuar = int.TryParse(Console.ReadLine(), out codigo);
                Console.Clear();
                if (!continuar)
                {
                    Console.WriteLine("Asegurese de ingresar solo números enteros\n");
                }
            } while (!continuar);
            encontrado = false;
            foreach (var e in plantas)
            {
                if (e.Key == codigo)
                {
                    encontrado = true;
                    break;
                }
            }
            if (encontrado)
            {
                plantas[codigo].VerInfo();
            }
            else
            {
                Console.WriteLine("No se ha encontrado ninguna planta con ese código\n");
            }
            break;
        case 3:
            Console.WriteLine("Se mostrarán todas las plantas que sean de la categoría ingresada");
            Console.WriteLine("¿Qué categoría desea buscar?");
            string categoria = Console.ReadLine();
            Console.Clear();
            encontrado = false;
            foreach (string c in categorias)
            {
                if (c == categoria)
                {
                    encontrado = true;
                    break;
                }
            }
            if (encontrado)
            {
                Console.WriteLine("LISTADO DE PLANTAS DE TIPO: " + categoria+"\n");
                foreach (var cat in plantas)
                {
                    if (cat.Value.Categoria == categoria)
                    {
                        cat.Value.VerInfo();
                    }
                }
            }
            else
            {
                Console.WriteLine("No se encontraron plantas de la categoria " + categoria + "\n");
            }
            break;
    }
}
void ModificarPlanta()
{
    do
    {
        Console.WriteLine("¿Qúe desea modificar?");
        Console.WriteLine("1) Modificar información de una planta");
        Console.WriteLine("2) Modificar una categoría");
        Console.WriteLine("3) Volver al menú de plantas");
        continuar = int.TryParse(Console.ReadLine(), out opcion);
        Console.Clear();
        if (continuar)
        {
            switch (opcion)
            {
                case 1:
                    do
                    {
                        Console.WriteLine("Se modificará la información de la planta que busque");
                        Console.WriteLine("¿Qué método de búsqueda desea utilizar?");
                        Console.WriteLine("1) Buscar por nombre");
                        Console.WriteLine("2) Buscar por código");
                        Console.WriteLine("3) Volver al menú de plantas");
                        continuar = int.TryParse (Console.ReadLine(), out opcion);
                        Console.Clear();
                        if (continuar)
                        {
                            if (opcion >= 1 && opcion <= 2)
                            {
                                BuscarPlanta("modificar", opcion);
                            }else if (opcion != 3)
                            {
                                Console.WriteLine("Asegurese de ingresar una opción válida");
                                continuar = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Asegurese de ingresar un número entero\n");
                        }
                    } while (opcion!=3);
                    break;
                default:
                    if (opcion != 3)
                    {
                        Console.WriteLine("Asegurese de ingresar una opción válida\n");
                    }
                    break;
            }
        }
        else
        {
            Console.WriteLine("Asegurese de ingresar un número entero\n");
        }
    } while (opcion!=3);
}

class Planta
{
    private int codigo;
    private string nombre;
    private int cantidad;
    private string categoria;
    private double precio;

    public Planta(int codigo, string nombre, int cantidad, string categoria, double precio)
    {
        this.codigo = codigo;
        this.nombre = nombre;
        this.cantidad = cantidad;
        this.categoria = categoria ;
        this.precio = precio ;
    }
    public string Nombre{  get { return nombre; } }
    public string Categoria { get { return categoria; } }
    public void VerInfo()
    {
        Console.WriteLine("Código de la planta: "+codigo);
        Console.WriteLine("Nombre: "+nombre);
        Console.WriteLine("Categoría: "+categoria);
        Console.WriteLine("Cantidad en posesión: "+cantidad);
        Console.WriteLine("Precio: Q"+precio+"\n");
    }
}