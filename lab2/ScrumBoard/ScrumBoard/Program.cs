﻿using ScrumBoard.ScrumBoard.Column;
using ScrumBoard.ScrumBoard.Task;
using Task = ScrumBoard.ScrumBoard.Task.Task;

namespace ScrumBoard
{
    class Program
    {
        public static void Main()
        {
            try
            {
                IColumn firstColumn = new Column("In progress");
                ITask task = new Task("asd", "asd", 1);
                ITask task2 = new Task("asd", "asd", 4);
                Console.WriteLine(task.Name + ' ' + task.Description + ' ' + task.Priority + ' ' + task.UUID);

                firstColumn.AddTask(task);
                firstColumn.AddTask(task2);
                Console.WriteLine(firstColumn.GetTask(task.UUID)?.Name + ' ' + firstColumn.GetTask(task.UUID)?.Description);
                Console.WriteLine(firstColumn.GetAllTaskUUIDs()[0] + ' ' + firstColumn.GetAllTaskUUIDs()[1]);
                firstColumn.RemoveTask(task2.UUID);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
