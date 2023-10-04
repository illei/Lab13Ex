using System;
using System.Collections.Generic;
using System.Text;
using Lab13Ex.Bank;
using Lab13Ex.Exceptions;

namespace Lab13Ex.MetodeDePlata
{
    class PoS
    {
        public Banca banca;
        public PoS(Banca banca)
        {
            this.banca = banca;
        }
        public void Plateste(int dePlatit,Card card)
        {
            card.IntroduCard();
            Guid idCont=card.GetCardData();
            banca.Plateste(dePlatit, idCont);
            card.ExtrageCard();

            
        }
    }
}
