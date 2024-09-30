using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    // Här finns funktioner som sätter in och tar ut pengar från kontonen
    public class BankomatChangeBalance
    {

        // Insättning - ökar saldot
        // Word key: dep = deposit  bal = balance
        public static void AccountDeposit(int[] accountNr, decimal[] accountBalance)
        {
            Console.WriteLine("Insättning\n");
            // Visar ett id på de aktiva kontonen som insättningar kan utföras
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
            // Välj det konto som insättningen ska utföras på
            Console.WriteLine("Välj ID på det konto som insättning ska utföras:");
            String strDepBalId = Console.ReadLine();
            
            // Validering av input
            if (!String.IsNullOrEmpty(strDepBalId) || !String.IsNullOrWhiteSpace(strDepBalId))
            {

                // Validering för att se om idet är giltigt
                bool checkDepBalId = int.TryParse(strDepBalId, out int depBalId);
                if (checkDepBalId == false)
                {
                    Console.WriteLine("Insättningen har inte ett giltigt kontoid");
                }
                else if (checkDepBalId == true && depBalId > accountNr.Length)
                {
                    Console.WriteLine("Insättningen har inte ett giltigt kontoid (Högre än array.length)");
                }
                else if (checkDepBalId == true && depBalId <= 0)
                {
                    Console.WriteLine("Insättningen har inte ett giltigt kontoid (lägre än array.length)");
                }
                else if (checkDepBalId == true && depBalId >= 1)
                {
                    // Insättning med validering
                    depBalId = depBalId - 1;
                    Console.WriteLine($"Genomför insättning på kontot med id {depBalId + 1}\nKontonummer: {accountNr[depBalId]}\nSaldo: {accountBalance[depBalId]:F}");
                    Console.WriteLine("Hur mycket ska sättas in:");

                    String strDepAmount = Console.ReadLine();
                    decimal depAmount;
                    Boolean depNumberCheck;

                    depNumberCheck = decimal.TryParse(strDepAmount, out depAmount);

                    if (depNumberCheck == true && depAmount > 0)
                    {
                        // Insättningen utförs bara om det är siffror med högst 2 decimaler
                        if (decimal.Round(depAmount, 2) == depAmount || decimal.Round(depAmount, 1) == depAmount || decimal.Round(depAmount, 0) == depAmount)
                        {
                            // Nya accoutBalance/kontosaldo
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


        // Uttag - minskar saldot
        // Word key: wd = withdraw    bal = balance
        public static void AccountWithdraw(int[] accountNr, decimal[] accountBalance)
        {
            Console.WriteLine("Uttag\n");
            // Visar ett id på de aktiva kontonen som uttag kan utföras
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
            // Välj det konto som uttag ska utföras på
            Console.WriteLine("Välj ID på det konto som uttag ska utföras:");
            String strWdBalId = Console.ReadLine();
            // Validering av input
            if (!String.IsNullOrEmpty(strWdBalId) || !String.IsNullOrWhiteSpace(strWdBalId))
            {

                // Validering för att se om idet är giltigt
                bool checkWdBalId = int.TryParse(strWdBalId, out int wdBalId);
                if (checkWdBalId == false)
                {
                    Console.WriteLine("Uttaget har inte giltigt kontoid");
                }
                else if (checkWdBalId == true && wdBalId > accountNr.Length)
                {
                    Console.WriteLine("Uttag har inte ett giltigt kontoid (Högre än array.length)");
                }
                else if (checkWdBalId == true && wdBalId <= 0)
                {
                    Console.WriteLine("Uttaget har inte giltigt kontoid (lägre än array.length)");
                }
                else if (checkWdBalId == true && wdBalId >= 1)
                {
                    // Uttag med validering
                    wdBalId = wdBalId - 1;
                    Console.WriteLine($"Genomför uttag på kontot med id {wdBalId + 1}\nKontonummer: {accountNr[wdBalId]}\nSaldo: {accountBalance[wdBalId]:F}");

                    Console.WriteLine("Hur mycket ska tas ut:");

                    String strWdAmount = Console.ReadLine();

                    decimal wdAmount;
                    Boolean wdNumberCheck;

                    wdNumberCheck = decimal.TryParse(strWdAmount, out wdAmount);

                    // Uttag utförs bara om det är siffror med högst 2 decimaler
                    if (decimal.Round(wdAmount, 2) == wdAmount || decimal.Round(wdAmount, 1) == wdAmount || decimal.Round(wdAmount, 0) == wdAmount)
                    {
                        if (wdNumberCheck == true && wdAmount > 0 && accountBalance[wdBalId] - wdAmount >= 0)
                        {
                            // Nya accoutBalance/kontosaldo
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
