using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Cards
{
    class GameOperator
    {
        private Deck _currentDeck;
        public Dictionary<string, Deck> Decks;
        public string path;
        
        public GameOperator() 
        {
            path= Path.Combine(Directory.GetCurrentDirectory(),"Decks.json");
            
            if (CheckSaveDeck(path))
            {
                var decks =  File.ReadAllText(path);
                Decks = JsonConvert.DeserializeObject<Dictionary<string, Deck>>(decks);
            }
            else
            {
                DefoltDeckCreate();
            }

        }
        public void Save()
        {
            var _deck = JsonConvert.SerializeObject(Decks,Formatting.Indented);
            File.WriteAllText(path, _deck);
            Console.WriteLine(path);

        }
        public void OpenDeck(string deckName)
        {
            _currentDeck = Decks[deckName];
            _currentDeck.OpenCards();

        }

        private bool CheckSaveDeck(string path)
        {
            return File.Exists(path);
        }

        private void DefoltDeckCreate()
        {
            Decks = new Dictionary<string, Deck>();
            var animals = new List<Cards>();
            animals.Add(new Cards("Cat","Кот"));
            animals.Add(new Cards("Собака","Dog"));
            animals.Add(new Cards("Енот","Racoon"));
            Decks.Add("Animals",new Deck("Animals",animals));
            
            var professions = new List<Cards>();
            professions.Add(new Cards("Машинист","Driver"));
            professions.Add(new Cards("Повар","Cook"));
            professions.Add(new Cards("Продавец","Salesman"));
            Decks.Add("Professions",new Deck("Professions",professions));
            
            var sport = new List<Cards>();
            sport.Add(new Cards("Вратарь","Goalkeeper"));
            sport.Add(new Cards("Нарушение","Violation"));
            sport.Add(new Cards("Мяч","Ball"));
            Decks.Add("Sport",new Deck("Sport",sport));
        }
        public void DeckCreate(string NameDeck)
        {
            if (!Decks.ContainsKey(NameDeck) && Decks!=null)
            {
                Decks.Add(NameDeck, new Deck(NameDeck,new List<Cards>()));
                _currentDeck = Decks[NameDeck];
            }
        }
        public void CardCreate(string word,string translate)
        {
            _currentDeck.WriteCard(word, translate);
        }
    }
}