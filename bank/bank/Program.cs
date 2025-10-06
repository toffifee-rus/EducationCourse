using System;

class Program
{
    static void Main()
    {
        BankClient[] clients = new BankClient[4];
        clients[0] = new BankClient("Косарев В.С.", "1234 567890", "111111111111", 500000, 10.5, new DateTime(2025, 1, 2), 12);
        clients[1] = new BankClient("Филимонов М.С.", "1234 987654", "222222222222", 1500000, 9.5, new DateTime(2025, 1, 1), 24);
        clients[2] = new BankClient("Лучевников Л.Э.", "1234 555555", "333333333333", 800000, 11.0, new DateTime(2025, 1, 3), 18);

        Console.WriteLine("Клиенты с кредитом больше 1 млн:");
        bool found = false;
        for (int i = 0; i < clients.Length; i++)
        {
            if (clients[i].LoanAmount > 1000000)
            {
                clients[i].PrintInfo();
                found = true;
            }
        }
        if (!found)
            Console.WriteLine("Таких клиентов нет");

        Console.WriteLine();

      
    }
}

struct BankClient
{
    public string FullName;
    public string Passport;
    public string INN;
    public decimal LoanAmount;
    public double Percent;
    public DateTime Date;
    public int Term;

    public BankClient(string name, string passport, string inn, decimal loan, double percent, DateTime date, int term)
    {
        FullName = name;
        Passport = passport;
        INN = inn;
        LoanAmount = loan;
        Percent = percent;
        Date = date;
        Term = term;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"{FullName} - {LoanAmount} руб.");
    }
}

