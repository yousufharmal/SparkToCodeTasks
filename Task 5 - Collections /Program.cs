namespace Task_5___Collections;

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        
        // Task 1 - Fixed Grades Array ///
        /*
        int[] grades = new int[5];

        
        for (int i = 0; i < grades.Length; i++)
        {
            Console.Write("Enter grade " + (i + 1) + ": ");
            grades[i] = Convert.ToInt32(Console.ReadLine());
        }

        
        Console.WriteLine("\nStudent Grades:");
        foreach (int grade in grades)
        {
            Console.WriteLine(grade);
        }
        
        
        
        // Task 2 - Dynamic To-Do List ///
        
        List<string> todoList = new List<string>();

        
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Enter task {i + 1}: ");
            string task = Console.ReadLine();

            
            todoList.Add(task);
        }

       
        Console.WriteLine("\nTo-Do List:");
        int taskNumber = 1;

        foreach (string task in todoList)
        {
            Console.WriteLine($"{taskNumber}. {task}");
            taskNumber++;
        }
        
        */
        
        // Task 3 - Browsing History Stack ///
        
        Stack<string> history = new Stack<string>();

        
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Enter website URL {i + 1}: ");
            string url = Console.ReadLine();

            
            history.Push(url);
        }

        
        string closedPage = history.Pop();

        Console.WriteLine($"\nYou left: {closedPage}");

        if (history.Count > 0)
        {
            Console.WriteLine($"You are now on: {history.Peek()}");
        }
        else
        {
            Console.WriteLine("No pages left in the browser history.");
        }
    }
}