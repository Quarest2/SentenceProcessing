using SentenceProcessing;

// Method that gets file name to read from user.
string GetFileNameToRead()
{
    string FileName;
    do
    {
        Console.WriteLine("Please, write the name of file to read a sentences" +
            "(without specifying extension)" +
            "(the file must be located next to the executable file of the console application):");
        FileName = Console.ReadLine() + ".txt";
    } while (!File.Exists(FileName));
    return FileName;

}

// Method that gets file name to save the result from user.
string GetFileNameToSave()
{
    StreamWriter sw = null;
    string FileName;
    do
    {
        Console.WriteLine("Please, write the name of file to save the result" +
            "(without specifying extension)" +
            "(the file must be located next to the executable file of the console application):");
        FileName = Console.ReadLine() + ".txt";
        try
        {
            sw = new StreamWriter(FileName);
        }
        catch
        {
            sw = null;
        }
    } while (sw == null);
    return FileName;
}

// Method that reads file and creates the list of CharArr2D.
List<CharArr2D> GetCharArraysFromFile(string FileName)
{
    var charArrays = new List<CharArr2D>(); ;
    try
    {
        using (StreamReader sr = new StreamReader(FileName))
        {
            string sentence;
            while ((sentence = sr.ReadLine()) != null)
            {
                charArrays.Add(new CharArr2D(sentence));
            }
        }
    }
    catch
    {
        Console.WriteLine("Sorry, the data in file is invalid.");
        return null;

    }
    return charArrays;
}

// Method that selects CharArr2D with only vowels from the CharArr2D list.
List<CharArr2D> GetOnlyVowelsCharArrays(List<CharArr2D> charArrays)
{
    var onlyVowels = new List<CharArr2D>();
    try
    {
        foreach (CharArr2D i in charArrays)
        {
            onlyVowels.Add(new CharArr2D(i.OnlyVowels));
        }
    }
    catch
    {
        Console.WriteLine("Sorry, something wrong with getting only vowels char arrays.");
        return null;
    }
    return onlyVowels;
}

// Method that writes CharrArr2D in file.
void WriteCharArr2DInFile(CharArr2D charArr, string fileName)
{
    using (StreamWriter sw = new StreamWriter(fileName, append: true))
    {
        char[][] charAr = charArr.GetCharArr();
        foreach (char[] j in charAr)
        {
            foreach (char k in j)
            {
            sw.Write(k);
            }
            sw.Write(" ");
        }
        sw.WriteLine();

    }
}




string input;
do
{
    string fileName = GetFileNameToRead();
    // I use lists, because in my opinion it is very strange to use an array when I am going to add an unknown number of objects.
    List<CharArr2D> charArrays = GetCharArraysFromFile(fileName);
    List<CharArr2D> onlyVowels = null;
    if (charArrays != null)
    {
        onlyVowels = GetOnlyVowelsCharArrays(charArrays);
    }
    else
    {
        Console.WriteLine("Sorry, we can't find valid sentences in file.");
    }
    if (onlyVowels != null)
    {
        fileName = GetFileNameToSave();
        foreach(CharArr2D i in onlyVowels)
        {
            WriteCharArr2DInFile(i, fileName);
        }
    }
    else
    {
        Console.WriteLine("Sorry there are no char arrays with only vowels in file.");
    }

    Console.WriteLine("Do you want to continue using the program? [y/n]");
    input = Console.ReadLine();

} while (input == "y" || input == "Y");
