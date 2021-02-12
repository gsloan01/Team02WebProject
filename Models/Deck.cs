using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MTGDeckBuilder.Models
{
    public class Deck
    {
        enum eFormat
        { }
        string Name;
        int Size;
        List<Card.eColor> ColorCombo;
        List<Card> cards;
        bool hasSideboard;
        List<Card> sideboard;

    }
}