using System;
using System.Collections.Generic;
using System.Text;
using Lab13Ex.Exceptions;

namespace Lab13Ex.Bank
{
    class ContBancar
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public double SoldCurent { get; private set; } = 0;
        public Card card = null;



        public void DepuneNumerar(int deDepus)
        {
            
            this.SoldCurent += deDepus;
        }

        public void ExtrageNumerar(int deExtras)
        {
            if (SoldCurent<deExtras)
            {
                throw new PoorException();
            }
            else
            {
                this.SoldCurent -= deExtras;
            }
        }

        public  Guid DetaliiCont()
        {
            return this.Id;
        }

    }
}
