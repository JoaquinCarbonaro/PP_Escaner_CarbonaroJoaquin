using System;
using Entidades;
using static Entidades.Documento;
using static Entidades.Escaner;

class Program
{
    static void Main()
    {
        /*
        Escaner escanerLibros = new Escaner("MarcaX", TipoDoc.Libro);
        Escaner escanerMapas = new Escaner("MarcaY", TipoDoc.Mapa);

        Libro libro1 = new Libro("C# Programming", "John Doe", 2023, "123456789", "987654321", 350);
        Libro libro2 = new Libro("Learn .NET", "Jane Smith", 2022, "234567890", "876543210", 500);

        Mapa mapa1 = new Mapa("World Map", "Cartographer", 2021, "1", "567890123", 100, 200);
        Mapa mapa2 = new Mapa("City Map", "Cartographer", 2020, "1", "678901234", 150, 250);

        Console.WriteLine("Libros distribuidos:");
        Informes.MostrarDistribuidos(escanerLibros, out int extLibros, out int cantLibros, out string resumenLibros);
        Console.WriteLine($"Cantidad: {cantLibros}, Extensión: {extLibros}\nResumen:\n{resumenLibros}");

        Console.WriteLine("Mapas distribuidos:");
        Informes.MostrarDistribuidos(escanerMapas, out int extMapas, out int cantMapas, out string resumenMapas);
        Console.WriteLine($"Cantidad: {cantMapas}, Extensión: {extMapas}\nResumen:\n{resumenMapas}");

        Console.WriteLine(mapa1 == mapa1);
        Console.WriteLine(mapa1 == mapa2);
        Console.WriteLine(mapa1 != mapa1);
        Console.WriteLine(mapa1 != mapa2);

        Console.WriteLine(libro1 == libro1);
        Console.WriteLine(libro1 == libro2);
        Console.WriteLine(libro1 != libro1);
        Console.WriteLine(libro1 != libro2);

        Console.WriteLine(escanerLibros == libro1);
        Console.WriteLine(escanerLibros != mapa1);
        Console.WriteLine(escanerMapas == mapa1);
        Console.WriteLine(escanerMapas != libro1);
        Console.WriteLine(escanerLibros + libro1);
        Console.WriteLine(escanerLibros + mapa1);
        Console.WriteLine(escanerMapas + mapa1);
        Console.WriteLine(escanerMapas + libro1);
        */


        // Crea instancias de Libro 
        Libro libro1 = new Libro("El Quijote", "Miguel de Cervantes", 1605, "123-4567890123", "001", 500);
        Libro libro2 = new Libro("C# Programming", "John Doe", 2023, "123456789", "987654321", 350);

        // Muestra los datos del libro
        Console.WriteLine(libro1.ToString());
        Console.WriteLine(libro2.ToString());

        // Crear instancias de Escaner
        Escaner escanerLibros = new Escaner("HP", Escaner.TipoDoc.libro);
        Escaner escanerMapas = new Escaner("Canon", Escaner.TipoDoc.mapa);

        // Crea instancias de Mapa
        Mapa mapa1 = new Mapa("Mapa del Mundo", "John Doe", 2022, "789-4561230789", "003", 20, 30);
        Mapa mapa2 = new Mapa("City Map", "Cartographer", 2020, "1", "678901234", 150, 250);

        // Muestra los datos del mapa
        Console.WriteLine(mapa1.ToString());
        Console.WriteLine(mapa2.ToString());


        // Probar agregar libros al escáner de libros
        bool agregado = escanerLibros + libro1;
        Console.WriteLine($"Libro 1 agregado al escáner de libros: {agregado}");

        agregado = escanerLibros + libro2;
        Console.WriteLine($"Libro 2 agregado al escáner de libros: {agregado}");

        // Probar agregar mapas al escáner de mapas
        agregado = escanerMapas + mapa1;
        Console.WriteLine($"Mapa 1 agregado al escáner de mapas: {agregado}");

        agregado = escanerMapas + mapa2;
        Console.WriteLine($"Mapa 2 agregado al escáner de mapas: {agregado}");

        // Probar agregar libro al escáner de mapas para que falle
        agregado = escanerMapas + libro1;
        Console.WriteLine($"Intento de agregar libro 1 al escáner de mapas: {agregado}");

        // Probar agregar mapa al escáner de libros para que falle
        agregado = escanerLibros + mapa1;
        Console.WriteLine($"Intento de agregar mapa 1 al escáner de libros: {agregado}");

        // Mostrar documentos en estado "EnEscaner" para el escáner de libros
        Informes.MostrarEnEscaner(escanerLibros, out int extLibrosEnEscaner, out int cantLibrosEnEscaner, out string resLibrosEnEscaner);
        Console.WriteLine($"Libros en estado 'EnEscaner' en el escáner de libros:\n{resLibrosEnEscaner}\nTotal de extensión: {extLibrosEnEscaner}\nCantidad: {cantLibrosEnEscaner}");

        // Mostrar documentos en estado "EnEscaner" para el escáner de mapas
        Informes.MostrarEnEscaner(escanerMapas, out int extMapasEnEscaner, out int cantMapasEnEscaner, out string resMapasEnEscaner);
        Console.WriteLine($"Mapas en estado 'EnEscaner' en el escáner de mapas:\n{resMapasEnEscaner}\nTotal de extensión: {extMapasEnEscaner}\nCantidad: {cantMapasEnEscaner}");

        // Avanzar estado de los documentos
        libro1.AvanzarEstado();
        libro2.AvanzarEstado();
        mapa1.AvanzarEstado();
        mapa2.AvanzarEstado();

        // Mostrar documentos en estado "Distribuido" para el escáner de libros
        Informes.MostrarDistribuidos(escanerLibros, out int extLibrosDistribuidos, out int cantLibrosDistribuidos, out string resLibrosDistribuidos);
        Console.WriteLine($"Libros en estado 'Distribuido' en el escáner de libros:\n{resLibrosDistribuidos}\nTotal de extensión: {extLibrosDistribuidos}\nCantidad: {cantLibrosDistribuidos}");

        // Mostrar documentos en estado "Distribuido" para el escáner de mapas
        Informes.MostrarDistribuidos(escanerMapas, out int extMapasDistribuidos, out int cantMapasDistribuidos, out string resMapasDistribuidos);
        Console.WriteLine($"Mapas en estado 'Distribuido' en el escáner de mapas:\n{resMapasDistribuidos}\nTotal de extensión: {extMapasDistribuidos}\nCantidad: {cantMapasDistribuidos}");

        // Avanzar estado de los documentos nuevamente
        libro1.AvanzarEstado();
        libro2.AvanzarEstado();
        mapa1.AvanzarEstado();
        mapa2.AvanzarEstado();

        // Mostrar documentos en estado "Terminado" para el escáner de libros
        Informes.MostrarTerminados(escanerLibros, out int extLibrosTerminados, out int cantLibrosTerminados, out string resLibrosTerminados);
        Console.WriteLine($"Libros en estado 'Terminado' en el escáner de libros:\n{resLibrosTerminados}\nTotal de extensión: {extLibrosTerminados}\nCantidad: {cantLibrosTerminados}");

        // Mostrar documentos en estado "Terminado" para el escáner de mapas
        Informes.MostrarTerminados(escanerMapas, out int extMapasTerminados, out int cantMapasTerminados, out string resMapasTerminados);
        Console.WriteLine($"Mapas en estado 'Terminado' en el escáner de mapas:\n{resMapasTerminados}\nTotal de extensión: {extMapasTerminados}\nCantidad: {cantMapasTerminados}");
    }
}