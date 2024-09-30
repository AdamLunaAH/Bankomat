using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    public class BankomatFunctions
    {

        // Kontosaldon
        public static void AccountBalance(int[] accountNr, decimal[] accountBalance)
        {
            Console.WriteLine("Kontosaldo\n");

            for (int i = 0; i < 10; i++)
            {

                if (accountNr[i] == 0)
                {
                    continue;
                }
                else
                {
                    // Console.WriteLine($"Konto: {i + 1}, Kontonr: {accountNr[i]}, Saldo: {accountBalance[i].ToString("F")}");

                    // Förenklad {accountBalance[i].ToString("F")}
                    Console.WriteLine($"Konto: {i + 1}, Kontonr: {accountNr[i]}, Saldo: {accountBalance[i]:F}");

                }
            }
        }

        // Kontoinformation
        public static void AccountInfo(int[] accountNr, decimal[] accountBalance, DateTime[] accountTime)
        {
            Console.WriteLine("Kontoinformation\n");
            for (int i = 0; i < 10; i++)
            {

                if (accountNr[i] == 0)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine($"ID: {i + 1}, accountNr: {accountNr[i]}");
                }
            }
            Console.WriteLine("Välj ID på det konto som information ska visas:");
            String strAccountId = Console.ReadLine();

            bool accountIdCheck = int.TryParse(strAccountId, out int accountId);

            if (accountIdCheck == true && accountId >= 1)
            {
                accountId = accountId - 1;
            }
            else
            {
                accountIdCheck = false;
            }


            if (accountIdCheck == true && accountNr[accountId] > 0)
            {
                DateTime accountTimeLocal = accountTime[accountId].ToLocalTime();

                Console.WriteLine($"Kontoinformation\nKontoID: {strAccountId}\nKontonummer: {accountNr[accountId]}\nSaldo: {accountBalance[accountId]:F}\nDatum då kontot skapdes: {accountTimeLocal}");
            }

            else if (accountIdCheck == true && accountNr[accountId] == 0)
            {
                Console.WriteLine("Kontot finns inte");
            }
            else
            {
                Console.WriteLine("Kontot finns inte");
            }

        }


        // Kontoplatser
        public static void EmptyAccounts(int[] accountNr)
        {
            Console.WriteLine("Lediga konton\n");
            for (int i = 0; i < 10; i++)
            {
                if (accountNr[i] != 0)
                {
                    continue;
                }
                else if (accountNr[i] == 0)
                {
                    Console.WriteLine($"Kontoplats {i + 1} är tom");
                }
            }
        }

        // Nytt konto
        public static void NewAccount(int[] accountNr, decimal[] accountBalance, DateTime[] accountTime)
        {
            Console.WriteLine("Nytt konto\n");

            int noEmptyAccountCheck = 0;
            int accountNrTaken = 0;
            bool validCheck = false;
            string strAccountBalance = "0";
            decimal intAccountBalance;


            for (int i = 0; i < 10; i++)
            {

                if (accountNr[i] == 0)
                {
                    noEmptyAccountCheck++;
                    Console.WriteLine($"Kontoplats med id {i + 1} är tom");
                    Console.WriteLine("Kontonummer:");

                    String strAccountNr = Console.ReadLine();

                    bool checkAccountNr = int.TryParse(strAccountNr, out int intAccountNr);

                    for (int j = 0; j < 10; j++)
                    {
                        if (accountNr[j] == intAccountNr)
                        {
                            accountNrTaken++;
                        }
                    }


                    if (checkAccountNr == true && intAccountNr > 0 && accountNrTaken == 0)
                    {

                        Console.WriteLine($"Kontonumret {intAccountNr} är giltigt.");

                    }
                    else
                    {
                        Console.WriteLine("Kontonumret är inte giltigt! (Det får inte vara 0, ett redan använt kontonummer, eller använda annat än siffror");
                        break;
                    }

                    Console.WriteLine("Kontosaldo (tryck enter för att sätta in pengar senare):");


                    strAccountBalance = Console.ReadLine();

                    bool checkAccountBalance = decimal.TryParse(strAccountBalance, out intAccountBalance);

                    Console.WriteLine(checkAccountBalance);
                    Console.WriteLine("1" + intAccountBalance);

                    if (accountNrTaken == 0 && checkAccountBalance == true && (decimal.Round(intAccountBalance, 2) == intAccountBalance || decimal.Round(intAccountBalance, 1) == intAccountBalance || decimal.Round(intAccountBalance, 0) == intAccountBalance))
                    {
                        validCheck = true;
                    }

                    if (validCheck && intAccountBalance >= 0)
                    {
                        Console.WriteLine($"Kontosaldot {intAccountBalance} är giltigt");
                    }
                    else
                    {
                        Console.WriteLine("Kontosaldot är är inte giltigt!");
                        break;
                    }

                    accountNr[i] = intAccountNr;
                    accountBalance[i] = intAccountBalance;
                    accountTime[i] = DateTime.UtcNow;
                    Console.WriteLine($"Kontot med ID {i + 1} har nu skapats och fått kontonumret {accountNr[i]} och kontosaldot {accountBalance[i]:F}");
                    accountTime[i] = DateTime.Now;
                    break;


                }

            }
            if (noEmptyAccountCheck == 0)
            {
                Console.WriteLine("Ingen ledig plats finns");
            }

        }

        // Ta bort konto
        // tar bort konton som inte finns
        public static void RemoveAccount(int[] accountNr, decimal[] accountBalance, DateTime[] accountTime)
        {
            Console.WriteLine("Ta bort konto\n");
            for (int i = 0; i < 10; i++)
            {

                if (accountNr[i] == 0)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine($"ID: {i + 1}, accountNr: {accountNr[i]}");
                }
            }
            Console.WriteLine("Välj ID på det konto som ska tas bort:");
            String strDeleteId = Console.ReadLine();
            if (!String.IsNullOrEmpty(strDeleteId) || !String.IsNullOrWhiteSpace(strDeleteId))
            {
                Int32 deleteId = Int32.Parse(strDeleteId) - 1;


                accountNr[deleteId] = 0;
                accountBalance[deleteId] = 0;
                accountTime[deleteId] = new DateTime(2000, 01, 01, 00, 00, 00);


                Console.WriteLine($"Kontot med Id {strDeleteId} har tagits bort");


            }
            else
            {
                Console.WriteLine("Kontot finns inte");


            }
        }

        // Insättning
        public static void AccountDeposit(int[] accountNr, decimal[] accountBalance)
        {
            Console.WriteLine("Insättning\n");
            for (int i = 0; i < 10; i++)
            {

                if (accountNr[i] == 0)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine($"ID: {i + 1}, accountNr: {accountNr[i]}");
                }
            }
            Console.WriteLine("Välj ID på det konto som insättning ska utföras:");
            String strDepBalId = Console.ReadLine();
            if (!String.IsNullOrEmpty(strDepBalId) || !String.IsNullOrWhiteSpace(strDepBalId))
            {

                bool checkDepBalId = int.TryParse(strDepBalId, out int depBalId);

                if (checkDepBalId == false)
                {
                    Console.WriteLine("Insättningen har inte ett giltigt kontoid");

                }
                else if (checkDepBalId == true && depBalId <= 0)
                {
                    Console.WriteLine("Insättningen har inte ett giltigt kontoid");
                }
                else if (checkDepBalId == true && depBalId >= 1)
                {
                    depBalId = depBalId - 1;

                    Console.WriteLine($"Genomför insättning på kontot med id {depBalId + 1}\nKontonummer: {accountNr[depBalId]}\nSaldo: {accountBalance[depBalId]:F}");

                    Console.WriteLine("Hur mycket ska sättas in:");

                    String strDepAmount = Console.ReadLine();

                    decimal depAmount;
                    Boolean depNumberCheck;

                    depNumberCheck = decimal.TryParse(strDepAmount, out depAmount);



                    if (depNumberCheck == true && depAmount > 0)
                    {

                        if (decimal.Round(depAmount, 2) == depAmount || decimal.Round(depAmount, 1) == depAmount || decimal.Round(depAmount, 0) == depAmount)
                        {
                            accountBalance[depBalId] = decimal.Round(accountBalance[depBalId] + depAmount, 2);

                            Console.WriteLine($"{depAmount:F} har satts in på kontot {accountNr[depBalId]} och det nya saldot är: {accountBalance[depBalId]:F}");

                        }
                        else
                        {
                            Console.WriteLine("Insättningen är inte ett giltigt nummer");
                        }


                    }
                    else if (depNumberCheck == false)
                    {
                        Console.WriteLine("Insättningen är inte ett nummer");
                    }
                    else if (depNumberCheck == true && depAmount <= 0)
                    {
                        Console.WriteLine("Insättning kan inte vara 0 eller negativt");

                    }
                }
            }
            else
            {
                Console.WriteLine("Kontot finns inte");
            }
        }


        // Uttag
        public static void AccountWithdraw(int[] accountNr, decimal[] accountBalance)
        {
            Console.WriteLine("Uttag\n");
            for (int i = 0; i < 10; i++)
            {

                if (accountNr[i] == 0)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine($"ID: {i + 1}, accountNr: {accountNr[i]}");
                }
            }
            Console.WriteLine("Välj ID på det konto som uttag ska utföras:");
            String strWdBalId = Console.ReadLine();
            if (!String.IsNullOrEmpty(strWdBalId) || !String.IsNullOrWhiteSpace(strWdBalId))
            {

                bool checkWdBalId = int.TryParse(strWdBalId, out int wdBalId);

                if (checkWdBalId == false)
                {
                    Console.WriteLine("Uttaget har inte giltigt kontoid");
                }
                else if (checkWdBalId == true && wdBalId <= 0)
                {
                    Console.WriteLine("Uttaget har inte giltigt kontoid");
                }
                else if (checkWdBalId == true && wdBalId >= 1)
                {
                    wdBalId = wdBalId - 1;

                    Console.WriteLine($"Genomför uttag på kontot med id {wdBalId + 1}\nKontonummer: {accountNr[wdBalId]}\nSaldo: {accountBalance[wdBalId]:F}");

                    Console.WriteLine("Hur mycket ska tas ut:");

                    String strWdAmount = Console.ReadLine();

                    decimal wdAmount;
                    Boolean wdNumberCheck;

                    wdNumberCheck = decimal.TryParse(strWdAmount, out wdAmount);

                    if (decimal.Round(wdAmount, 2) == wdAmount || decimal.Round(wdAmount, 1) == wdAmount || decimal.Round(wdAmount, 0) == wdAmount)
                    {
                        if (wdNumberCheck == true && wdAmount > 0 && accountBalance[wdBalId] - wdAmount >= 0)
                        {
                            accountBalance[wdBalId] = decimal.Round(accountBalance[wdBalId] - wdAmount, 2);
                            Console.WriteLine($"{wdAmount:F} har tagits ut från kontot {accountNr[wdBalId]} och det nya saldot är: {accountBalance[wdBalId]:F}");

                        }
                        else if (wdNumberCheck == false)
                        {
                            Console.WriteLine("Uttag är inte ett nummer");

                        }
                        else if (wdNumberCheck == true && wdAmount <= 0 || accountBalance[wdBalId] - wdAmount < 0)
                        {
                            if (wdAmount <= 0)
                            {
                                Console.WriteLine("Uttag kan inte vara 0 eller negativt");

                            }
                            else if (accountBalance[wdBalId] - wdAmount < 0)
                            {
                                Console.WriteLine("Uttaget kan inte vara större är kontosaldot");

                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Uttaget är inte ett giltigt nummer");
                    }
                }
            }
            else
            {
                Console.WriteLine("Kontot finns inte");
            }
        }
    }
}
