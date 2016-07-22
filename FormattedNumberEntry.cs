using System;
using Xamarin.Forms;

namespace FormattedNumberEntrySample
{
	public class FormattedNumberEntry : Entry
	{

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

		//protected override void OnPropertyChanged(string propertyName = null)
		//{
		//	if (nameof(this.Text).Equals(propertyName))
		//	{
		//		if (!_shouldReactToTextChange) return;

		//		_shouldReactToTextChange = false;

		//		var oldText = this.Text;
		//		var number = DumbParse(oldText);
		//		var newText = $"{number:#,###}";

		//		this.Text = newText;

		//		_shouldReactToTextChange = true;
		//	}
		//	base.OnPropertyChanged(propertyName);
		//}
	}
}

