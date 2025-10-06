using System;
using System.Collections.Generic;

public class CompanyDictionary
{
    private Dictionary<string, string> companies;
    public CompanyDictionary()
    {
        companies = new Dictionary<string, string>
        {
            {"Apple", "www.apple.com"},
            {"Microsoft", "www.microsoft.com"},
            {"Google", "www.google.com"},
            {"Amazon", "www.amazon.com"},
            {"JBL", "www.jbl.com"},
            {"Tesla", "www.tesla.com"},
            {"Samsung", "www.samsung.com"},
            {"Sony", "www.sony.com"},
            {"Intel", "www.intel.com"},
            {"ABC", "www.abc.com"}
        };
    }

    public bool FindAndRemoveCompany(string companyName)
    {
        if (companies.ContainsKey(companyName))
        {
            Console.WriteLine($"Найдено: {companyName} - {companies[companyName]}");
            companies.Remove(companyName);
            DisplayAllCompanies();
            Console.WriteLine("Если вы хотите продолжить - введите 1\nЕсли вы хотите выйти - нажмите \"Enter\"");
            string res = Console.ReadLine();
            if (res == "1")
            {
                Console.WriteLine("Введите фирму из словаря");
                FindAndRemoveCompany(Console.ReadLine());
                DisplayAllCompanies();
                return companies.Remove(companyName);

            }
            else
                return true;


        }
        else
        {
            Console.WriteLine($"Фирма '{companyName}' не найдена в словаре.\nВведите фирму из словаря");
            return FindAndRemoveCompany(Console.ReadLine());
        }
    }

    public void DisplayAllCompanies()
    {

        Console.WriteLine("Текущий список компаний:");
        int counter = 1;
        foreach (var company in companies)
        {
            Console.WriteLine($"{counter}. {company.Key} - {company.Value}");
            counter++;
        }
    }

    public void ClearAllCompanies()
    {
        companies.Clear();
        Console.WriteLine("Все компании удалены из словаря.");
    }

}
public class Program
{
    public static void Main(string[] args)
    {
        CompanyDictionary companyDict = new CompanyDictionary();

        SearchCompany(companyDict);

        DisplayRemainingCompanies(companyDict);

        ClearAllCompanies(companyDict);

    }

    public static void SearchCompany(CompanyDictionary companyDict)
    {
        Console.WriteLine("Исходный словарь компаний:");
        companyDict.DisplayAllCompanies();
        Console.WriteLine();

        Console.Write("Введите название фирмы для поиска: ");

        companyDict.FindAndRemoveCompany(Console.ReadLine());
        Console.WriteLine();
    }

    public static void DisplayRemainingCompanies(CompanyDictionary companyDict)
    {
        Console.WriteLine("Оставшиеся компании после удаления:");
        companyDict.DisplayAllCompanies();
        Console.WriteLine();
    }

    public static void ClearAllCompanies(CompanyDictionary companyDict)
    {
        Console.WriteLine("Очистка словаря...");
        companyDict.ClearAllCompanies();
    }

}