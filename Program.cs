using Bankomat;


// Konton som inte har någon data kan beskrivas som inaktiva konton, då de har en plats i data array men har ingen data.
// Konton som har data i arrays kan beskrivas som aktiva konton

// Kontonummer
int[] accountNr = new Int32[10];
// Exempeldata
accountNr[0] = 1111; 
accountNr[1] = 2222;
accountNr[2] = 3333;
accountNr[5] = 6666;

// Kontosaldo
decimal[] accountBalance = new decimal[10];
// Exempeldata
accountBalance[0] = 100.3M;
accountBalance[1] = 200.50M;
accountBalance[2] = 300.23M;
accountBalance[5] = 600M;

// Tid när kontot skapas 
DateTime[] accountTime = new DateTime[10];
// Exempeldata
accountTime[0] = new DateTime(2024, 09, 30, 11, 16, 37);
accountTime[1] = new DateTime(2024, 09, 30, 12, 16, 37);
accountTime[2] = new DateTime(2024, 09, 30, 09, 16, 37);
accountTime[5] = new DateTime(2024, 09, 29, 23, 16, 37);

String menuSelection = "";

do
{
    // Menylista
    Console.Clear();
    Console.WriteLine("Välj meny \n1: Kontosaldon \n2: Kontoinformation \n3: Nytt konto \n4: Avsluta konto \n5: Insättning \n6: Uttag \n\nAvsluta med x \n");
    menuSelection = Console.ReadLine();
    Console.WriteLine($"Du har valt: {menuSelection}\n");

    // Kontosaldon
    if (menuSelection == "1")
    {
        BankomatAccountsData.AccountBalance(accountNr, accountBalance);
        MenuFunctions.Pause();
    }

    // Kontoinformation
    else if (menuSelection == "2")
    {
        BankomatAccountsData.AccountInfo(accountNr, accountBalance, accountTime);
        MenuFunctions.Pause();
    }

    // Nytt konto
    else if (menuSelection == "3")
    {
        BankomatChangeAccounts.NewAccount(accountNr, accountBalance, accountTime);
        MenuFunctions.Pause();

    }

    // Avsluta konto
    else if (menuSelection == "4")
    {
        BankomatChangeAccounts.RemoveAccount(accountNr, accountBalance, accountTime);
        MenuFunctions.Pause();

    }

    // Insättning
    // Word key: dep = deposit  bal = balance
    else if (menuSelection == "5")
    {
        BankomatChangeBalance.AccountDeposit(accountNr, accountBalance);
        MenuFunctions.Pause();
    }

    // Uttag
    // Word key: wd = withdraw    bal = balance
    else if (menuSelection == "6")
    {
        BankomatChangeBalance.AccountWithdraw(accountNr, accountBalance);
        MenuFunctions.Pause();
    }

    else if (menuSelection != "x")
    {
        Console.WriteLine($"{menuSelection} är inte en meny.");
        MenuFunctions.Pause();
    }
}
while (menuSelection != "x");





