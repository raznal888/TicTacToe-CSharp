using System;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    internal class UserInterface
    {
        private Match _current;

        internal UserInterface() => _current = null;

        internal void Start()
        {
            bool gameRunning = true;

            while (gameRunning) 
            {
                string command = EnterCommand();

                if (command.Equals("exit")) {
                    gameRunning = false;
                    return;
                }

                string[] commandParts = command.Split(" ");
                string firstPlayer = commandParts[1];
                string secondPlayer = commandParts[2];

                _current = new Match(Player.Of(firstPlayer), Player.Of(secondPlayer));

                _current.Play();
                Console.WriteLine();
            }
        }
        
        private static string EnterCommand() 
        {
            string command = string.Empty;

            bool commandNotValid = true;
            while (commandNotValid) 
            {
                Console.Write("Input command: ");

                command = Console.ReadLine();

                if (!Regex.IsMatch(command,"(start\\s(easy|user|medium|hard)\\s(easy|user|medium|hard))|exit")) 
                {
                    Console.WriteLine("Bad parameters!");
                    continue;
                }
                commandNotValid = false;
            }

            return command;
        }
    }
}