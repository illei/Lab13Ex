using Lab13Ex.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab13Ex.Bank
{
    class Banca
    {
        public IDictionary<Guid, ContBancar> ConturiBancare = new Dictionary<Guid, ContBancar>();

        public Guid CreazaContBancar()
        {
            //Cream un cont 
            ContBancar cont = new ContBancar();
           
            AdaugaCont(cont);
            //returnam detalii cont 
            return cont.DetaliiCont();
        }
        //Adaugam cont 
        private void AdaugaCont(ContBancar cont)
        {
            ConturiBancare.Add(cont.Id, cont);
        }

        public Card EmiteCard(Guid id)
        {
            Card card = null;
            //Verificam daca exsista acest cont 
            if (!(ConturiBancare.ContainsKey(id)))
            {
                throw new DosentExistException();
            }
            //verificam daca sa mai emis alt card pt acest cont 
            else if (!(ConturiBancare[id].card==null))
            {
                throw new AlreadyExistException();
            }

            //emitem card
            else
            {
                card = new Card();
                card.Id = id;
                ConturiBancare[id].card = card;
            }

            return card;
        }
        public void Plateste(int dePlatit,Guid id)
        {
            if (ConturiBancare.ContainsKey(id))
            {


                ConturiBancare[id].ExtrageNumerar(dePlatit);

            }
            else
            {
                throw new DosentExistException();
            } 
                
        }


    }
}
