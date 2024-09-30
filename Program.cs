using Bankomat;


int[] accountNr = new Int32[10];
accountNr[0] = 1111;
accountNr[1] = 2222;
accountNr[2] = 3333;
accountNr[5] = 6666;

decimal[] accountBalance = new decimal[10];
accountBalance[0] = 100.3M;
accountBalance[1] = 200.50M;
accountBalance[2] = 300.23M;
accountBalance[5] = 600M;

DateTime[] accountTime = new DateTime[10];
accountTime[0] = new DateTime(2024, 09, 30, 11, 16, 37);
accountTime[1] = new DateTime(2024, 09, 30, 12, 16, 37);
accountTime[2] = new DateTime(2024, 09, 30, 09, 16, 37);
accountTime[5] = new DateTime(2024, 09, 29, 23, 16, 37);

Console.WriteLine("");

String menuSelection = "";

do
{
    Console.Clear();


   // DateTime time = DateTime.UtcNow;
   // String time1 = time.ToString();
   //DateTime ToLocal = time.ToLocalTime();
   //Console.WriteLine($"{time} \n {ToLocal}");


    //decimal a = decimal.MaxValue;
    //decimal b = decimal.MinValue;
    //Console.WriteLine(a);
    //Console.WriteLine(b);




    Console.WriteLine("Välj meny \n1: Kontosaldon \n2: Kontoinformation \n3: Nytt konto \n4: Avsluta konto \n5: Insättning \n6: Uttag \n\nAvsluta med x \n");
    menuSelection = Console.ReadLine();
    Console.WriteLine($"Du har valt: {menuSelection}\n");

    // Kontosaldon
    if (menuSelection == "1")
    {
        BankomatFunctions.AccountBalance(accountNr, accountBalance);
        MenuFunctions.Pause();
    }

    // Kontoinformation
    else if (menuSelection == "2")
    {
        BankomatFunctions.AccountInfo(accountNr, accountBalance, accountTime);
        MenuFunctions.Pause();
    }

    // Nytt konto
    else if (menuSelection == "3")
    {
        BankomatFunctions.NewAccount(accountNr, accountBalance, accountTime);
        MenuFunctions.Pause();

    }

    // Avsluta konto
    else if (menuSelection == "4")
    {
        BankomatFunctions.RemoveAccount(accountNr, accountBalance, accountTime);
        MenuFunctions.Pause();

    }

    // Insättning
    // Word key: dep = deposit  bal = balance
    else if (menuSelection == "5")
    {
        BankomatFunctions.AccountDeposit(accountNr, accountBalance);
        MenuFunctions.Pause();
    }

    // Uttag
    // Word key: wd = withdraw    bal = balance
    else if (menuSelection == "6")
    {
        BankomatFunctions.AccountWithdraw(accountNr, accountBalance);
        MenuFunctions.Pause();
    }

    else if (menuSelection != "x")
    {
        Console.WriteLine($"{menuSelection} är inte en meny.");
        MenuFunctions.Pause();
    }
}
while (menuSelection != "x");





