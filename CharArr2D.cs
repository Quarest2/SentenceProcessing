namespace SentenceProcessing;

/// <summary>
/// Class that works with array of char arrays.
/// </summary>
public class CharArr2D
{
    private char[][] _charArr = new char[0][];

    public CharArr2D() { }

    /// <summary>
    /// Constructor that creates array of char arrays from sentence.
    /// </summary>
    /// <param name="sentence">A set of words separated by a space. Ends with a dot.</param>
    /// <exception cref="ArgumentException"></exception>
    public CharArr2D(string sentence)
    {
        try
        {
            string[] arr = sentence.Split(' ');
            StringBuilder sb = new StringBuilder(arr[^1]);

            if (sb[^1].Equals('.'))
            {
                sb.Remove(sb.Length - 1, 1);
                arr[^1] = sb.ToString();
            }
            else
            {
                // We use this type of exception, because it is thrown out if the parameter in the method is invalid.
                throw new ArgumentException("Parameter CharArr2D includes not only sentences.");
            }
            foreach (string i in arr)
            {
                // We use regular expressions to check strings to see if they match the criteria we need.
                if (!Regex.Match(i, "^[a-z]+$", RegexOptions.IgnoreCase).Success)
                {
                    // We use this type of exception, because it is thrown out if the parameter in the method is invalid.
                    throw new ArgumentException("Not only latin characters in the sentence.");
                }
            }
            foreach (string i in arr)
            {
                _charArr = _charArr.ToList().Append(i.ToCharArray()).ToArray();
            }
        }catch
        {
            // We use this type of exception, because it is thrown out if the parameter in the method is invalid.
            throw new ArgumentException("Something wrong with sentence parameter in CharArr2D.");
        }
    }

    /// <summary>
    /// Constructor that do deep copy of array of char arrays.
    /// </summary>
    /// <param name="arr">Array of char arrays.</param>
    /// <exception cref="ArgumentException"></exception>
    public CharArr2D(char[][] arr)
    {
        try
        {
            _charArr = new char[arr.Length][];
            for (int i = 0; i < arr.Length; i++)
            {
                _charArr[i] = new char[0];
                foreach (char j in arr[i])
                {
                    _charArr[i] = _charArr[i].ToList().Append(j).ToArray();
                }
            }
        }
        catch
        {
            // We use this type of exception, because it is thrown out if the parameter in the method is invalid.
            throw new ArgumentException("Something wrong with char[][] parameter in CharrArr2D.");
        }

    }

    /// <summary>
    /// A propetry that returns array elements containing only vowels.
    /// </summary>
    public char[][] OnlyVowels
    {
        get
        {
            var onlyVowelsCharArr = new char[0][];
            string word;
            try
            {
                foreach (char[] i in _charArr)
                {
                    word = new string(i);
                    // We use regular expressions to check strings to see if they match the criteria we need.
                    if (Regex.Match(word, "^[a, e, i, o, u, y]+$", RegexOptions.IgnoreCase).Success)
                    {
                        onlyVowelsCharArr = onlyVowelsCharArr.ToList().Append(i).ToArray();
                    }
                }
                return onlyVowelsCharArr;
            }
            catch
            {
                // We use this type of excpression, because it is thrown out if the parameter in the method null.
                throw new ArgumentNullException("Something wrong with _charArr this instance of the class.");
            }
        }
    }

    public char[][] GetCharArr()
    {
        return _charArr;
    }
}

