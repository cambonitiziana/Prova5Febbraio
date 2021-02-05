using System;

namespace GestioneTask
{
    class Program
    {
        static void Main(string[] args)
        {



            Console.WriteLine("Benvenuto nell'applicazione Task Managment!");
            Inserimento:
            Console.WriteLine("Premi V per visualizzare i task presenti \nPremi A per aggiungere un nuovo Task \nPremi D per rimuovere un task\nPremi F se vuoi filtrare i task per priorità ");
            String Letter = Console.ReadLine();

            if (Letter == "v")
            {
                TaskManagement.visualize();
            }
            else if (Letter == "a")
            {
                // creo un nuovo oggetto Task e inserisco i campi 
                Task New = new Task();
                Console.WriteLine("inserisci la descrizione");
                New.Description = Console.ReadLine();

                Console.WriteLine("Inserisci la data di scadenza in formato dd/mm/yy");
                var Date = Convert.ToDateTime(Console.ReadLine());

                var Today = DateTime.Today; // Aggiungere controllo sulla data
                New.ExDate = Date.Date;
                Console.WriteLine("Inserisci il livello di priorità; inserire Basso, Medio, Alto");
                New.Level = Console.ReadLine();

                //richiamo funzione di aggiunta aggetto
                TaskManagement.AddTask(New);
                Console.WriteLine("La lista aggiornata è:");
            }
            else if (Letter == "d")
            {
                Console.WriteLine("Inserisci la descrizione del task che vuoi eliminare:");
                String TaskToRemove = Console.ReadLine();
                //richiama funzione per eliminare l'oggetto
                TaskManagement.RemoveTask(TaskToRemove);
            }
            else if (Letter == "f")
            {
                Console.WriteLine("Inserisci il livello di priorità per cui vuoi filtrare i task; inserire Basso, Medio, Alto");
                String TaskToFilt = Console.ReadLine();
                Task[] Filtered = (TaskManagement.Priority(TaskToFilt));
                foreach (Task t in Filtered)
                {
                    Console.WriteLine(t.Description + "  " + t.ExDate + "  " + t.Level);
                }

            }
            else 
            {
                Console.WriteLine("Inserimento non valido");
                goto Inserimento;

            }
        }
        
        
    }
}
