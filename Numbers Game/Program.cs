using System;

namespace Numbers_Game
{
    internal class Program
    {
        static void StartSequence()
        {
            int n = 0;
            while (true)
            {
                Console.Write("Enter a number greater than zero: ");
                n = Convert.ToInt32(Console.ReadLine());
                if (n > 0) break;
                Console.WriteLine("Your input is not valid please re input again ");               
            }
            int[] arr = new int[n];
            arr = Populate(arr);
            int sum = GetSum(arr);          
            int product = GetProduct(arr, sum);
            decimal quotient = GetQuotient(product);
            Console.WriteLine("Your array size is: " + arr.Length);
            Console.Write("The numbers in the array are: ");
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                if(i != arr.Length - 1) Console.Write(",");
            }
            Console.WriteLine();
            Console.WriteLine("The sum of the array is: " + sum);
            if (sum == 0) Console.WriteLine("Product = 0");
            else
            {
                Console.WriteLine("Product = " + sum + " * " + product / sum + " = " + product);
            }
            
            if (quotient != 0) Console.WriteLine("Quotient = " + product + " / " + product / quotient + " = " + quotient);
            else
            {
                Console.WriteLine("Quotient  = " + quotient);
            }

        }
        static int[] Populate(int[] arr)
        {
           for(int i = 0; i < arr.Length; i++)
            {
                Console.Write("Enter a number " + (i+1) + " of " + arr.Length + ": ");
                int n = Convert.ToInt32(Console.ReadLine());
                arr[i] = n;
            }
           return arr;
        }
        static int GetSum (int[] arr)
        {
            int sum = 0;
            for(var i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            if (sum < 20) throw new Exception($"Value of { sum } is too low");
            return sum;
        }
        static int GetProduct (int[] arr , int sum)
        {
            Console.Write("Enter a number between 1 and " + arr.Length + ": ");
            int n = Convert.ToInt32(Console.ReadLine());
            if(!(n > 0 && n<= arr.Length)) throw new IndexOutOfRangeException();
            int product = sum * arr[n-1];
            return product;
        }
        static decimal GetQuotient(int product)
        {
            Console.Write("Enter a number to divide the Product("+ product + ") by: ");
            int n = Convert.ToInt32(Console.ReadLine());
            try
            {
                return decimal.Divide(product, n);
            }
            catch (DivideByZeroException)
            {
                return 0;
            }
            
        }
        static void Main(string[] args)
        {
            while (true)
            {
                
                try
                {
                    StartSequence();
                }
                catch (FormatException ex)
                {
                    
                    Console.WriteLine("You dont enter a number ");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again ");      
                    continue;
                }
                catch (IndexOutOfRangeException ex)
                {
                    
                    Console.WriteLine("You dont enter a number outside the array bounds ");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again ");
                    continue;
                }
                catch(Exception ex)
                {
                    
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again ");
                    continue;

                }
                finally {
                    Console.WriteLine("Program is complete");
                }
                break;
                
            }
            
        }
    }
}
