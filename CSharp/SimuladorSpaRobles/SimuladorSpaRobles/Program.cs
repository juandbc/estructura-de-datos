using System.Data;

String banner = @"
Juan David Bermúdez Celedón
Simulador Spa Robles
Estructura de Datos 301305A_2033
";
String[] servicios = {
    "Corte y cepillado $60.000",
    "Corte, cepillado y uñas $90.000",
    "Uñas en acrílico y cejas $100.000",
    "Uñas en acrílico, maquillaje y cejas $140.000"
};
int[] precios = { 60000, 90000, 100000, 140000 };
String password = "123";
Console.WriteLine(banner);
Console.Write("Ingrese la contraseña: ");
String? inputPassword = Console.ReadLine();

if (inputPassword == password)
{
    Console.WriteLine("Contraseña correcta. Acceso concedido.");
    ShowMenu();
    int op = Console.ReadLine() is string input && int.TryParse(input, out int option) ? option : -1;
    switch (op)
    {
        case int n when n >= 1 && n <= 4:
            Console.WriteLine("Servicio seleccionado: {0}", servicios[op - 1]);
            Console.Write("Ingrese su nombre: ");
            String? nombre = Console.ReadLine();
            Console.Write("Ingrese su cédula: ");
            String? cedula = Console.ReadLine();
            Console.Write("Ingrese su estrato socioeconómico (1-6): ");
            int estrato = Console.ReadLine() is string estratoInput && int.TryParse(estratoInput, out int estratoValue) ? estratoValue : -1;
            float descuento = calcularDescuento(estrato);
            Console.WriteLine("Su descuento es de {0}%, valor del servicio con descuento aplicado: {1}", descuento, precios[op - 1] * (1 - descuento / 100));
            break;
        case 0:
            Console.WriteLine("Saliendo del programa...");
            break;
        default:
            Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
            ShowMenu();
            break;
    }
}
else
{
    Console.WriteLine("Contraseña incorrecta. Acceso denegado.");
}

void ShowMenu()
{
    String texto = "";
    for (int i = 0; i < servicios.Length; i++)
    {
        texto += $"{i + 1}. {servicios[i]}\n";
    }
    Console.WriteLine("""
    Menú de Servicios
    {0}
    Escoja una opción (1-4) o 0 para salir:
    """, texto);
}

float calcularDescuento(int estrato)
{
    return estrato switch
    {
        1 or 2 => 15,
        3 or 4 => 10,
        >= 5 => 5,
        _ => 0
    };
}