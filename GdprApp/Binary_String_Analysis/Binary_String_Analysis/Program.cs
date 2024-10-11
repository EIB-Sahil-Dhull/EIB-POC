using System;
class Binary_String
{
	public string binary_string(char[] str, int n)
	{
		int count0 = 0;
		int count1 = 0;

		for (int i = 0; i < n; i++)
		{
			if (str[i] != '0' && str[i] != '1')
			{
				return "Not a good string";
			}
			if (str[i] == '0')
			{
				count0++;
			}
			else { count1++; }

			if (count1 < count0)
			{
				return "Not a good string";
			}

		}
		if (count0 == count1)
		{
			return "Good String";

		}
		else
		{
			return "Not a Good String";
		}
		
	}

	public void run_test()
	{
		string[] input_strings =
		{
			"10101010","03526700","1100101010","101011001","10100101010"
		};
		string[] expected_value = { "Good String", "Not A Good String", "Good String", "Not A Good String", "Not A Good String" };

		Binary_String binary = new Binary_String();
		

		for(int i = 0;i < input_strings.Length; i++)
		{
			
			char[] str = input_strings[i].ToCharArray();
			int n = str.Length;
			Console.WriteLine( $"Input string: {input_strings[i]} Current Output: {binary.binary_string(str,n)} Expected Output:{expected_value[i]}");
		}


		
	}
	public static void Main(String[] args)
	{
		Binary_String binary = new Binary_String();
		binary.run_test();
	}
}
