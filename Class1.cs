using System;

public class Class1
{
	public Class1()
	{
        void main()
        {

            int n = 8;
            for (int i = 0; i < n; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            for (int i = 0; i < n / 2 - 1; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j == 0)
                    {
                        Console.Write("*");
                    }
                    else if (j == n - 1)
                    {
                        Console.WriteLine("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            for (int i = 0; i < n / 2 + 1; i++)
            {
                Console.WriteLine("*");
            }
            Console.ReadKey();
        }
	}
}
