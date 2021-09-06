

	//Write a program that creates arithmetic expressions by inserting + or - or nothing between the ordered digits 1,2,…,9 such
	//that the expression evaluates to 100. For example 1 + 2 + 3 - 4 + 5 + 6 + 78 + 9 = 100,
	//so this expression would be output by your program.
	// C# implementation of the approach
	//Author: Roy He
	//Date: 2021-09-03
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using System.Text.RegularExpressions;
	

namespace ArithmeticExpression
	{
		class Program
		{

			public static void Main()
			{

				List<string> exp = ArithmeticExpression();
				Console.WriteLine("Here are all the expressions that evalulated to 100:");
				foreach (string s in exp)
				{
					Console.WriteLine(s);
				}

			}

			public static List<string> ArithmeticExpression()
			{
				string sOperator = "+- ";
				string sExpression = "";
				int a, b, c, d, e, f, g, h;
				int result;
				List<string> lstStr = new List<string>();

				//Loop through all the possibility.
				//inserting "+" or "-" or space " " between the ordered digits 1,2,…,9, we will remove the space at the end.
				//We will call "+", "-" and " " an operator 
				//Since there are 9 digit, there are 8 position in between there digits, each position we can insert one operator,
				//and there are three possible operators for one position, so we will have 8 nested loops, each loop have 3 iterations("+", "-", " ").   
				for (a = 0; a <= sOperator.Length - 1; a++)
				{
					for (b = 0; b <= sOperator.Length - 1; b++)
					{
						for (c = 0; c <= sOperator.Length - 1; c++)
						{
							for (d = 0; d <= sOperator.Length - 1; d++)
							{
								for (e = 0; e <= sOperator.Length - 1; e++)
								{
									for (f = 0; f <= sOperator.Length - 1; f++)
									{
										for (g = 0; g <= sOperator.Length - 1; g++)
										{
											for (h = 0; h <= sOperator.Length - 1; h++)
											{

												sExpression = "1" + sOperator[a] + "2" + sOperator[b] + "3" + sOperator[c] + "4" + sOperator[d] + "5" +
													sOperator[e] + "6" + sOperator[f] + "7" + sOperator[g] + "8" + sOperator[h] + "9";
												
												sExpression = Regex.Replace(sExpression, @"\s", "");

											    //store all the digit and operator combination in the token stack
												Stack<string> sStk = new Stack<string>(Regex.Split(sExpression, @"([+-])").Reverse());
												result = MathEvaluator.Evaluate(sStk);
												if (result == 100)
												{
													lstStr.Add(sExpression);
												}


											}
										}
									}
								}
							}
						}
					}
				}

				return lstStr;
			}

		}

	//Include * and / operator for future extension
	//This implmentation is without Stack for storing the temporary result
	class MathEvaluator
	{
		public static int Evaluate(Stack<string> sStk)
		{
			if (sStk == null || sStk.Count == 0)
			{
				return 0;
			}
			
			int result = 0;

			Func<int, int, int> operation = null;
			while (sStk.Count > 0)
			{
				var s = sStk.Pop();

				switch (s)
				{
					case "+":
						operation = (result, param) => result + param;
						break;
					case "-":
						operation = (result, param) => result - param;

						break;
					case "*":
						operation = (result, param) => result * param;
						break;
					case "/":
						operation = (result, param) => result / param;
						break;

					//When Value is a number
					default:
						int input = int.Parse(s, NumberStyles.Any);
						if (operation != null)
							result = operation(result, input);
						else
							result = input;

						input = 0;
						break;
				}
			}
			return result;
		}
	}

	//Include * and / operator for future extension
	//This implmentation is using Stack for storing the temporary  result
	//class MathEvaluator
	//{
	//	public static int Evaluate(Stack<string> sStk)
	//	{
	//		if (sStk == null || sStk.Count == 0)
	//		{
	//			return 0;
	//		}
	//		Stack<int> intStk = new Stack<int>();
	//		int result = 0;

	//		Func<int, int> operation = null;
	//		while (sStk.Count > 0)
	//		{
	//			var s = sStk.Pop();

	//			switch (s)
	//			{
	//				case "+":
	//					operation = (param) =>  intStk.Pop() + param;  
	//					break;
	//				case "-":
	//					operation = (param) => { return intStk.Pop() - param; };
	//					break;
	//				case "*":
	//					operation = (param) => { return intStk.Pop() * param; };
	//					break;
	//				case "/":
	//					operation = (param) => { return intStk.Pop() / param; };
	//					break;

	//				//When Value is a number
	//				default:
	//					result = int.Parse(s, NumberStyles.Any);

	//					//If there is a number in the result stack, take out the number, and appy the operation on the number with the number value from token stack 
	//					//Here intStk.count always greate than 0 except when the number value is the first number value from token stack starting with digit 1.
	//					if (intStk.Count > 0)
	//					{
	//						result = operation(result);
	//					}
	//					//And put it back to the result stack
	//					intStk.Push(result);
	//					break;
	//			}
	//		}
	//		return result;
	//	}
	//}
}



