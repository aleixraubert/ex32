# EX 32

## Enunciat

![foto_enunciat](/IMG/CAPTURA_ENUNCIAT.PNG)

---

## Mètodes a implementar

1. 
```csharp
bool EvilIsInLimits(int evil, int Min_Evil, int Max_Evil) /*Comprova que el nivell de maldat introduit està dins del rang.*/
```

2. 
```csharp 
bool CheckIfHasTwoVowels(string str) /*Comproba si la string té més de 2 vocals.*/
```

3. 
``` csharp
int CalcEvil(int evil, bool win) /*Calcula la maldat que li correspont a cadascú depenent de si ha guanyat o no.*/
```

4. 
```csharp 
bool CheckStringLength(string str, int min, int max) /*Comproba que el nom tingui més de 2 caràcters i menys de 25, i que no sigui null ni buit.*/ 
```

5. 
```csharp 
bool CheckSpecialChars(string str) /*Comproba que una string no tingui caràcters especials.*/
```

---

## Testos unitaris

### 1. EvilIsInLimits

```csharp
[TestMethod]
public void EvilHigher()
{
    int evil = 52000;
    int Min_evil = 1000;
    int Max_evil = 50000;

    bool expected = false;

    bool actual = Batalla.EvilIsInLimits(evil, Min_evil, Max_evil);

    Assert.AreEqual(expected, actual);
}
```

```csharp
[TestMethod]
public void EvilLower()
{
    int evil = 500;
    int Min_evil = 1000;
    int Max_evil = 50000;

    bool expected = false;

    bool actual = Batalla.EvilIsInLimits(evil, Min_evil, Max_evil);

    Assert.AreEqual(expected, actual);
}
```

```csharp
[TestMethod]
public void EvilRight()
{
    int evil = 12000;
    int Min_evil = 1000;
    int Max_evil = 50000;

    bool expected = true;

    bool actual = Batalla.EvilIsInLimits(evil, Min_evil, Max_evil);

    Assert.AreEqual(expected, actual);
}
```
---

### 2. CheckIfHasTwoVowels

```csharp
[TestMethod]
public void HasTwoVowels()
{
    string name = "Aa";
    bool expected = true;

    bool actual = Batalla.CheckIfHasTwoVowels(name);

    Assert.AreEqual(expected, actual);
}
```

```csharp
[TestMethod]
public void HasNotTwoVowels()
{
    string name = "Daddf";
    bool expected = false;

    bool actual = Batalla.CheckIfHasTwoVowels(name);

    Assert.AreEqual(expected, actual);
}
```
---

### 3. CalcEvil

```csharp
[TestMethod]
public void DistributeEvilWin()
{
    int evil = 10000;
    bool win = true;

    int expected = 2500;

    int actual = Batalla.DistributeEvil(evil, win);

    Assert.AreEqual(expected, actual);
}
```

```csharp
[TestMethod]
public void DistributeEvilLose()
{
    int evil = 10000;
    bool win = false;

    int expected = 500;

    int actual = Batalla.DistributeEvil(evil, win);

    Assert.AreEqual(expected, actual);
}
```

---

### 4. CheckStringLength

```csharp
[TestMethod]
public void HighLength()
{
    string name = "holaholaholaholaholaholahola";
    int min = 2;
    int max = 25;

    bool expected = false;

    bool actual = Batalla.CheckStringLength(name, min, max);

    Assert.AreEqual(expected, actual);
}
```

```csharp
[TestMethod]
public void LowerLength()
{
    string name = "a";
    int min = 2;
    int max = 25;

    bool expected = false;

    bool actual = Batalla.CheckStringLength(name, min, max);

    Assert.AreEqual(expected, actual);
}
```

```csharp
[TestMethod]
public void CorrectLength()
{
    string name = "aleix";
    int min = 2;
    int max = 25;

    bool expected = true;

    bool actual = Batalla.CheckStringLength(name, min, max);

    Assert.AreEqual(expected, actual);
}
```
---

### 5. CheckSpecialChars

```csharp
[TestMethod]
public void HasSpecialChars()
{
    string name = "aleix!";

    bool expected = false;

    bool actual = Batalla.CheckIfHasSpecialChars(name);

    Assert.AreEqual(expected, actual);
}
```

```csharp
[TestMethod]
public void HasNotSpecialChars()
{
    string name = "aleix";

    bool expected = false;

    bool actual = Batalla.CheckIfHasSpecialChars(name);

    Assert.AreEqual(expected, actual);
}
```

---

## Còdig Programa Principal

```csharp
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
```


---

## Resultat dels testos unitaris

![testos_unitaris](/IMG/Captura.PNG)
