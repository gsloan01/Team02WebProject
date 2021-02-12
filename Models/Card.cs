using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MTGDeckBuilder.Models
{
    public class Card
    {
        public enum eKeyword
        { }
        public enum eType
        { }
        public enum eColor
        { }


        string Name;
        int CMC;
        List<eColor> Colors;
        int Power;
        int Toughness;
        List<eKeyword> keywords;
        string SetReleased;
        string Rarity;
        bool isLegal;
        string CardText;



    }
}