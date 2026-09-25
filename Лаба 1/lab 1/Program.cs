using System;
using System.Globalization;

public class Program
{
	public static void Main()
	{
		CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
		CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

		Console.WriteLine("TASK 1");
		RunTask1();
		Console.WriteLine("\nTASK 2");
		RunTask2();
		Console.WriteLine("\nTASK 3");
		RunTask3();
	}

	public static void RunTask1()
	{
		int nInput, mInput;
		bool isParsed;
		double x;

		do
		{
			Console.Write("n?");
			isParsed = int.TryParse(Console.ReadLine(), out nInput);
		} while (!isParsed);

		do
		{
			Console.Write("m?");
			isParsed = int.TryParse(Console.ReadLine(), out mInput);
		} while (!isParsed);
		
		var n = nInput;
		var m = mInput;
		var expression1 = n++ * m;
		Console.WriteLine("n={0} m={1} n++*m={2}", n, m, expression1);

		n = nInput;
		m = mInput;
		var expression2 = m-- < n;
		Console.WriteLine("n={0} m={1} m--<n={2}", n, m, expression2);

		n = nInput;
		m = mInput;
		var expression3 = ++m > n;
		Console.WriteLine("n={0} m={1} ++m>n={2}", n, m, expression3);

		do
		{
			Console.Write("x?");
			isParsed = double.TryParse(Console.ReadLine(), out x);
		} while (!isParsed);

		var expression4 = Math.Cos(Math.Atan(x));
		Console.WriteLine("x={0} Cos(Arctg(x))={1}", x, expression4);
	}

	public static bool CheckInArea(double x, double y) =>
		x >= 0 && x <= 5 && y >= -7 && y <= (5.0 - x);

	public static void RunTask2()
	{
		double x, y;
		bool isParsed;
		do
		{
			Console.Write("x?");
			isParsed = double.TryParse(Console.ReadLine(), out x);
		} while (!isParsed);

		do
		{
			Console.Write("y?");
			isParsed = double.TryParse(Console.ReadLine(), out y);
		} while (!isParsed);

		var isInside = CheckInArea(x, y);
		Console.WriteLine("Point ({0}, {1}) is in area: {2}", x, y, isInside);
	}

	public static void CalculateForFloat()
	{
		var a = 1000.0f;
		var b = 0.0001f;

		var part1 = (float)Math.Pow(a - b, 4);
		var part2 = (float)Math.Pow(a, 4) + 6.0f * (float)Math.Pow(a, 2) * (float)Math.Pow(b, 2) + (float)Math.Pow(b, 4);
		var part3 = -4.0f * a * (float)Math.Pow(b, 3) - 4.0f * (float)Math.Pow(a, 3) * b;
		var result = (part1 - part2) / part3;

		Console.WriteLine("Result for float: {0}", result);
	}

	public static void CalculateForDouble()
	{
		var a = 1000.0;
		var b = 0.0001;

		var part1 = Math.Pow(a - b, 4);
		var part2 = Math.Pow(a, 4) + 6.0 * Math.Pow(a, 2) * Math.Pow(b, 2) + Math.Pow(b, 4);
		var part3 = -4.0 * a * Math.Pow(b, 3) - 4.0 * Math.Pow(a, 3) * b;
		var result = (part1 - part2) / part3;

		Console.WriteLine("Result for double: {0}", result);
	}

	public static void RunTask3()
	{
		CalculateForFloat();
		CalculateForDouble();
	}
}