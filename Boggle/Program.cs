
//Given a 4x4 matrix of letters chosen randomly from A-Z (with replacement), and a list L of English words (you can use any words you’d like).
//Write a program to output all the words present in the matrix per the rules of Boggle.
//Your program should be able to accept pre-set 4x4 matrices and word lists in a reasonable (text-based) format of your choosing.
// C# implementation of the approach
//Author: Roy He
//Date: 2021-09-03
using System;
using System.Collections.Generic;

namespace Boggle
{
	class Program
	{


		static bool IsInDictinary(String str, string[] arrDictionary)
		{
			for (int i = 0; i < arrDictionary.Length; i++)
			{

				if (str.ToUpper().Equals(arrDictionary[i].ToUpper()))
					return true;
			}
			return false;
		}


		static void SearchWords(char[,] arrMatrix,
								bool[,] visited,
								int i,
								int j,
								string[] arrDictionary,
								String sWord,
								List<string> listWords)
		{
			visited[i, j] = true;
			sWord = sWord + arrMatrix[i, j];


			int r, c;

			r = arrMatrix.GetLength(0);
			c = arrMatrix.GetLength(1);

			if (IsInDictinary(sWord, arrDictionary))
			{
				listWords.Add(sWord);
			}


			for (int row = i - 1; row <= i + 1 && row < r; row++)
				for (int col = j - 1; col <= j + 1 & col < c; col++)
					if (row >= 0 && col >= 0 && !visited[row, col])
						SearchWords(arrMatrix, visited, row, col, arrDictionary, sWord, listWords);

			sWord = "" + sWord[sWord.Length - 1];
			visited[i, j] = false;
		}


		static List<string> GetWords(char[,] arrMatrix, string[] arrDictionary)
		{
			int r, c;

			r = arrMatrix.GetLength(0);
			c = arrMatrix.GetLength(1);

			bool[,] bVisited = new bool[r, c];

			string sWord = "";
			List<string> lstWord = new List<string>();

			for (int i = 0; i < r; i++)
				for (int j = 0; j < c; j++)
					SearchWords(arrMatrix, bVisited, i, j, arrDictionary, sWord, lstWord);
			return lstWord;
		}


		public static void Main(String[] args)
		{


			List<string> lstWords;
			char[,] arrMatrix =  {
						   { 'B', 'L', 'N','M' },
						   { 'A', 'O', 'D','O' },
						   { 'H', 'N', 'T','Y' },
						   { 'T', 'H', 'P','E' }
			};
			string[] arrDictionary = {
				"Bold", "BAN", "BON", "LOAN", "MOTH", "THOD","NON", "TYPE" };

			int[] arrInt = new int[3];

		


			lstWords = GetWords(arrMatrix, arrDictionary);

			Console.WriteLine("Here are all the words from the dictinary that are present in the matrix per the rules of Boggle.");
			foreach (string sWord in lstWords)
			{
				Console.WriteLine(sWord);
			}
		}
	}

}


