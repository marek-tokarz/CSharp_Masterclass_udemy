using System;
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
        bool exitChoosed = true;

        List<string> TODOs = new List<string>();

        string todo;

        while (exitChoosed)
        {
            Console.WriteLine();
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("[S]ee all TODOs");
            Console.WriteLine("[A]dd a TODO");
            Console.WriteLine("[R]emove a TODO");
            Console.WriteLine("[E]xit");

            string userChoice = Console.ReadLine();

            List<string> options = new List<string>() { "S", "s", "A", "a", "R", "r", "E", "e" };

            if(!options.Contains(userChoice))
            {
                Console.WriteLine("Incorrect input");
                continue;
            }

            switch (userChoice)
            {
                case "s":
                case "S":
                    ListingTodos();
                    break;
                case "A":
                case "a":
                    PrintSelectedOption("Add a TODO");
                    bool todoExistsOrEmpty = true;
                    while(todoExistsOrEmpty)
                    {
                        Console.WriteLine("Type a TODO to the list");
                        todo = Console.ReadLine();
                        if (todo == "")
                        {
                            Console.WriteLine("The description cannot be empty");
                            continue;
                        }
                        else if (TODOs.Contains(todo))
                        {
                            Console.WriteLine("This todo already exists, add another one, description must be unique");
                            continue;
                        }
                        else
                        {
                            TODOs.Add(todo);
                            todoExistsOrEmpty = false;
                        }
                    }
                    break;
                case "R":
                case "r":
                    PrintSelectedOption("Remove a TODO");
                    bool isParsingSuccessful = true;
                    int number;
                    do
                    {
                        if (TODOs.Count == 0)
                        {
                            Console.WriteLine("No TODOs have been added yet");
                            break;
                        }
                        ListingTodos();
                        Console.WriteLine("Enter a number of a choosen TODO");
                        var userInput = Console.ReadLine();
                        if (userInput == "")
                        {
                            Console.WriteLine("Selected index cannot be empty");
                            isParsingSuccessful = false;
                            continue;
                        }
                        isParsingSuccessful = int.TryParse(
                            userInput, out number);
                        if(isParsingSuccessful)
                        {
                            Console.WriteLine("You have choose: " + number);
                            if(number > TODOs.Count)
                            {
                                Console.WriteLine("The given index is not valid - out of range");
                                isParsingSuccessful = false; // in order not to finish the loop
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("TODO removed: " + TODOs[number-1]);
                                TODOs.RemoveAt(number-1);
                            }  
                        }
                        else
                        {
                            Console.WriteLine("The given index is not valid");
                        }
                    } while (!isParsingSuccessful);
                    break;
                case "E":
                case "e":
                    PrintSelectedOption("Exit");
                    exitChoosed = false;
                    break;
                default:
                    Console.WriteLine("Invalid statement");
                    break;
            }
        }

        Console.ReadKey();

        void PrintSelectedOption(string selectedOption)
        {
            Console.WriteLine("Selected option: " + selectedOption);
        }

        void ListingTodos()
        {
            if (TODOs.Count == 0)
            {
                Console.WriteLine("The list of TODOs is empty.");
            }
            else
            {
                PrintSelectedOption("See all TODOs");
                int i = 1;
                foreach (var todoInLoop in TODOs)
                {
                    Console.WriteLine(i + ". " + todoInLoop);
                    i++;
                }
            }
        }
    }
*/