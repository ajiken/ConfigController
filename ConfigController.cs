using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

public class ConfigController
{
    public static T GetValue<T>(string key, Func<string, T> parse, T defaultValue = default)
    {
        string value = ConfigurationManager.AppSettings[key];
        
        if (string.IsNullOrEmpty(value))
        {
            Console.WriteLine($"The key: {key} was not found or is empty.");
            return defaultValue;
        }
        
        try
        {
            return parse(value);
        }
        catch (Exception ex) when (ex is FormatException || ex is OverflowException)
        {
            Console.WriteLine($"Error parsing the key: {key} with value: {value}");
            return defaultValue;
        }
    }

    public static List<T> GetValueList<T>(string key, Func<string, T> parse)
    {
        string value = ConfigurationManager.AppSettings[key];
        
        if (string.IsNullOrEmpty(value))
        {
            Console.WriteLine($"The key: {key} was not found or is empty.");
            throw new ConfigurationErrorsException("Error reading app settings");
        }
        
        try
        {
            return value.Split(',').Select(parse).ToList();
        }
        catch (Exception ex) when (ex is FormatException || ex is OverflowException)
        {
            Console.WriteLine($"Error parsing list for the key: {key} with value: {value}");
            throw;
        }
    }

    public static List<List<T>> GetValueNestedList<T>(string key, Func<string, T> parse)
    {
        string value = ConfigurationManager.AppSettings[key];
        
        if (string.IsNullOrEmpty(value))
        {
            Console.WriteLine($"The key: {key} was not found or is empty.");
            throw new ConfigurationErrorsException("Error reading app settings");
        }
        
        try
        {
            return value.Split('/')
                .Select(subList => subList.Split(',').Select(parse).ToList())
                .ToList();
        }
        catch (Exception ex) when (ex is FormatException || ex is OverflowException)
        {
            Console.WriteLine($"Error parsing nested list for the key: {key} with value: {value}");
            throw;
        }
    }

    public static int GetValueInt(string key) => GetValue(key, int.Parse, 0);
    public static double GetValueDouble(string key) => GetValue(key, double.Parse, 0.0);
    public static string GetValueString(string key) => GetValue(key, str => str, "Not Found");
    public static List<int> GetValueIntList(string key) => GetValueList(key, int.Parse);
    public static List<double> GetValueDoubleList(string key) => GetValueList(key, double.Parse);
    public static List<string> GetValueStringList(string key) => GetValueList(key, str => str);
    public static List<List<double>> GetValueDoubleNestedList(string key) => GetValueNestedList(key, double.Parse);
}
