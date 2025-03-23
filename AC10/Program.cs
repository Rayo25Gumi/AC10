using System.Reflection.Metadata.Ecma335;

internal class Program
{
    private static void Main(string[] args)
    {
        List<string> messages = new List<string>();
        int i = 0;
        do
        {
            addMessage();
            listUsers();
            i++;
        } while (4 != i);
        do
        {
            readAllMessages();
            // readMessageUser();
            i++;
        } while (i != 8);
        void addMessage()
        {
            Console.WriteLine("Escribe el usuario");
            string user = Console.ReadLine();
            Console.WriteLine("Escribe el asunto");
            string subject = Console.ReadLine();
            Console.WriteLine("Escribe el mensaje");
            string content = Console.ReadLine();
            string localmessage = $"{user};{subject};{content}";
            messages.Add(localmessage);
        }
        void listUsers()
        {
            foreach (string message in messages)
            {
                string[] part = message.Split(';');
                int i = 0;
                Console.WriteLine(part[i]);
                i++;
            }
        }
        void readMessageUser()
        {
            Console.WriteLine("De que usuario quieres leer el mensaje?");
            string user = Console.ReadLine();
            foreach (string message in messages)
            {
                string[] part = message.Split(';');
                if (part[0] == user)
                {
                    Console.WriteLine(message);
                }
            }
        }
        void readAllMessages(){
            foreach(string message in messages){
                Console.WriteLine(message);
            }
        }
    }
}
