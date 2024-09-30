using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    // Här visas funktionern som ändrar kontodata (Skapa nytt konto, avsluta konto)
    public class BankomatChangeAccounts
    {

        // Nytt konto
        public static void NewAccount(int[] accountNr, decimal[] accountBalance, DateTime[] accountTime)
        {
            Console.WriteLine("----------\nNytt konto\n----------\n");

            int noEmptyAccountCheck = 0;
            int accountNrTaken = 0;
            bool validCheck = false;
            string strAccountBalance = "0";
            decimal intAccountBalance;

            // Om en ledig plats finns i kontonummer-array så används den först platsen som hittas
            for (int i = 0; i < 10; i++)
            {
                if (accountNr[i] == 0)
                {
                    noEmptyAccountCheck++;

                    // Id på första lediga plats
                    Console.WriteLine($"Kontoplats med id {i + 1} är tom");

                    // Kontonummer
                    Console.WriteLine("Kontonummer:");
                    String strAccountNr = Console.ReadLine();
                    Console.WriteLine("");

                    bool checkAccountNr = int.TryParse(strAccountNr, out int intAccountNr);

                    // Kollar om kontonumret redan används
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
                        // Om kontonumret redan används så läggs kontot inte till i array
                        Console.WriteLine("Kontonumret är inte giltigt! (Det får inte vara 0, ett redan använt kontonummer, eller använda annat än siffror");
                        break;
                    }

                    // Här kan man lägga till ett saldo på kontot som skapas
                    Console.WriteLine("Kontosaldo (tryck enter för att sätta in pengar senare):");
                    strAccountBalance = Console.ReadLine();
                    Console.WriteLine("");


                    if (string.IsNullOrEmpty(strAccountBalance) || string.IsNullOrWhiteSpace(strAccountBalance))
                    {
                        strAccountBalance = "0";
                    }

                    bool checkAccountBalance = decimal.TryParse(strAccountBalance, out intAccountBalance);

                    // Validering av nya kontosaldot (det får bara vara siffror med högst 2 decimaler)
                    if (accountNrTaken == 0 && checkAccountBalance == true && (decimal.Round(intAccountBalance, 2) == intAccountBalance || decimal.Round(intAccountBalance, 1) == intAccountBalance || decimal.Round(intAccountBalance, 0) == intAccountBalance))
                    {
                        validCheck = true;
                    }

                    if (validCheck == true && intAccountBalance >= 0)
                    {
                        Console.WriteLine($"Kontosaldot {intAccountBalance} är giltigt");
                    }
                    else
                    {
                        Console.WriteLine("Kontosaldot är är inte giltigt!");
                        break;
                    }
                    // Data-arrayer uppdateras med den nya datan och visar den
                    accountNr[i] = intAccountNr;
                    accountBalance[i] = intAccountBalance;
                    accountTime[i] = DateTime.UtcNow;
                    Console.WriteLine($"Kontot med ID {i + 1} har nu skapats och fått kontonumret {accountNr[i]} och kontosaldot {accountBalance[i]:F}");
                    accountTime[i] = DateTime.Now;
                    break;


                }

            }

            // Om ingen ledig plats hittades så visas ett felmeddelande
            if (noEmptyAccountCheck == 0)
            {
                Console.WriteLine("Ingen ledig plats finns");
            }

        }

        // Avslutar/tar bort ett konto - den nollställer datan som finns i data-array
        // tar bort konton som inte finns!!!
        public static void RemoveAccount(int[] accountNr, decimal[] accountBalance, DateTime[] accountTime)
        {
            Console.WriteLine("----------\nTa bort konto\n----------\n");
            // Visar ett id på de aktiva kontonen som kan tas bort
            for (int i = 0; i < accountNr.Length; i++)
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
            // Välj idet på det konto som ska tas bort
            Console.WriteLine("Välj ID på det konto som ska tas bort:");
            String strDeleteId = Console.ReadLine();
            Console.WriteLine("");



            if (!String.IsNullOrEmpty(strDeleteId) || !String.IsNullOrWhiteSpace(strDeleteId))
            {
                Int32 deleteId = Int32.Parse(strDeleteId) - 1;



                if (deleteId >= 0 && deleteId < accountNr.Length && accountNr[deleteId] == 0)
                {
                    Console.WriteLine("Kontot finns inte");
                }
                else if (deleteId >= 0 && deleteId < accountNr.Length)
                {
                    // Nollställer det valda kontots data i arrayer
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
            else
            {
                Console.WriteLine("Kontot finns inte");


            }
        }
    }
}