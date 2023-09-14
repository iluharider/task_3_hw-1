using System;

class Program
{
    static void Main(string[] args)
    { 
        Console.WriteLine(CreateRandomPassword());
    }

    public static string CreateRandomPassword()
    {
        Random random = new Random();

        int sizeOfPassword = random.Next(6, 21);
        char[] randomPassword = new char[sizeOfPassword];
        
        int underscoreIndex = random.Next(sizeOfPassword);
        randomPassword[underscoreIndex] = '_';
        
        int numberOfUpperCase = random.Next(2, sizeOfPassword);
        string upperCaseChars = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
        
        char[] digits = new char[10];
        for (int i = 0; i <= 9; i++) digits[i] = (char) (i + '0');
        
        string otherSymbols = "abcdefghijklmnopqrstuvwxyz!@#$%^&*?-";
        
        for (int i = 0; i < numberOfUpperCase; i++)
        {
            int letterPlace = 0;

            do
            {
                letterPlace = random.Next(sizeOfPassword);
            }
            while (randomPassword[letterPlace] != '\0');

            randomPassword[letterPlace] = upperCaseChars[random.Next(upperCaseChars.Length)];
        }

        int DigitsLeft = random.Next(5);

        if (randomPassword[0] == '\0')
        {
            if (random.Next(2) == 1) //flip a coin: aka "50/50 chance" -> random.Next(2) returns 0 or 1 
            {
                randomPassword[0] = (char)(random.Next(10) + '0');
                --DigitsLeft;
            }
        }

        for (int i = 1; i < sizeOfPassword && DigitsLeft > 0; i++)
        {
            if (randomPassword[i] == '\0')
                if (randomPassword[i-1] == '\0' || !digits.Contains(randomPassword[i - 1]))
                {
                    if (random.Next(2) == 1)
                    {
                        randomPassword[i] = (char)(random.Next(10) + '0');
                        --DigitsLeft;
                    }
                }
        }

        for (int i = 0; i < sizeOfPassword; i++)
        {
            if (randomPassword[i] == '\0') randomPassword[i] = otherSymbols[random.Next(otherSymbols.Length)];
        }

        return new string(randomPassword);
    }
}