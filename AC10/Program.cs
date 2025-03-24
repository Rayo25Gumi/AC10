// using System.Reflection.Metadata.Ecma335;
// using System.Runtime.InteropServices;

// internal class Program
// {
//     private static void Main(string[] args)
//     {
//         List<string> messages = new List<string>();
//         StreamWriter textmessages = new StreamWriter("messages.txt", true);
//         StreamReader readtextmessages = new StreamReader("messages.txt");
//         int option;
//         do
//         {
//             Console.WriteLine(
//                 "1: Añadir mensaje\n2: Listar usuarios\n3: Leer mensaje de usuario especifico\n4: Leer todos los mensajes\n5: Guardar mensajes en archivo txt\n6: Leer mensajes del archivo txt\n0: Salir"
//             );
//             option = Convert.ToInt32(Console.ReadLine());
//             switch (option)
//             {
//                 case 1:
//                     addMessage();
//                     break;
//                 case 2:
//                     listUsers();
//                     break;
//                 case 3:
//                     readMessageUser();
//                     break;
//                 case 4:
//                     readAllMessages();
//                     break;
//                 case 5:
//                     saveMessages();
//                     break;
//                 case 6:
//                     readSavedMessagses();
//                     break;
//                 case 0:
//                     Console.WriteLine("Saliendo...");
//                     break;
//                 default:
//                     Console.WriteLine("Opción no válida.");
//                     break;
//             }
//         } while (option != 0);
//         void addMessage()
//         {
//             Console.WriteLine("Escribe el usuario");
//             string user = Console.ReadLine();
//             Console.WriteLine("Escribe el asunto");
//             string subject = Console.ReadLine();
//             Console.WriteLine("Escribe el mensaje");
//             string content = Console.ReadLine();
//             string localmessage = $"{user};{subject};{content}";
//             messages.Add(localmessage);
//         }

//         void listUsers()
//         {
//             foreach (string message in messages)
//             {
//                 string[] part = message.Split(';');
//                 int i = 0;
//                 Console.WriteLine(part[i]);
//                 i++;
//             }
//         }

//         void readMessageUser()
//         {
//             Console.WriteLine("De que usuario quieres leer el mensaje?");
//             string user = Console.ReadLine();
//             foreach (string message in messages)
//             {
//                 string[] part = message.Split(';');
//                 if (part[0] == user)
//                 {
//                     Console.WriteLine(message);
//                 }
//             }
//         }

//         void readAllMessages()
//         {
//             foreach (string message in messages)
//             {
//                 Console.WriteLine(message);
//             }
//         }

//         void saveMessages()
//         {
//             foreach (string message in messages)
//             {
//                 File.WriteAllLines("messages.txt", messages);
//             }
//         }

//         void readSavedMessagses()
//         {
//             Console.WriteLine(File.ReadAllText("messages.txt"));
//         }
//     }
// }



// LIBRERIA
internal class Program
{
    static void Main()
    {
        List<string> libreria = new List<string>();
        string archivo = "libros.txt";
        StreamWriter textolibreria = new StreamWriter(archivo, true);
        int option;

        do
        {
            Console.WriteLine("1: Añadir libro\n2: Mostrar libros\n0: Salir");
            option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    nuevoLibro();
                    break;
                case 2:
                    leerLibro();
                    break;
                case 0:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (option != 0);

        void nuevoLibro()
        {
            string titulo,
                autor,
                isbn;

            do
            {
                Console.WriteLine("Título del libro: ");
                titulo = Console.ReadLine();
                Console.WriteLine("Autor del libro: ");
                autor = Console.ReadLine();
                Console.WriteLine("ISBN del libro: ");
                isbn = Console.ReadLine();
                libreria.Add($"{titulo};{autor};{isbn}");

                Console.WriteLine("¿Deseas agregar otro libro? (si/no)");
            } while (Console.ReadLine() == "si");

            foreach (string libro in libreria)
            {
                textolibreria.WriteLine(libro);
            }

            textolibreria.Close();
        }
        void leerLibro()
        {
            List<string> libros = new List<string>();
            StreamReader libreria = new StreamReader(archivo);
            string linea;

            while ((linea = libreria.ReadLine()) != null)
            {
                libros.Add(linea);
            }
            libreria.Close();

            libros.Sort(CompararLibros);

            foreach (string libro in libros)
            {
                string[] datosLibro = libro.Split(';');
                Console.WriteLine("Título: {0} ", datosLibro[0]);
                Console.WriteLine("Autor: {0}", datosLibro[1]);
                Console.WriteLine("isbn: {0}", datosLibro[2]);
            }
        }

        int CompararLibros(string libro1, string libro2)
        {
            string autor1 = libro1.Split(';')[1];
            string autor2 = libro2.Split(';')[1];
            return autor1.CompareTo(autor2);
        }
    }
}
