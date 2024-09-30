using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    public class BankomatFunctions
    {

        public static void AccountList(int[] accountNr)
        {
            Console.WriteLine("Kontolista\n");

            for (int i = 0; i < 10; i++)
            {

                if (accountNr[i] == 0)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine($"accountNr: {accountNr[i]}");
                }
            }
            
        }

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

        public static void NewAccount(int[] accountNr)
        {
            Console.WriteLine("Nytt konto\n");
            Console.WriteLine("Lediga platser:");
            for (int i = 0; i < 10; i++)
            {

                if (accountNr[i] == 0)
                {
                    Console.WriteLine($"ID: {i + 1}");
                }
                else
                {
                    continue;
                }
            }
            Console.WriteLine("Välj ID på den plats på det nya kontot:");
            String strAddId = Console.ReadLine();

            if (!String.IsNullOrEmpty(strAddId) || !String.IsNullOrWhiteSpace(strAddId))
            {
                Int32 addId = Int32.Parse(strAddId) - 1;
                Console.WriteLine("Nya kontonummret:");
                String strAddAccountNr = Console.ReadLine();
                Int32 addAccountNr = Int32.Parse(strAddAccountNr);
                accountNr[addId] = addAccountNr;

                Console.WriteLine($"Konto med Id {addId + 1} har fått kontonummret {addAccountNr}");

                //MenuFunctions.Pause();
            }
            else
            {
                Console.WriteLine("Ingen ledig plats finns");
                //MenuFunctions.Pause();

            }
        }

        // Ta bort konto
        // tar bort konton som inte finns
        public static void RemoveAccount(int[] accountNr)
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

                Console.WriteLine($"Kontot med Id {strDeleteId} har tagits bort");

                //MenuFunctions.Pause();
            }
            else
            {
                Console.WriteLine("Input finns inte");
                //MenuFunctions.Pause();

            }
        }

        public static void AccountBalance(int[] accountNr, int[] accountBalance)
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
                    Console.WriteLine($"Konto: {i + 1}, Kontonr: {accountNr[i]}, Saldo: {accountBalance[i]}");

                }
            }
        }


        //Uttag
        // inget meddeladne visas när uttag utförts
        public static void AccountWithdraw(int[] accountNr, int[] accountBalance)
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


                Int32 wdBalId = Int32.Parse(strWdBalId) - 1;

                Console.WriteLine($"Genomför uttag på kontot med id {wdBalId + 1}\nKontonummer: {accountNr[wdBalId]}\nSaldo: {accountBalance[wdBalId]}");

                Console.WriteLine("Hur mycket ska tas ut:");

                String strWdAmount = Console.ReadLine();

                Int32 wdAmount;
                Boolean wdNumberCheck;

                wdNumberCheck = int.TryParse(strWdAmount, out wdAmount);

                //Console.WriteLine($"{wdNumberCheck} {wdAmount}");



                if (wdNumberCheck == true && wdAmount > 0 && accountBalance[wdBalId] - wdAmount >= 0)
                {
                    accountBalance[wdBalId] = accountBalance[wdBalId] - wdAmount;
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



                //MenuFunctions.Pause();
            }
            else
            {
                Console.WriteLine("Kontot finns inte");
                //MenuFunctions.Pause();

            }
        }

        // Insättning
        // inget meddeladne visas när insättning utförts
        public static void AccountDeposit(int[] accountNr, int[] accountBalance)
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

                Int32 depBalId = Int32.Parse(strDepBalId) - 1;

                Console.WriteLine($"Genomför insättning på kontot med id {depBalId + 1}\nKontonummer: {accountNr[depBalId]}\nSaldo: {accountBalance[depBalId]}");

                Console.WriteLine("Hur mycket ska sättas in:");

                String strDepAmount = Console.ReadLine();

                Int32 depAmount;
                Boolean depNumberCheck;

                depNumberCheck = int.TryParse(strDepAmount, out depAmount);

                Console.WriteLine($"{depNumberCheck} {depAmount}");



                if (depNumberCheck == true && depAmount > 0)
                {
                    accountBalance[depBalId] = accountBalance[depBalId] + depAmount;
                }
                else if (depNumberCheck == false)
                {
                    Console.WriteLine("Insättningen är inte ett nummer");

                }
                else if (depNumberCheck == true && depAmount <= 0)
                {

                    Console.WriteLine("Insättning kan inte vara 0 eller negativt");



                }



                //MenuFunctions.Pause();
            }
            else
            {
                Console.WriteLine("Kontot finns inte");
                

            }
        }

        

       

        

        
    }
}
