using System;
namespace Register_Console_App.Helpers
{
    public static class Helper
    {
            #region ReadLineStr
            public static string ReadLineStr(string input)
            {
                if (input == null)
                    throw new ArgumentNullException(nameof(input));
            
            
                TryAgain:
                Console.Write($" Enter the {input}: ");
                var str =  Console.ReadLine()?.Trim();

                if (str is not {Length: 0})
                    return str;
            
                Console.Clear();
                Console.WriteLine($"\n ❌  Wrong! Please enter the {input}\n");
                goto TryAgain;
            }
            #endregion

            #region ReadLineInt
            public static int ReadLineInt(string input)
            {
                if (input == null)
                    throw new ArgumentNullException(nameof(input));
                if (string.IsNullOrEmpty(input))
                    throw new ArgumentException("\n ❌  Value cannot be null or empty.", nameof(input));
                if (string.IsNullOrWhiteSpace(input))
                    throw new ArgumentException("\n ❌  Value cannot be null or whitespace.", nameof(input));

                TryAgain:
                try
                {
                    var console = Convert.ToInt32(ReadLineStr(input));
                
                    if (console < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("\n ❌  Enter a positive value\n");
                        goto TryAgain;
                    }
                    else
                    {
                        return console;
                    }
                
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine($"\n ❌  Wrong! Please enter the {input}\n");
                    goto TryAgain;
                }
            }
            #endregion
    }
    
}