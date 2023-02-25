using System.Collections.Generic;

namespace Cards
{
    class Deck: IDeck
    {
        public string NameDeck { get; set; }
        public List<Cards> _cardsList { get; set; }

        public Deck(string _nameDeck,List<Cards> cards)
        {
            NameDeck = _nameDeck;
            _cardsList = cards;
        }

        public void OpenCards()
        {
            var stop = false;
            for (int i = 0; i < _cardsList.Count; i++)
            {
                if (!_cardsList[i].IsRemember && !stop)
                {
                    stop = _cardsList[i].PrintWord();
                }
            }

        }
        public void WriteCard(string word, string translate)
        {
            _cardsList.Add(new Cards(word, translate));
        }

    }
}