using System;
using System.Globalization;

public class Program
{
	private const double Epsilon = 0.0001;
	private const int TermsCount = 50;
	private const double XStart = 0.1;
	private const double XEnd = 0.8;
	private const int PointsCount = 10;

	public static void Main()
	{
		CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
		var step = (XEnd - XStart) / PointsCount;

		for (var i = 0; i < PointsCount; i++)
		{
			var x = XStart + i * step;
			var sumByTermsCount = ComputeSumByTermsCount(x);
			var sumByAccuracy = ComputeSumByAccuracy(x);
			var exactValue = ComputeExactValue(x);
			PrintRow(x, sumByTermsCount, sumByAccuracy, exactValue);
		}
	}

	private static double ComputeSumByTermsCount(double x)
	{
		var sum = 0.0;

		for (var n = 1; n <= TermsCount; n++)
			sum += GetTerm(x, n);
		return sum;
	}

	private static double ComputeSumByAccuracy(double x)
	{
		var sum = 0.0;
		var n = 1;

		while (GetTermAmplitude(n) >= Epsilon)
		{
			sum += GetTerm(x, n);
			n++;
		}
		return sum;
	}

	private static double ComputeExactValue(double x)
	{
		return 0.5 - Math.PI / 4.0 * Math.Abs(Math.Sin(x));
	}

	private static double GetTerm(double x, int n)
	{
		return Math.Cos(2.0 * n * x) / (4.0 * n * n - 1.0);
	}

	private static double GetTermAmplitude(int n)
	{
		return 1.0 / (4.0 * n * n - 1.0);
	}

	private static void PrintRow(
		double x, 
		double sumByTermsCount, 
		double sumByAccuracy, 
		double exactValue)
	{
		Console.WriteLine("X={0:F2}\tSN={1:F8}\tSE={2:F8}\tY={3:F8}", 
			x, 
			sumByTermsCount, 
			sumByAccuracy, 
			exactValue);
	}
}