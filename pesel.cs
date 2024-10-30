using System;

class Program
{
    static void Main(string[] args)
    {
        string pesel;

        
        Console.WriteLine("Podaj numer PESEL (11 cyfr) lub naciśnij Enter, aby użyć domyślnego: 55030101193");
        pesel = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(pesel))
        {
            pesel = "55030101193";
        }

       
        char gender = CheckGender(pesel);
        string genderString = (gender == 'K') ? "Kobieta" : "Mężczyzna";
        Console.WriteLine($"Płeć: {genderString}");

       
        bool isChecksumValid = CheckChecksum(pesel);
        if (isChecksumValid)
        {
            Console.WriteLine("Suma kontrolna jest poprawna.");
        }
        else
        {
            Console.WriteLine("Suma kontrolna jest niepoprawna.");
        }
    }

    static char CheckGender(string pesel)
    {
       
        if (pesel.Length != 11)
        {
            throw new ArgumentException("Numer PESEL musi mieć 11 cyfr.");
        }

       
        int genderDigit = int.Parse(pesel[9].ToString());
        return (genderDigit % 2 == 0) ? 'K' : 'M'; 
    }

    static bool CheckChecksum(string pesel)
    {
        
        int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
        int sum = 0;

       
        for (int i = 0; i < 10; i++)
        {
            sum += int.Parse(pesel[i].ToString()) * weights[i];
        }

     
        int M = sum % 10;
        int R = (M == 0) ? 0 : 10 - M;

       
        return R == int.Parse(pesel[10].ToString());
    }
}

