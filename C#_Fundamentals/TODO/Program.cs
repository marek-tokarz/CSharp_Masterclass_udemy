using System;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    private static void Main(string[] args)
    {
        var todos = new List<string>();

        Console.WriteLine("Hello");

        bool shallExit = false;
        while (!shallExit)
        {
            Console.WriteLine();
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("[S]ee all TODOs");
            Console.WriteLine("[A]dd a TODO");
            Console.WriteLine("[R]emove a TODO");
            Console.WriteLine("[E]xit");

            var userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "E":
                case "e":
                    shallExit = true;
                    Console.WriteLine("Exit");
                    break;
                case "S":
                case "s":
                    SeeAllTodos();
                    break;
                case "A":
                case "a":
                    AddTodo();
                    break;
                case "R":
                case "r":
                    RemoveTodo();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

        Console.ReadKey();

        void SeeAllTodos()
        {
            if (todos.Count == 0)
            {
                ShowNoTodosMessage();
                return;
            }
            for (int i = 0; i < todos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {todos[i]} ");
            }
        }

        void AddTodo()
        {
            string description;
            do
            {
                Console.WriteLine("Enter the TODO description");
                description = Console.ReadLine();
            }
            while (!IsDescriptionValid(description));

            Console.WriteLine($"TODO added {description}");
            todos.Add(description);
        }

        bool IsDescriptionValid(string description)
        {
            if (description == "")
            {
                Console.WriteLine("The description cannot be empty");
                return false;
            }
            if (todos.Contains(description))
            {
                Console.WriteLine("The description must be unique.");
                return false;
            }
            return true;
        }

        void RemoveTodo()
        {
            if (todos.Count == 0)
            {
                ShowNoTodosMessage();
                return;
            }

            int index;
            do
            {
                Console.WriteLine("Select the index of the TODO you want to remove");
                SeeAllTodos();
            } while (!TryReadIndex(out index));

            RemoveTodoAtIndex(index - 1);
        }

        bool TryReadIndex(out int index)
        {
            var userInput = Console.ReadLine();
            if (userInput == "")
            {
                index = 0;
                Console.WriteLine("Selected index can not be empty");
                return false;
            }
            if (int.TryParse(userInput, out index) && index >= 1 && index <= todos.Count)
            {
                return true;
            }
            Console.WriteLine("The given index is not valid.");
            return false;
        }

        void ShowNoTodosMessage()
        {
            Console.WriteLine("No TODOs have been added yet");
        }

        void RemoveTodoAtIndex(int index)
        {
            var todoToBeRemoved = todos[index];
            todos.RemoveAt(index);
            Console.WriteLine("TODO removed: " + todoToBeRemoved);
        }
    }
}

// CHANGING VARIABLE NAME: Ctrl + R + R

// Commenting multiple lines: Ctrl + K + C

// Writing in multiple lines: Alt + mouse arrow

// bool isUserInputAbc = userChoice == "ABC";
// boll isUserInputNotAbc = userChoice != "ABC";

// cw + Tab + Tab = Console.WriteLine();

/* Parsing a strint to an int
Console.WriteLine("Provide a number");
string userInput = Console.ReadLine();
int number = int.Parse(userInput);
Console.WriteLine("number is: ",number);
*/

/* String interpolation 
int a = 4, b = 5, c = 6;
Console.WriteLine($"First is {a}, second is {b}, third is {c}");
*/

/* Switch expressions 
char ConvertPointsToGrade(int points)
{
    return points switch
    {
        10 or 9 => 'A',
        8 or 7 or 6 => 'B',
        5 or 4 or 3 => 'C',
        2 or 1 => 'D',
        0 => 'E',
        _ => '!',
    };
*/

/*Checking if a string is parsable to an int
 * bool isParsableToInt = userInput.All(char.IsDigit);
 */

/* PREVIOUS VERSION
  
   var todos = new List<string>();

        Console.WriteLine("Hello");

        bool shallExit = false;
        while (!shallExit)
        {
            Console.WriteLine();
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("[S]ee all TODOs");
            Console.WriteLine("[A]dd a TODO");
            Console.WriteLine("[R]emove a TODO");
            Console.WriteLine("[E]xit");

            var userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "E":
                case "e":
                    shallExit = true;
                    Console.WriteLine("Exit");
                    break;
                case "S":
                case "s":
                    SeeAllTodos();
                    break;
                case "A":
                case "a":
                    AddTodo();
                    break;
                case "R":
                case "r":
                    RemoveTodo();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
        Console.ReadKey();

        void AddTodo()
        {
            bool isValidDescription = false;
            while (!isValidDescription)
            {
                Console.WriteLine("Enter the TODO description");
                var description = Console.ReadLine();

                if (description == "")
                {
                    Console.WriteLine("The description cannot be empty");
                }
                else if (todos.Contains(description))
                {
                    Console.WriteLine("The description must be unique.");
                }
                else
                {
                    todos.Add(description);
                    isValidDescription = true;
                }
            }
        }

        void SeeAllTodos()
        { 
            if(todos.Count == 0)
            {
                Console.WriteLine("No TODOs have been added yet");
            }
            else
            {
                for(int i = 0; i<todos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {todos[i]} ");
                }
            }
        }

        void RemoveTodo()
        {
            if(todos.Count == 0)
            {
                Console.WriteLine("No TODOs have been added yet");
                return;
            }
            bool isIndexValid = false;
            while (!isIndexValid)
            {
                Console.WriteLine("Select the index of the TODO you want to remove");
                SeeAllTodos();
                var userInput = Console.ReadLine();
                if(userInput == "")
                {
                    Console.WriteLine("Selected index can not be empty");
                    continue;
                }
                if(int.TryParse(userInput, out int index) &&
                    index >= 1 &&
                    index <= todos.Count)
                {
                    var indexOfTodo = index - 1;
                    var todoToBeRemoved = todos[indexOfTodo];
                    todos.RemoveAt(indexOfTodo);
                    isIndexValid = true;
                    Console.WriteLine("TODO removed: " + todoToBeRemoved);
                }
                else
                {
                    Console.WriteLine("The given index is not valid.");
                }
            }

        }
        
*/