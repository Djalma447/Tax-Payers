﻿using System;
using System.Collections.Generic;
using System.Globalization;
using Course.Entities;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> list = new List<TaxPayer>();
            
            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Tax payer #{i} data:");
                Console.Write("Individual or company (i/c)? ");
                char answer = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual income: ");
                double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if (answer == 'i')
                {
                    Console.Write("Health expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new Individual(name, anualIncome, healthExpenditures));
                }
                else
                {
                    Console.Write("Number of employees: ");
                    int numberOfEmployees = int.Parse(Console.ReadLine());
                    list.Add(new Company(name, anualIncome, numberOfEmployees));
                }
            }

            Console.WriteLine();
            Console.WriteLine("TAXES PAID:");
            foreach(TaxPayer payer in list)
            {
                Console.WriteLine(payer.Name + ": $ " + payer.Tax().ToString("F2", CultureInfo.InvariantCulture));
            }

            Console.WriteLine();
            double totalTaxes = 0;
            foreach(TaxPayer payer in list)
            {
                totalTaxes += payer.Tax();
            }
            Console.WriteLine("TOTAL TAXES: $ " + totalTaxes.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
