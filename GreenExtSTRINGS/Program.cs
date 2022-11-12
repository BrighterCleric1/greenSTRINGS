using System.Text.RegularExpressions;

//Console.WriteLine("Inserisci dei numeri separati da una virgola");
//var numbers = Console.ReadLine();

//var test = "//[+]//[***]//[.]//1+2***3.2";
var test = "//[+]//[***]//[.]//1+2***-3.2";

Console.WriteLine(test);
Console.WriteLine(Add(test));
decimal Add(string numbers)
{
    var searchDelimiters = numbers.Split("//").Skip(1);
    var numbersToSearch = searchDelimiters.LastOrDefault();
    var delimiters = searchDelimiters.Where(x => x.Contains("[") && x.Contains("]")).ToList();
    var onlyDelimiters = new List<string>();
    foreach(var x in delimiters)
    {
       onlyDelimiters.Add(x.Substring(1, x.Length-2));
    }
    var delArray = onlyDelimiters.ToArray();
    var numbersAsString = numbersToSearch.Split(delArray, StringSplitOptions.RemoveEmptyEntries);
    var decimals = new List<decimal>();
    var negatives = new List<decimal>();
    foreach (var x in numbersAsString)
    {
        switch (decimal.Parse(x))
        {
            case < 0:
                negatives.Add(decimal.Parse(x));
                break;
            case < 1000:
                decimals.Add(decimal.Parse(x));
                break;
            default: break;
        }

    }
    if (negatives.Count() > 0)
    {
        var emptyString = "";
        foreach (var num in negatives)
        {
            emptyString += num.ToString() + " ";
        }
        throw new Exception($"negatives {emptyString} not allowed");
    }
    return decimals.Sum();
}