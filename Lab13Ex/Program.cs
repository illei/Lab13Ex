using System;
using Lab13Ex.Bank;
using Lab13Ex.Exceptions;
using Lab13Ex.MetodeDePlata;
namespace Lab13Ex
{

    /*Scrieti un program care va modela operatiunile unui POS.
Contul bancar
Va avea un ID de tip Guid
Va avea o metoda DepuneNumerar
Va avea o metoda ExtrageNumerar
• Va avea ca parametru suma ce se doreste a fi extrasa
• In cazul in care suma nu este disponibila, contul bancar va arunca o exceptie
• Va fi folosita la de Banca atunci cand vor fi efectuate plati
Banca
Va avea o lista de conturi curente indexate intr-un dictionar in functie de id-ul (Guid) acestora.
Va avea o metoda „CreeazaCont” care
• Va creea un nou cont bancar
• Il va adauga in lista conturilor
• Va returna id-ul contului
Va avea o metoda „EmiteCard” care va primi ca parametru id-ul contului
• In cazul in care contul nu exista va arunca o exceptie corespunzatoare
• In cazul in care au fost emise deja 2 carduri pentru acel cont va arunca o exceptie.
• Cardul emis va primi id-ul contului.
Va avea o metoda „Plateste” care va primi 2 parametri: suma si id-ul contului.
• In cazul in care contul nu exista va arunca o exceptie corespunzatoare
Card-ul
Va avea 3 metode:
 IntroduCard
 Va afisa pe ecran un mesaj
 GetCardData
 Returneaza id-ul contului
 ExtrageCard
 Va afisa pe ecran un mesaj
POS-ul
Va avea o metoda „Plateste” care:
• va primi doi parametri: suma de plata si cardul
• va chema pe rand metodele
o introdu card
o get card data
o va incerca sa efectueze plata in banca
o va extrage cardul
• Se va asigura ca extragerea cardului a fost facuta si in situatia in care plata a esuat
Instantiati banca, creeati conturi, depuneti bani in conturi, instantiati un POS, emiteti carduri si
efectuati plati prin intermediul POS-ului
Definiti exceptiile, tratati exceptiile si afisati mesaje corespunzatoare*/
    class Program
    {
        static void Main(string[] args)
        {
            var InG = new Banca();
            Guid cont1 = InG.CreazaContBancar();
            InG.ConturiBancare[cont1].DepuneNumerar(2000);
            var card = InG.EmiteCard(cont1);
            try
            {
               
                var card2 = InG.EmiteCard(cont1);
                
            }
            catch (AlreadyExistException)
            {

                Console.WriteLine("Exista deja un card emis pentru contul curent");
            }

            try
            {
                var card3 = InG.EmiteCard(Guid.NewGuid());
            }
            catch (DosentExistException)
            {

                Console.WriteLine("COnt bancar inexistent");
            }
          
            var PoS = new PoS(InG);
            try
            {
                InG.ConturiBancare[cont1].ExtrageNumerar(3000);
                PoS.Plateste(4000, card);
            }
            catch (PoorException e)
            {
                Console.WriteLine("Nu este cascaval");
                
            }
            
            

           

           
            Console.WriteLine(InG.ConturiBancare[cont1].SoldCurent);

        }
    }
}
