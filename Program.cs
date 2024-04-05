




using System;

class Program
{
    static bool IsPalindrome(string str)
    {
        //to make case sensitive
        str = str.ToLower();
        //two pointers
        int l = 0;
        int r = str.Length - 1;

        while (l < r)
        {
            //  to skip  punctuation
            if (!char.IsLetterOrDigit(str[l]))
            {
                l++;
                continue;
            }
            if (!char.IsLetterOrDigit(str[r]))
            {
                r--;
                continue;
            }


            if (str[l] != str[r])
            {
                return false;
            }
            l++;
            r--;
        }
        return true;
    }

    static void Main()
    {
        string str;
        bool validInput = false;
        //using the do so that at least theh question is asked once
        do
        {
            Console.WriteLine("Enter a string:");
            str = Console.ReadLine();

            // Check if the entered input is a valid string removing white spaces
            if (str != null && str.Trim() != "" && !int.TryParse(str, out _))
            {
                validInput = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid string.");
            }
        } while (!validInput);

        if (IsPalindrome(str))
        {
            Console.WriteLine("It's a palindrome.");
        }
        else
        {
            Console.WriteLine("It's not a palindrome.");
        }
    }
}
