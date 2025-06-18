String banner = @"
Juan David Bermúdez Celedón
Simulador Spa Robles
Estructura de Datos 301305A_2033
";
String[] servicios =
{
    "Corte y cepillado $60.000",
    "Corte, cepillado y uñas $90.000",
    "Uñas en acrílico y cejas $100.000",
    "Uñas en acrílico, maquillaje y cejas $140.000"
};
int[] precios = { 60000, 90000, 100000, 140000 };
const String password = "123";

Console.WriteLine(banner);
Console.Write("Ingrese la contraseña: ");
var inputPassword = Console.ReadLine();

while (password != inputPassword)
{
    Console.WriteLine("Contraseña incorrecta.");
    inputPassword = Console.ReadLine();
}

Console.WriteLine("Contraseña correcta. Acceso concedido.");
int op = -1;
do
{
    ShowMenu();
    op = Console.ReadLine() is string input && int.TryParse(input, out int option) ? option : -1;
    switch (op)
    {
        case int n when n is >= 1 and <= 4:
            Console.WriteLine("Servicio seleccionado: {0}", servicios[op - 1]);
            Console.Write("Ingrese su nombre: ");
            String? nombre = Console.ReadLine();
            Console.Write("Ingrese su cédula: ");
            String? cedula = Console.ReadLine();
            int estrato = 0;
            do
            {
                Console.Write("Ingrese su estrato socioeconómico (1-6): ");
                estrato = Console.ReadLine() is string estratoInput && int.TryParse(estratoInput, out int estratoValue)
                    ? estratoValue
                    : 0;
                if (estrato < 1 | estrato > 6)
                    Console.WriteLine("Estrato inválido");
            } while (estrato < 1 | estrato > 6);

            float descuento = CalcularDescuento(estrato);
            float total = precios[op - 1] * (1 - descuento / 100);
            Console.WriteLine("""
                              Id cliente: {0}
                              Nombre: {1}
                              Su descuento es de {2}%, valor del servicio con descuento aplicado: ${3}
                              """, cedula, nombre, descuento, total
            );
            break;
        case 0:
            Console.WriteLine("Saliendo del programa...");
            break;
        default:
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
            break;
    }
} while (op < 0 | op > 4);

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

float CalcularDescuento(int estrato)
{
    return estrato switch
    {
        1 or 2 => 15,
        3 or 4 => 10,
        >= 5 => 5,
        _ => 0
    };
}