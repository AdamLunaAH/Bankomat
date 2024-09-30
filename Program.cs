using Bankomat;


Int32[] accountNr = new Int32[10];
accountNr[0] = 1111;
accountNr[1] = 2222;
accountNr[2] = 3333;
accountNr[5] = 6666;

Int32[] accountBalance = new Int32[10];
accountBalance[0] = 100;
accountBalance[1] = 200;
accountBalance[2] = 300;
accountBalance[5] = 600;

Console.WriteLine("");

String menuSelection = "";
do
{
    Console.Clear();

    Console.WriteLine("Välj meny \n1: Kontolista \n2: Lediga konton \n3: Nytt konto \n4: Ta bort konto \n5: Kontosaldo \n6: Uttag \n7: Insättnig \nAvsluta med x \n");
    menuSelection = Console.ReadLine();
    Console.WriteLine($"Du har valt: {menuSelection}\n");

    // Kontolista
    if (menuSelection == "1")
    {
        BankomatFunctions.AccountList(accountNr);
        MenuFunctions.Pause();
    }

    // Lediga konton
    else if (menuSelection == "2")
    {
        BankomatFunctions.EmptyAccounts(accountNr);
        MenuFunctions.Pause();
    }

    // Nytt konto
    else if (menuSelection == "3")
    {
        BankomatFunctions.NewAccount(accountNr);
        MenuFunctions.Pause();

    }

    // Ta bort konto
    else if (menuSelection == "4")
    {
        BankomatFunctions.RemoveAccount(accountNr);
        MenuFunctions.Pause();

    }

    // Kontosaldo
    else if (menuSelection == "5")
    {
        BankomatFunctions.AccountBalance(accountNr, accountBalance);

        MenuFunctions.Pause();
    }
    // Uttag
    // Word key: wd = withdraw    bal = balance
    else if (menuSelection == "6")
    {
        BankomatFunctions.AccountWithdraw(accountNr, accountBalance);
        MenuFunctions.Pause();
    }
    // Insättning
    // Word key: dep = deposit  bal = balance
    else if (menuSelection == "7")
    {
        BankomatFunctions.AccountDeposit(accountNr, accountBalance);
        MenuFunctions.Pause();
    }

    else if (menuSelection == "8")
    {
        Console.WriteLine("Visa kontosaldo");
        MenuFunctions.Pause();
    }

    else if (menuSelection != "x")
    {
        Console.WriteLine($"{menuSelection} är inte en meny.");
        MenuFunctions.Pause();
    }
}
while (menuSelection != "x");





