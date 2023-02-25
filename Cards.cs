using System;

namespace Cards
{
    class Cards : ICards
    {
        public bool IsRemember { get; set; }
        public string Word { get; private set; }
        public string Translation { get; private set; }


        public Cards(string word,string translation)
        {
            IsRemember = false;
            Word = word;
            Translation = translation;
        }
        public bool PrintWord()
        {
            Console.WriteLine($"\nYour word -> {Word} \n If you remember word press Enter \n to open translate word press BackSpace \n To back Menu press Esc");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Backspace:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n\nYour word -> {Word} \n word translate -> {Translation}");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case ConsoleKey.Enter:
                    IsRemember = true;
                    break;
                case ConsoleKey.Escape:
                    return true;
            }
            return false;
        }
        
    }
}