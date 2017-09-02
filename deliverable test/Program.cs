using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deliverable_test
{
	class Program
	{
		static void Main(string[] args)
		{
			string input1, input2;
			int remainderNum1, remainderNum2, leftoverNum1, leftoverNum2;//values that will be used to seperate digits
			int sum1 = 0;//values to add last digits, base as zero
			int sumElse = 0;//named sumElse for all other values that will be summed after last digit
			char doAgain;
			bool repeat = true;
			while (repeat == true)
			{
				try
				{
					Console.WriteLine("Please enter a positive integer");
					input1 = Console.ReadLine();
					int num1 = Int32.Parse(input1);
					uint positive1 = (uint)(num1);//to validate input is positive

					Console.WriteLine("Please enter a second positive integer with the same amount of numbers as the first");
					input2 = Console.ReadLine();
					int num2 = Int32.Parse(input2);
					uint positive2 = (uint)(num2);

					if (input1.Length == input2.Length)//to validate inputs are both same length
					{
						repeat = false;
					}
					else
					{
						Console.WriteLine("Value does not match the number of digits from first, Please try again");
						repeat = true;
					}
					if (num1 > 1)
					{
						remainderNum1 = num1 % 10;
						leftoverNum1 = num1 / 10;
						remainderNum2 = num2 % 10;
						leftoverNum2 = num2 / 10;
						sum1 = remainderNum1 + remainderNum2;//last set of digits
						Console.WriteLine("The sum of the last set of digits of both integers is {0}", sum1);
						for (;;)//repeats infinitely 
						{
							remainderNum1 = leftoverNum1 % 10;
							leftoverNum1 = leftoverNum1 / 10;
							remainderNum2 = leftoverNum2 % 10;
							leftoverNum2 = leftoverNum2 / 10;
							sumElse = remainderNum2 + remainderNum1;//for all sets of digits before the last
							Console.WriteLine("The sum of the digits to the left of the last set of digits of both integers is {0}", sumElse);
							if (leftoverNum1 < 1)//stops repeating when num1 only has 1st digit left
							{
								break;
							}
						}
						if (sum1 == sumElse)//checks if values are equal
						{
							Console.WriteLine("True, digits in the same place of the two inputs, all add up to the same value");
						}
						else
						{
							Console.WriteLine("False, digits in the same place of the two inputs do not add up to the same value");
						}
					}

				}
				catch (FormatException)
				{
					Console.WriteLine("Input is not a valid string of digits, Please try again");
					repeat = true;
				}
				catch (OverflowException)
				{
					Console.WriteLine("Number is too long, Please try again");
					repeat = true;
				}
				catch (DivideByZeroException)
				{
					Console.WriteLine("Value is zero, Please try again");
					repeat = true;
				}
				finally
				{
					repeat = false;
				}
				Console.WriteLine("Would you like to run this program again? (Y or N)");
				doAgain = Convert.ToChar(Console.ReadLine());
				if (doAgain == 'y' || doAgain == 'Y')
				{
					repeat = true;
				}
				else
				{
					repeat = false;
				}
			}
		}
	}
			
}
