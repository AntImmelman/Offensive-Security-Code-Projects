class Program
{
    #region Private variables
    // To break the secret password specified below, we'll utilize brute force.
    private static string password = "o!3a";
    private static string result;

    private static bool isMatched = false;
 
    private static int charactersToTestLength = 0;
    private static long computedKeys = 0;
 
    // An array is used to hold the brute force keys.
    private static char[] charactersToTest =
    {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
        'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
        'u', 'v', 'w', 'x', 'y', 'z','A','B','C','D','E',
        'F','G','H','I','J','K','L','M','N','O','P','Q','R',
        'S','T','U','V','W','X','Y','Z','1','2','3','4','5',
        '6','7','8','9','0','!','$','#','@','-','%','^','&','*',
        '(',')','+','<','>','?'
    };
    #endregion
 
    static void Main(string[] args)
    {
        var WhenDidItStart = DateTime.Now;
        Console.WriteLine("Starting BruteForce @ {0}", WhenDidItStart.ToString()); 
        charactersToTestLength = charactersToTest.Length;
        var estimatedPassLen = 0;
 
        while (!isMatched)
        {
            estimatedPasswordLength++;
            startBruteForce(estimatedPasswordLength);
        }
 
        Console.WriteLine("The Password matched. @ {0}", DateTime.Now.ToString());
        Console.WriteLine("Time passed: {0}s", DateTime.Now.Subtract(timeStarted).TotalSeconds);
        Console.WriteLine("The resolved password: {0}", result);
        Console.WriteLine("List of omputed keys: {0}", computedKeys);
 
        Console.ReadLine();
    }
 
    #region Private methods

    // Starts the recursive process that will use brute force to generate the keys.
    private static void startBruteForce(int keyLength)
    {
        var keyChars = createCharArray(keyLength, charactersToTest[0]);
        // For a modest performance boost, the index of the last character will be saved.
        var indexOfLastChar = keyLength - 1;
        createNewKey(0, keyChars, keyLength, indexOfLastChar);
    }
 
    private static char[] createCharArray(int length, char defaultChar)
    {
        return (from c in new char[length] select defaultChar).ToArray();
    }

    // Creates new keys and compares them to the password until the password is matched or the length of the current key is expired.
    private static void createNewKey(int currentCharPosition, char[] keyChars, int keyLength, int indexOfLastChar)
    {
        var nextCharPosition = currentCharPosition + 1;
        for (int i = 0; i < charactersToTestLength; i++)
        {
            keyChars[currentCharPosition] = charactersToTest[i];
             if (currentCharPosition < indexOfLastChar)
            {
                createNewKey(nextCharPosition, keyChars, keyLength, indexOfLastChar);
            }
            else
            {
                computedKeys++;
                if ((new String(keyChars)) == password)
                {
                    if (!isMatched)
                    {
                        isMatched = true;
                        result = new String(keyChars);
                    }
                    return;
                }
            }
        }
    }
    #endregion
}
