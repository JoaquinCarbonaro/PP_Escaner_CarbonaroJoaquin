using System;
using Entidades;

class Program
{
    static void Main()
    {
        Escaner escanerLibros = new Escaner("MarcaX", TipoDoc.Libro);
        Escaner escanerMapas = new Escaner("MarcaY", TipoDoc.Mapa);

        Libro libro1 = new Libro("C# Programming", "John Doe", 2023, "123456789", "987654321", 350);
        Libro libro2 = new Libro("Learn .NET", "Jane Smith", 2022, "234567890", "876543210", 500);

        Mapa mapa1 = new Mapa("World Map", "Cartographer", 2021, "567890123", 100, 200);
        Mapa mapa2 = new Mapa("City Map", "Cartographer", 2020, "678901234", 150, 250);

        escanerLibros + libro1;
        escanerLibros + libro2;
        escanerMapas + mapa1;
        escanerMapas + mapa2;

        Console.WriteLine("Libros distribuidos:");
        Informes.MostrarDistribuidos(escanerLibros, out int extLibros, out int cantLibros, out string resumenLibros);
        Console.WriteLine($"Cantidad: {cantLibros}, Extensión: {extLibros}\nResumen:\n{resumenLibros}");

        Console.WriteLine("Mapas distribuidos:");
        Informes.MostrarDistribuidos(escanerMapas, out int extMapas, out int cantMapas, out string resumenMapas);
        Console.WriteLine($"Cantidad: {cantMapas}, Extensión: {extMapas}\nResumen:\n{resumenMapas}");
    }
}