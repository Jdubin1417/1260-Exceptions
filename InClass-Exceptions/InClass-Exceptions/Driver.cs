using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClass_Exceptions
{
    public class Driver
    {
        public static void Main()
        {
            //ArrayOutOfBoundsExample();
            //BadUserInputHandlingExample();
            //ArrayOutOfBoundsExample2();
            //MultipleCatches();
            //FinallyBlock();

            //M1();

            /*
            try
            {
                ThrowingYourOwnException();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            */

            bool valid = false;
            Person userPerson = null;

            Console.WriteLine("Please enter a name: ");
            string name = Console.ReadLine();

            while (!valid)
            {
                try
                {
                    Console.WriteLine("Please enter an age: ");
                    int age = int.Parse(Console.ReadLine());

                    userPerson = new Person(name, age);
                    valid = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("You entered a non-numeric age.");
                }
                //catch (AgeException e)
                //{
                //    Console.WriteLine(e.Message);
                //}
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(userPerson);
        }

        public static void ArrayOutOfBoundsExample()
        {
            int[] numbers = { 1, 2, 3 };

            try
            {
                //code that may fail
                for (int i = 0; i <= numbers.Length; i++)
                {
                    Console.WriteLine(numbers[i]);
                }
            }
            catch (IndexOutOfRangeException e)
            {
                //what to do instead of crashing
                Console.WriteLine($"The subscript you tried to access is beyond the size of the array.");
            }

            Console.WriteLine("The program continues...");
        }

        public static void BadUserInputHandlingExample()
        {
            bool enteredValidInput = false;

            while(!enteredValidInput)
            {
                try
                {
                    Console.Write("Please enter an integer: ");
                    int userInput = int.Parse(Console.ReadLine());
                    //int userInput = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"You entered {userInput}");
                    enteredValidInput = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Your input was not a valid integer. Please try again.");
                }
            }

            Console.WriteLine("Thank you for successfully entering an integer.");
        }

        public static void ArrayOutOfBoundsExample2()
        {
            int[] numbers = { 1, 2, 3 };

            try
            {
                for (int i = 0; i <= numbers.Length; i++)
                {
                    Console.WriteLine(numbers[i]);
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                //Console.WriteLine(e.StackTrace);
                //Console.WriteLine(e.Source);
            }

            Console.WriteLine("The program continues...");
        }

        public static void MultipleCatches()
        {
            //order of catches matter, need to go from most specific to most broad/generic
            //also cannot have more than one catch one the same type
            try
            {
                int myNum = int.Parse("a");
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine("Index out of range exception occured");
            }
            catch(FormatException e)
            {
                Console.WriteLine("Format exception occurred");
            }
            catch(Exception e)
            {
                Console.WriteLine("Some other exception occurred");
            }
        }

        public static void FinallyBlock()
        {
            try
            {
                Console.WriteLine("try executes");
                //int myNum = int.Parse("1");
                int myNum = int.Parse("a");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Format exception occurred");
            }
            catch (Exception e)
            {
                Console.WriteLine("Some other exception occurred");
            }
            finally //optional
            {
                //is ran regardless of whether or not you do the catches
                Console.WriteLine("finally executes");
            }
        }

        public static void M1()
        {
            M2();
        }
        public static void M2()
        {
            try
            {
                M3();
            }
            catch (FormatException e)
            {
                Console.WriteLine("handled in M2");
            }
        }
        public static void M3()
        {
            int myNum = int.Parse("a");

            /*
            try
            {
                int myNum = int.Parse("a");
            }
            catch (FormatException e)
            {
                Console.WriteLine("handled in M3");
            }
            */
        }

        public static double ThrowingYourOwnException()
        {
            int sum = 0;

            Console.Write("Please enter the number of elements: ");
            int numElements = int.Parse(Console.ReadLine());

            if(numElements <= 0)
            {
                throw new DivideByZeroException("Cannot divide by zero");
            }

            for(int i = 0; i < numElements; i++)
            {
                Console.Write($"Enter element {i+1}: ");
                int userNumber = int.Parse(Console.ReadLine());
                sum += userNumber;
            }
            
            double average = (double)sum / numElements;

            return average;
        }
    }
}
