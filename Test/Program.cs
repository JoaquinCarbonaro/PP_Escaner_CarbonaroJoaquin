using System;
using Entidades;

class Program
{
    static void Main()
    {
        int totalPaginas; //extension
        int totalDocumentos; //cantidad
        string resumen; //resumen


        //Instancia escaner LIBRO
        Escaner escanerLibros = new Escaner("Canon", Escaner.TipoDoc.libro);

        // Instancia de LIBRO
        Libro book1 = new Libro("Ficción", "Mary Shelley", 2019, "101-a", "9781111111111", 500);
        Libro book2 = new Libro("Educación Financiera", "Susan Lee", 2021, "102-b", "9782222222222", 450);
        Libro book3 = new Libro("Crecimiento Personal", "Michael King", 2005, "103-c", "9783333333333", 330);
        Libro book4 = new Libro("Aventura", "James Bond", 2008, "104-d", "9784444444444", 375);
        Libro book5 = new Libro("Clásicos", "Jane Austen", 2013, "105-e", "9785555555555", 280);
        Libro book6 = new Libro("Historia", "John Doe", 1996, "106-f", "9786666666666", 420);
        // PRUEBA: Repetido de book6
        Libro book7 = new Libro("Historia", "John Doe", 1996, "106-f", "9786666666666", 420); // Repetido de 
        Libro book8 = new Libro("Mitología", "Emily Clark", 2017, "107-g", "9787777777777", 510);

        Libro book9 = new Libro("Mitología", "Emily Clark", 2008, "108-h", "9788888888888", 375); // Repetido de book4

        //PRUEBA: no deben cargarse, estado dif. INICIO
        // Estado distribuido
        Libro book10 = new Libro("Fantasía", "Peter Pan", 1995, "109-i", "9789999999999", 350);
        book10.AvanzarEstado();

        // Estado en revisión
        Libro book11 = new Libro("Ciencia Ficción", "Isaac Asimov", 1990, "110-j", "9781010101010", 540);
        book11.AvanzarEstado();
        book11.AvanzarEstado();


        Console.WriteLine("++++++++++++++++++++++++++++++++");


        //PRUEBA: Carga de libros (scanner libro)
        Console.WriteLine(escanerLibros + book1);
        Console.WriteLine(escanerLibros + book2);
        Console.WriteLine(escanerLibros + book3);
        Console.WriteLine(escanerLibros + book4);
        Console.WriteLine(escanerLibros + book5);
        Console.WriteLine(escanerLibros + book6);
        Console.WriteLine(escanerLibros + book7); // No debe cargar, return false
        Console.WriteLine(escanerLibros + book8);
        Console.WriteLine(escanerLibros + book9); // No debe cargar, return false
        Console.WriteLine(escanerLibros + book10); // No debe cargar, estado no está en INICIO
        Console.WriteLine(escanerLibros + book11); // No debe cargar, estado no está en INICIO


        //PRUEBA: Cambio de Estado de Documentos:
        escanerLibros.CambiarEstadoDocumento(book1);

        escanerLibros.CambiarEstadoDocumento(book2);
        escanerLibros.CambiarEstadoDocumento(book2);

        escanerLibros.CambiarEstadoDocumento(book3);
        escanerLibros.CambiarEstadoDocumento(book3);
        escanerLibros.CambiarEstadoDocumento(book3);
        escanerLibros.CambiarEstadoDocumento(book3);
        escanerLibros.CambiarEstadoDocumento(book3);


        Console.WriteLine("++++++++++++++++++++++++++++++++");


        // PRUEBA: Generación de Informes para Libros: DISTRIBUIDOS
        Informes.MostrarDistribuidos(escanerLibros, out totalPaginas, out totalDocumentos, out resumen);
        Console.WriteLine($"Cantidad de páginas: {totalPaginas}");
        Console.WriteLine($"Cantidad de documentos: {totalDocumentos} \n");
        Console.WriteLine(resumen);

        Console.WriteLine("++++++++++++++++++++++++++++++++");

        // PRUEBA: Generación de Informes para Libros: ESCANER
        Informes.MostrarEnEscaner(escanerLibros, out totalPaginas, out totalDocumentos, out resumen);
        Console.WriteLine($"Cantidad de páginas: {totalPaginas}");
        Console.WriteLine($"Cantidad de documentos: {totalDocumentos}\n");
        Console.WriteLine(resumen);

        Console.WriteLine("++++++++++++++++++++++++++++++++");

        // PRUEBA: Generación de Informes para Libros: REVISION
        Informes.MostrarEnRevision(escanerLibros, out totalPaginas, out totalDocumentos, out resumen);
        Console.WriteLine($"Cantidad de páginas: {totalPaginas}");
        Console.WriteLine($"Cantidad de documentos: {totalDocumentos} \n");
        Console.WriteLine(resumen);

        Console.WriteLine("++++++++++++++++++++++++++++++++");

        // PRUEBA: Generación de Informes para Libros: TERMINADOS
        Informes.MostrarTerminados(escanerLibros, out totalPaginas, out totalDocumentos, out resumen);
        Console.WriteLine($"Cantidad de páginas: {totalPaginas}");
        Console.WriteLine($"Cantidad de documentos: {totalDocumentos}\n");
        Console.WriteLine(resumen);


        Console.WriteLine("++++++++++++++++++++++++++++++++");

        //Instancia escaner MAPA
        Escaner escanerMapas = new Escaner("HP", Escaner.TipoDoc.mapa);

        // Instancia de MAPA
        Mapa map1 = new Mapa("Nueva York", "Alice Johnson", 2015, "", "1234-5678", 55, 15);
        Mapa map2 = new Mapa("California", "Bob Smith", 2001, "", "8765-4321", 60, 50);
        Mapa map3 = new Mapa("Florida", "Charles Brown", 1998, "", "4321-8765", 45, 90);
        // PRUEBA: Repetido de map3
        Mapa map6 = new Mapa("Florida", "Charles Brown", 1998, "", "4321-8765", 45, 50);
        Mapa map4 = new Mapa("Texas", "Diana White", 2020, "", "5678-1234", 95, 110);
        // PRUEBA: Repetido de map4
        Mapa map5 = new Mapa("Texas", "Diana White", 2020, "", "9999-8888", 95, 110);
        Mapa map7 = new Mapa("Nevada", "Edward Black", 2021, "", "8888-7777", 120, 210);


        Console.WriteLine("++++++++++++++++++++++++++++++++");

        //Verificación de Carga Incorrecta:

        // PRUEBA: libro en el scanner de mapas 
        Console.WriteLine(escanerMapas + book1);

        // PRUEBA: mapa en el scanner de libros
        Console.WriteLine(escanerLibros + map1);

        Console.WriteLine("++++++++++++++++++++++++++++++++");

        //PRUEBA: Carga de mapas (scanner mapas)
        Console.WriteLine(escanerMapas + map1);
        Console.WriteLine(escanerMapas + map2);
        Console.WriteLine(escanerMapas + map3);
        Console.WriteLine(escanerMapas + map4);
        Console.WriteLine(escanerMapas + map5); // No debe cargar, return false
        Console.WriteLine(escanerMapas + map6); // No debe cargar, return false
        Console.WriteLine(escanerMapas + map7);


        //PRUEBA: Cambio de Estado de Documentos:
        escanerMapas.CambiarEstadoDocumento(map2);

        escanerMapas.CambiarEstadoDocumento(map3);
        escanerMapas.CambiarEstadoDocumento(map3);

        escanerMapas.CambiarEstadoDocumento(map4);
        escanerMapas.CambiarEstadoDocumento(map4);
        escanerMapas.CambiarEstadoDocumento(map4);

        escanerMapas.CambiarEstadoDocumento(map7);
        escanerMapas.CambiarEstadoDocumento(map7);
        escanerMapas.CambiarEstadoDocumento(map7);
        escanerMapas.CambiarEstadoDocumento(map7);
        escanerMapas.CambiarEstadoDocumento(map7);


        Console.WriteLine("++++++++++++++++++++++++++++++++");


        // PRUEBA: Generación de Informes para mapas: DISTRIBUIDOS
        Informes.MostrarDistribuidos(escanerMapas, out totalPaginas, out totalDocumentos, out resumen);
        Console.WriteLine($"Total de superficie: {totalPaginas}");
        Console.WriteLine($"Cantidad de documentos: {totalDocumentos}\n");
        Console.WriteLine(resumen);

        Console.WriteLine("++++++++++++++++++++++++++++++++");

        // PRUEBA: Generación de Informes para mapas: ESCANER
        Informes.MostrarEnEscaner(escanerMapas, out totalPaginas, out totalDocumentos, out resumen);
        Console.WriteLine($"Total de superficie: {totalPaginas}");
        Console.WriteLine($"Cantidad de documentos: {totalDocumentos}\n");
        Console.WriteLine(resumen);

        Console.WriteLine("++++++++++++++++++++++++++++++++");

        // PRUEBA: Generación de Informes para mapas: REVISION
        Informes.MostrarEnRevision(escanerMapas, out totalPaginas, out totalDocumentos, out resumen);
        Console.WriteLine($"Total de superficie: {totalPaginas}");
        Console.WriteLine($"Cantidad de documentos: {totalDocumentos} \n");
        Console.WriteLine(resumen);

        Console.WriteLine("++++++++++++++++++++++++++++++++");

        // PRUEBA: Generación de Informes para mapas: TERMINADOS
        Informes.MostrarTerminados(escanerMapas, out totalPaginas, out totalDocumentos, out resumen);
        Console.WriteLine($"Total de superficie: {totalPaginas}");
        Console.WriteLine($"Cantidad de documentos: {totalDocumentos}\n");
        Console.WriteLine(resumen);

    }
}