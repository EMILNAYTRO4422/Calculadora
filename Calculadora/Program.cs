/*
    Calculadora + Verificador de estudiante aprobado
    Programación I - ITLA
    Autor: Emil Gómez - 2026-0935

    - Operaciones: Sumar, Restar, Multiplicar y Dividir (con 2 o más números)
    - Verifica si un estudiante aprobó o no según el promedio de sus notas
    - El programa no se detiene hasta que el usuario elige la opción Salir
*/

using System.Collections.Generic;

// ===================== VARIABLES GLOBALES =====================
// Se declaran e inicializan al inicio del código
int opcion = 0;                                 // Opción elegida en el menú principal
int continuar = 0;                              // 1 = Sí, 2 = No
decimal resultado = 0;                          // Resultado de las operaciones
decimal suma = 0;                               // Acumulador de notas
decimal promedio = 0;                           // Promedio del estudiante
decimal nota = 0;                               // Nota digitada
decimal notaMinima = 70;                        // Nota mínima para aprobar
string? nombreEstudiante = "";                   // Nombre del estudiante
List<decimal> numeros = new List<decimal>();    // Números de las operaciones
List<decimal> notas = new List<decimal>();      // Notas del estudiante

Console.WriteLine("========================================");
Console.WriteLine("   CALCULADORA Y VERIFICADOR DE NOTAS");
Console.WriteLine("========================================");

// El programa se repite hasta que el usuario elija la opción 6 (Salir)
while (opcion != 6)
{
    // Manejo de errores: evita que el programa se detenga por una entrada incorrecta
    try
    {
        Console.WriteLine();
        Console.WriteLine("-------------- MENÚ PRINCIPAL --------------");
        Console.WriteLine("1. Sumar");
        Console.WriteLine("2. Restar");
        Console.WriteLine("3. Multiplicar");
        Console.WriteLine("4. Dividir");
        Console.WriteLine("5. Verificar si un estudiante aprobó");
        Console.WriteLine("6. Salir del programa");
        Console.WriteLine("Digite el número de la opción que desea:");
        opcion = Convert.ToInt32(Console.ReadLine());

        // Captura de números para las operaciones aritméticas (opciones 1 a 4)
        if (opcion >= 1 && opcion <= 4)
        {
            numeros.Clear();

            Console.WriteLine("Digite el primer número:");
            numeros.Add(Convert.ToDecimal(Console.ReadLine()));

            Console.WriteLine("Digite el segundo número:");
            numeros.Add(Convert.ToDecimal(Console.ReadLine()));

            continuar = 0;
            while (continuar != 2)
            {
                Console.WriteLine("¿Desea agregar otro número? 1. Sí  2. No");
                continuar = Convert.ToInt32(Console.ReadLine());

                if (continuar == 1)
                {
                    Console.WriteLine("Digite el siguiente número:");
                    numeros.Add(Convert.ToDecimal(Console.ReadLine()));
                }
                else if (continuar != 2)
                {
                    Console.WriteLine("Opción inválida. Digite 1 para Sí o 2 para No.");
                }
            }
        }

        // Más de 3 escenarios: se usa switch
        switch (opcion)
        {
            case 1:
                resultado = 0;
                foreach (decimal valor in numeros)
                {
                    resultado = resultado + valor;
                }
                Console.WriteLine("El resultado de la suma es: " + resultado);
                break;

            case 2:
                resultado = numeros[0];
                for (int i = 1; i < numeros.Count; i++)
                {
                    resultado = resultado - numeros[i];
                }
                Console.WriteLine("El resultado de la resta es: " + resultado);
                break;

            case 3:
                resultado = 1;
                foreach (decimal valor in numeros)
                {
                    resultado = resultado * valor;
                }
                Console.WriteLine("El resultado de la multiplicación es: " + resultado);
                break;

            case 4:
                resultado = numeros[0];
                for (int i = 1; i < numeros.Count; i++)
                {
                    // Si algún divisor es 0 se lanza DivideByZeroException (se captura abajo)
                    resultado = resultado / numeros[i];
                }
                Console.WriteLine("El resultado de la división es: " + resultado);
                break;

            case 5:
                notas.Clear();
                suma = 0;

                Console.WriteLine("Digite el nombre del estudiante:");
                nombreEstudiante = Console.ReadLine();
                if (nombreEstudiante == null || nombreEstudiante == "")
                {
                    nombreEstudiante = "Estudiante sin nombre";
                }

                continuar = 1;
                while (continuar == 1)
                {
                    // Se repite hasta que la nota esté en el rango válido
                    do
                    {
                        Console.WriteLine("Digite la nota (entre 0 y 100):");
                        nota = Convert.ToDecimal(Console.ReadLine());

                        if (nota < 0 || nota > 100)
                        {
                            Console.WriteLine("La nota debe estar entre 0 y 100. Intente nuevamente.");
                        }
                    } while (nota < 0 || nota > 100);

                    notas.Add(nota);

                    // Se repite hasta que la respuesta sea 1 o 2
                    continuar = 0;
                    while (continuar != 1 && continuar != 2)
                    {
                        Console.WriteLine("¿Desea agregar otra nota? 1. Sí  2. No");
                        continuar = Convert.ToInt32(Console.ReadLine());

                        if (continuar != 1 && continuar != 2)
                        {
                            Console.WriteLine("Opción inválida. Digite 1 para Sí o 2 para No.");
                        }
                    }
                }

                foreach (decimal valorNota in notas)
                {
                    suma = suma + valorNota;
                }
                promedio = suma / notas.Count;

                Console.WriteLine();
                Console.WriteLine("Estudiante: " + nombreEstudiante);
                Console.WriteLine("Cantidad de notas: " + notas.Count);
                Console.WriteLine("Promedio: " + promedio.ToString("0.00"));

                if (promedio >= notaMinima)
                {
                    Console.WriteLine("Resultado: APROBADO");
                }
                else
                {
                    Console.WriteLine("Resultado: REPROBADO (la nota mínima para aprobar es " + notaMinima + ")");
                }
                break;

            case 6:
                Console.WriteLine("Gracias por usar el programa. ¡Hasta luego!");
                break;

            default:
                Console.WriteLine("Opción inválida. Digite un número del 1 al 6.");
                break;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Error: debe digitar un número válido (sin letras ni símbolos). Intente de nuevo.");
    }
    catch (DivideByZeroException)
    {
        Console.WriteLine("Error: no se puede dividir entre cero. Intente de nuevo.");
    }
    catch (OverflowException)
    {
        Console.WriteLine("Error: el número digitado o el resultado es demasiado grande. Intente de nuevo.");
    }
    catch (Exception ex)
    {
        // Va de último porque Exception contiene a todas las demás
        Console.WriteLine("Ocurrió un error inesperado: " + ex.Message);
    }
    finally
    {
        // Se ejecuta siempre, haya o no error
        Console.WriteLine("--------------------------------------------");
    }
}