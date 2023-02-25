using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            GameOperator game = new GameOperator();
            while (true)
            {
                Console.WriteLine("\n\nВыберите действие: \n 1. Посмотреть прогресс \n 2. Выбрать колоду \n 3. Создать колоду \n 4. Exit game ");
                string action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        Progress.PrintProgress();
                        break;
                    case "2":
                        SeeDeck(game);
                        break;
                    case "3":
                        CreatDeck(game);
                        break;
                    case "4":
                        game.Save();
                        return;
                    default:
                        Console.WriteLine("Oooops");
                        break;
                }
            }


        }
        private static void SeeDeck(GameOperator game)
        {
            Console.WriteLine($"Select a deck :\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"in order to select a deck ,enter one of the available values into the console\n");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var _deck in game.Decks)
            {
                Console.WriteLine($"{_deck.Key} \n");

            }
            string deck_selection = Console.ReadLine();

            if (game.Decks.ContainsKey(deck_selection))
            {
                game.OpenDeck(deck_selection);
            }
        }
        private static void CreatDeck(GameOperator game)
        {
            Console.WriteLine($"Write Deck Name :\n");
            string deck = Console.ReadLine();
            game.DeckCreate(deck);
            while (true)
            {
                Console.WriteLine($"Add card press Enter\nBack to Menu press Esc");
                if (Console.ReadKey().Key == ConsoleKey.Escape) break;
                else
                {
                    Console.WriteLine($"Write Word:\n");
                    var word = Console.ReadLine();
                    Console.WriteLine($"Write Translate:\n");
                    var trns = Console.ReadLine();
                    game.CardCreate(word, trns);
                }

            }
        }
    }
}
