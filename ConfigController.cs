using System.Configuration;

public class ConfigController
{
    public static int GetValueInt(string key)
    {
        try
        {
            string val = ConfigurationManager.AppSettings[key] ?? "Not Found";
            int result = int.Parse(val);
            return result;
        }
        catch (ConfigurationErrorsException)
        {
            Console.WriteLine($"the key: {key} was not found");
            Console.WriteLine("Error reading app settings");
            return 0;
        }
    }

    public static double GetValueDouble(string key)
    {
        try
        {
            string val = ConfigurationManager.AppSettings[key] ?? "Not Found";
            double result = double.Parse(val);
            return result;
        }
        catch (ConfigurationErrorsException)
        {
            Console.WriteLine($"the key: {key} was not found");
            Console.WriteLine("Error reading app settings");
            return 0;
        }
    }

    public static string GetValueString(string key)
    {
        string result = ConfigurationManager.AppSettings[key] ?? "Not Found";
        if (result == "Not Found")
        {
            Console.WriteLine($"the key: {key} was not found");
            throw new ConfigurationErrorsException("Error reading app settings");
        }
        return result;
    }

    public static List<int> GetValueIntList(string key)
    {
        string val = ConfigurationManager.AppSettings[key] ?? "Not Found";
        if (val == "Not Found")
        {
            Console.WriteLine($"the key: {key} was not found");
            throw new ConfigurationErrorsException("Error reading app settings");
        }

        List<int> outputList = new List<int>();
        foreach (string str in val.Split(","))
        {
            outputList.Add(int.Parse(str));
        }
        return outputList;
    }

    public static List<double> GetValueDoubleList(string key)
    {
        string val = ConfigurationManager.AppSettings[key] ?? "Not Found";
        if (val == "Not Found")
        {
            Console.WriteLine($"the key: {key} was not found");
            throw new ConfigurationErrorsException("Error reading app settings");
        }

        List<double> outputList = new List<double>();
        foreach (string str in val.Split(","))
        {
            outputList.Add(double.Parse(str));
        }
        return outputList;
    }

    public static List<List<double>> GetValueDoubleNestedList(string key)
    {
        string val = ConfigurationManager.AppSettings[key] ?? "Not Found";
        if (val == "Not Found")
        {
            Console.WriteLine($"the key: {key} was not found");
            throw new ConfigurationErrorsException("Error reading app settings");
        }

        List<List<double>> outputList = new List<List<double>>();
        foreach (string splitted_str in val.Split("/"))
        {
            List<double> tmpList = new List<double>();
            foreach (string str in splitted_str.Split(","))
            {
                tmpList.Add(double.Parse(str));
            }
            outputList.Add(tmpList);
        }
        return outputList;
    }

    public static List<string> GetValueStringList(string key)
    {
        string val = ConfigurationManager.AppSettings[key] ?? "Not Found";
        if (val == "Not Found")
        {
            Console.WriteLine($"the key: {key} was not found");
            throw new ConfigurationErrorsException("Error reading app settings");
        }

        List<string> outputList = new List<string>();
        foreach (string str in val.Split(","))
        {
            outputList.Add(str);
        }
        return outputList;
    }

    private static List<int> ConvertStringToIntList(string[] strArray)
    {
        List<int> outputList = new List<int>();
        foreach (string str in strArray)
        {
            outputList.Add(int.Parse(str));
        }
        return outputList;
    }

    private static List<double> ConvertStringToDoubleList(string[] strArray)
    {
        List<double> outputList = new List<double>();
        foreach (string str in strArray)
        {
            outputList.Add(double.Parse(str));
        }
        return outputList;
    }
}
