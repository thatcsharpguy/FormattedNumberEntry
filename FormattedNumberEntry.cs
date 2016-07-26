using System;
using Xamarin.Forms;

namespace FormattedNumberEntrySample
{
	public class FormattedNumberEntry : Entry
	{
		public static readonly BindableProperty ValueProperty =
			BindableProperty.Create(nameof(Value), typeof(int), typeof(FormattedNumberEntry), 0);
		
		public int Value
		{
			get { return (int)GetValue(ValueProperty); }
			set { SetValue(ValueProperty, value); }
		}

		public bool ShouldReactToTextChanges { get; set; }

		public FormattedNumberEntry()
		{
			ShouldReactToTextChanges = true;
		}

		public static int DumbParse(string input)
		{
			if (input == null) return 0;

			var number = 0;
			int multiply = 1;

			for (int i = input.Length - 1; i >= 0; i--)
			{
				if (Char.IsDigit(input[i]))
				{
					number += (input[i] - '0') * (multiply);
					multiply *= 10;
				}
			}
			return number;
		}
	}
}

