using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GestioneTask
{
    public class TaskManagement
    {
        public static string path { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Prova05Feb/Tasks.txt");

        //visualizzatore
        public static void visualize()
        {
            Task[] TaskToDo = GetTasksList();
            foreach (Task t in TaskToDo)
            {
                Console.WriteLine(t.Description + "  " + t.ExDate + "  " + t.Level);
            }
        }

        // Controllo i task presenti
        public static Task[] GetTasksList() // vettore di ritorno di tipi Task
        {
           

                int totalLines = File.ReadLines(path).Count();
                Task[] TasksList = new Task[totalLines - 1]; //
                string line;

                using (StreamReader read = File.OpenText(path))
                {
                    string Header = read.ReadLine();
                    while (!read.EndOfStream) // finchè non finisce di leggere
                    {
                        for (int i = 0; i < totalLines - 1; i++)
                        {
                            line = read.ReadLine();   // leggo riga
                            string[] TaskElement = line.Split(", ");
                            Task task = new Task
                            {
                                Description = TaskElement[0],
                                ExDate = Convert.ToDateTime(TaskElement[1]),
                                Level = TaskElement[2]
                            };

                            TasksList[i] = task;
                        }

                    }
                }

                return TasksList;
            
        }

        //Aggiungere Task
        public static void AddTask(Task NewTask)
        {
            // controllo se esiste gia un task con quelle info -> se esite gia informo l'utente
            Task[] TasksList = GetTasksList();

            try
            {
                for (int i = 0; i < TasksList.Length; i++)
                {
                    if ((TasksList[i].Description == NewTask.Description) && (TasksList[i].ExDate == NewTask.ExDate) && (TasksList[i].Level == NewTask.Level))
                    {
                        Console.WriteLine("Task already existing!!");
                    }
                    else
                    {
                        using (StreamWriter write = File.AppendText(path))
                        {
                            write.WriteLine(NewTask.Description + ", " + NewTask.ExDate + ",  " + NewTask.Level);
                        }



                    }


                }
                Console.WriteLine("Task Added!");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        //filtro per priorità
        public static Task[] Priority(string Priority)
        {
            Task[] TasksList = GetTasksList();
            ArrayList FilteredTask = new ArrayList();

            for (int i = 0; i < TasksList.Length; i++)
            {

                string Level = TasksList[i].Level;
                if (String.Equals(Level, Priority))
                {

                    FilteredTask.Add(TasksList[i]);

                }

            }
            return (Task[])FilteredTask.ToArray(typeof(Task));
        }


        //Elimino task
        public static void RemoveTask(String ToRemove)
        {

            Task[] TasksList = GetTasksList();
            Task[] TasksListUpdated = new Task[TasksList.Length - 1];

            for (int i = 0; i < TasksList.Length; i++)
            {
                if ((TasksList[i].Description != ToRemove))
                {
                    for (int j = 0; j < i; j++)
                    {
                        TasksListUpdated[j] = TasksList[i];
                    }


                    using (StreamWriter write = File.CreateText(path))
                    {
                        write.WriteLine(" Descrizione, DataScadenza, Livello Priorità");
                        foreach (Task t in TasksListUpdated)
                        {
                            write.WriteLine(t.Description + "  " + t.ExDate + "  " + t.Level);
                        }
                        Console.WriteLine("Eliminato correttamente!");
                    }

                }
            }






        }
    }
}
