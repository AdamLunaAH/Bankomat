using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    // Här finns funktioner som hämtar och visar kontodata
    public class BankomatAccountsData
    {
        // Kontosaldon
        public static void AccountBalance(int[] accountNr, decimal[] accountBalance)
        {
            // For-loop som hämter kontonummer och kontosaldo från konton med data (presenterar bara konton med data (aktiva konton))
            Console.WriteLine("Kontosaldo\n");
            for (int i = 0; i < 10; i++)
            {

                if (accountNr[i] == 0)
                {
                    continue;
                }
                else
                {
                    // Presenterar kontonen
                    // Console.WriteLine($"Konto: {i + 1}, Kontonr: {accountNr[i]}, Saldo: {accountBalance[i].ToString("F")}");

                    // Förenklad {accountBalance[i].ToString("F")}
                    Console.WriteLine($"Konto: {i + 1}, Kontonr: {accountNr[i]}, Saldo: {accountBalance[i]:F}");

                }
            }
        }


        // Kontoinformation - visar mer information som tid så kontot skapdes
        public static void AccountInfo(int[] accountNr, decimal[] accountBalance, DateTime[] accountTime)
        {
            Console.WriteLine("Kontoinformation\n");
            // For-loop som ger idn på de aktiva konton som finns
            for (int i = 0; i < 10; i++)
            {
                if (accountNr[i] == 0)
                {
                    continue;
                }
                else
                {
                    // Ger idn till de aktiva kontonen (1 läggs till i idet för att göra det mer användar vänligt) 
                    Console.WriteLine($"ID: {i + 1}, accountNr: {accountNr[i]}");
                }
            }
            // Välj idet på den konto som mer information ska visas
            Console.WriteLine("Välj ID på det konto som information ska visas:");
            String strAccountId = Console.ReadLine();

            // Validering av input 
            bool accountIdCheck = int.TryParse(strAccountId, out int accountId);

            if (accountIdCheck == true && accountId < accountNr.Length && accountId >= 1)
            {
                // Gör så att idet är den faktiska array idet
                accountId = accountId - 1;
            }
            else
            {
                accountIdCheck = false;
            }

            // Presenterar informationen för det valda kontot
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
    }
}