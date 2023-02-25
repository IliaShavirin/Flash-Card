using System.Collections.Generic;

namespace Cards
{
    interface IDeck
    {
        void OpenCards();
        void WriteCard(string word, string translate);
        string NameDeck { get; set; }
        List<Cards> _cardsList { get; set; }
    }
}