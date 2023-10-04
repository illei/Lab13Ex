using System;
using System.Collections.Generic;
using System.Text;

namespace Lab13Ex.Bank
{
    class Card
    {
        public Guid Id;
        public void IntroduCard()
        {
            Console.WriteLine("A-ti introdus cardul");
        }

        public Guid GetCardData()
        {
            return Id;
        }

        public void ExtrageCard()
        {
            Console.WriteLine($"Cardul a fost extras");
        }



       
    }
}
