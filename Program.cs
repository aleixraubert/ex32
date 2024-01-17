/* En el mateix estudi, en paral·lel es porta a terme la creació del videojoc basat en Super 4, una sèrie d’animació basada en personatges de Playmobil. En aquesta primera part del projecte, el videojoc se centra en la fada Espurna. 
El jugador haurà d’escollir un dels següents avatars (suposem que es mostren les imatges següents i el jugador ha d’escollir entre [1,4]):

Un cop seleccionat l’avatar, el jugador haurà de posar-li un nom i indicar el seu nivell de maldat [1000, 50000]. Llavors l’Espurna haurà de llançar el seu encanteri contra l’avatar del jugador:
si el nom assignat a l’avatar conté com a mínim dues vocals, l’Espurna podrà convertir la seva maldat en pols
màgica per ajudar els seus companys, i la repartirà entre tot l’equip a parts iguals, deixant la resta com a maldat per a l’avatar. 
En cas contrari, només podrà repartir a parts iguals entre l’equip el 5% de la seva maldat, ja que l’encanteri no ho pot transformar-la tota.
Enumera els mètodes que hauràs d’implementar (només la declaració)
Implementa els UT per a aquests mètodes
Implementa el programa principal amb els mètodes corresponents
Assigna el projecte de UT a la solució i valida els mètodes
PO aclariments: la maldat es reparteix entre tots els membres de Super4, Espurna inclosa (són 4)
a l’hora d’escollir avatar, si s’equivoca el jugador, intents infinits
*/
using System;

namespace Prog
{
    public class Batalla
    {
        static void Main()
        {
            const string Msg_Ask = "Escull el teu avatar [1,4]: ";
            const string Msg_Choose = "Has escollit a la fada Espurna. Quin nom li vols posar? ";
            const string Msg_Evil = "Quin nivell de maldat vols que tingui? [1000, 50000]: ";
            const string Msg_Error_Name = "El nom ha de tenir entre 2 i 25 caràcters i no pot contenir caràcters especials. Torna a provar: ";
            const string Msg_Error_Evil = "El nivell de maldat ha d'estar entre 1000 i 50000. Torna a provar: ";
            const string Msg_Final = "La pols màgica que reparteix l'Espurna a cada membre del equip es de {0}";

            const int Min_Evil = 1000;
            const int Max_Evil = 50000;
            const int Min_length = 2;
            const int Max_length = 25;

            Console.Write(Msg_Ask);

            int option = Convert.ToInt32(Console.ReadLine());

            while (option < 1 || option > 4)
            {
                Console.Write(Msg_Ask);

                option = Convert.ToInt32(Console.ReadLine());
            }

            Console.Write(Msg_Choose);

            string name = Console.ReadLine();

            while(!CheckStringLength(name, Min_length, Max_length) || CheckIfHasSpecialChars(name))
            {
                Console.Write(Msg_Error_Name);

                name = Console.ReadLine();
            }

            Console.Write(Msg_Evil);

            int evil = Convert.ToInt32(Console.ReadLine());

            while(!EvilIsInLimits(evil, Min_Evil, Max_Evil))
            {
                Console.Write(Msg_Error_Evil);

                evil = Convert.ToInt32(Console.ReadLine());
            }

            bool win = CheckIfHasTwoVowels(name);
            
            Console.WriteLine(Msg_Final, CalcEvil(evil, win));
        }

        public static bool EvilIsInLimits(int evil, int Min_Evil, int Max_Evil)
        {
            return evil >= Min_Evil && evil <= Max_Evil;
        }

        public static bool CheckIfHasTwoVowels(string str)
        {
            int count = 0;

            string str_lower = str.ToLower();

            for (int i = 0; i < str.Length; i++)
            {
                if (str_lower[i] == 'a' || str_lower[i] == 'e' ||
                                       str_lower[i] == 'i' || str_lower[i] == 'o' ||
                                                          str_lower[i] == 'u')
                {
                    count++;
                }
            }

            return count >= 2;
        }

        public static int CalcEvil(int evil, bool win)
        {
            if(win)
            {
                return evil / 4;
            }
            else
            {
                evil = evil * 5 / 100;
                return evil / 4;
            }
        }

        public static bool CheckStringLength(string str, int min, int max)
        {
            return str.Length >= min && str.Length <= max;
        }

        public static bool CheckIfHasSpecialChars(string str)
        {
            const string SpecialChars = "!@#$%^&*()_+<>?:.,;";

            bool found = false;

            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < SpecialChars.Length; j++)
                {
                    if (str[i] == SpecialChars[j])
                    {
                        found = true;
                    }
                }
            }

            return found;
        }   

    }
}
