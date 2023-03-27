using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;


namespace Vjezba_Darko_Takac
{
    public class Lottery
    {
        public List<int> LotteryNumbers { get; }

        public Lottery()
        {
            LotteryNumbers = new List<int>();
            Random random = new Random();

            while (LotteryNumbers.Count < 7)
            {
                int randomNumber = random.Next(1, 46);
                if (!LotteryNumbers.Contains(randomNumber))
                {
                    LotteryNumbers.Add(randomNumber);
                }
            }
        }

        public void PrintNumbers()
        {
            Console.WriteLine("The lottery numbers are:");
            foreach (int numberDrawn in LotteryNumbers)
            {
                Console.Write(numberDrawn + " ");
            }
            Console.WriteLine("\n");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                Console.WriteLine("Choose the number of the function you'd like to open: 1-8");
                Console.WriteLine("1 - PARNOST");
                Console.WriteLine("2 - KVADRATNA");
                Console.WriteLine("3 - PROSJEK");
                Console.WriteLine("4 - ZNAMENKE");
                Console.WriteLine("5 - LOTO");
                Console.WriteLine("6 - LISTIC");
                Console.WriteLine("7 - OSOBA");
                Console.WriteLine("8 - PDF\n");

                string menu = Console.ReadLine();

                switch (menu)
                {
                    // zadatak 1, 2, 3
                    case "1":

                        Console.WriteLine("Option 1 selected: 1 - PARNOST");
                        Console.WriteLine("Enter a number:");

                        int.Parse(Console.ReadLine());
                        int number;

                        try
                        {
                            number = int.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Wrong key pressed, it must be a number!");
                            break;
                        }

                        if (number % 2 == 0)
                        {
                            Console.WriteLine($"{number} is even.");
                        }
                        else
                        {
                            Console.WriteLine($"{number} is odd.");
                        }
                    break;

                    // zadatak 4
                    case "2":

                        int a, b, c;

                        double d, x1, x2;
                        Console.Write("\n\n");
                        Console.Write("Calculate root of Quadratic Equation :\n");
                        Console.Write("----------------------------------------\n");

                        Console.Write("Input the value of a: ");
                        a = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Input the value of b: ");
                        b = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Input the value of c: ");
                        c = Convert.ToInt32(Console.ReadLine());

                        d = b * b - 4 * a * c;
                        if (d == 0)
                        {
                            Console.Write("Both roots are equal.\n");
                            x1 = -b / (2.0 * a);
                            x2 = x1;
                            Console.Write("First Root = {0}\n", x1);
                            Console.Write("Second Root = {0}\n\n", x2);
                        }
                        else if (d > 0)
                        {
                            Console.Write("Both roots are real and diff-2\n");

                            x1 = (-b + Math.Sqrt(d)) / (2 * a);
                            x2 = (-b - Math.Sqrt(d)) / (2 * a);

                            Console.Write("First Root = {0}\n", x1);
                            Console.Write("Second Root = {0}\n\n", x2);
                        }
                        else
                            Console.Write("Root are imaginary;\nNo Solution. \n\n");
                    break;

                    //zadatak 5
                    case "3":
                        List<int> grades = new List<int>();
                        bool done = false;
                        while (!done)
                        {
                            Console.WriteLine("Enter a grade from 1 to 5, or enter 'done' to finish:");
                            string input = Console.ReadLine();
                            if (input == "done")
                            {
                                done = true;
                            }
                            else
                            {
                                int grade;
                                if (int.TryParse(input, out grade) && grade >= 1 && grade <= 5)
                                {
                                    grades.Add(grade);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a number from 1 to 5, or enter 'done' to finish.");
                                }
                            }
                        }

                        int sum = 0;
                        foreach (int grade in grades)
                        {
                            sum += grade;
                        }
                        double average = (double)sum / grades.Count;

                        int roundedAverage = (int)Math.Round(average, MidpointRounding.AwayFromZero);
                        string description;
                        switch (roundedAverage)
                        {
                            case 1:
                                description = "NEDOVOLJAN";
                                break;
                            case 2:
                                description = "DOVOLJAN";
                                break;
                            case 3:
                                description = "DOBAR";
                                break;
                            case 4:
                                description = "VRLO DOBAR";
                                break;
                            case 5:
                                description = "ODLIČAN";
                                break;
                            default:
                                throw new InvalidOperationException("Unexpected rounded average value.");
                        }

                        Console.WriteLine($"The average grade is {average:F2} ({description}).\n");

                    break;

                    //zadatak 6
                    case "4":

                        int sumDigit = 0;
                        bool doneDigit = false;
                        while (!doneDigit)
                        {
                            Console.WriteLine("Enter an integer, or enter 'done' to finish:");
                            string input = Console.ReadLine();
                            if (input == "done")
                            {
                                doneDigit = true;
                            }
                            else
                            {
                                int num;
                                if (int.TryParse(input, out num))
                                {
                                    int lastDigit = num % 10;
                                    sumDigit += lastDigit;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter an integer, or enter 'done' to finish.");
                                }
                            }
                        }

                        Console.WriteLine($"The sum of the last digits is {sumDigit}.\n");

                    break;

                    //zadatak 7
                    case "5":
                        Lottery lotteryPrint = new Lottery();
                        lotteryPrint.PrintNumbers();
                    break;

                    //zadatak 8
                    case "6":

                    int[,] matrix = new int[7, 7];
                    int currentNumber = 1;

                    for (int row = 0; row < 7; row++)
                    {
                        for (int column = 0; column < 7; column++)
                        {
                            matrix[row, column] = currentNumber;
                            currentNumber++;
                        }
                    }

                    using (StreamWriter writer = new StreamWriter("..\\..\\ticket.txt"))
                    {
                        writer.WriteLine("Lotto 6 od 45");
                        writer.WriteLine("--------------------------------------------------");
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int column = 0; column < matrix.GetLength(1); column++)
                            {
                                writer.Write(matrix[row, column] + "\t");
                            }
                            writer.WriteLine();
                        }
                    }

                    Console.WriteLine("The lotto ticket has been saved to ticket.txt\n");
                    break;

                    //zadatak 9
                    case "7":

                        
                    break;

                    //zadatak 10
                    case "8":
                        Lottery lotteryPdf = new Lottery();
                 
                        PdfDocument document = new PdfDocument();
                        PdfPage page = document.AddPage();
                      
                        XGraphics graphic = XGraphics.FromPdfPage(page);
                        XFont font = new XFont("Verdana", 12, XFontStyle.Bold);
                        XStringFormat format = new XStringFormat();
                        
                        string numbers = string.Join(" ", lotteryPdf.LotteryNumbers);
                        graphic.DrawString(numbers, font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), format);
                        
                        document.Save("..\\..\\LotteryNumbers.pdf");
                        document.Close();

                        Console.WriteLine("The lottery numbers have been saved to LotteryNumbers.pdf\n");
                     break;

                     default:
                            Console.WriteLine("Wrong number entered");
                            keepGoing = false;
                        
                            Console.ReadKey();
                     break;
                }
            }
        }
    }


    //kompletan kod ispod bi služio za case 7
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Sex { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
