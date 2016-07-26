using System.ComponentModel;
using Xamarin.Forms;

namespace FormattedNumberEntrySample
{
	public partial class FormattedNumberEntryPage : ContentPage
	{
		public FormattedNumberEntryPage()
		{
			Padding = 20;


			InitializeComponent();
			FormattedEntry.PropertyChanged += FormattedEntry_PropertyChanged;
			SetValue.Clicked += (s, a) =>
			{
				int newValue;
				if (System.Int32.TryParse(NormalEntry.Text, out newValue))
					FormattedEntry.Value = newValue;
			};
		}

		void FormattedEntry_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName.Equals(nameof(FormattedNumberEntry.Value)))
			{
				FormattedLabel.Text = FormattedEntry.Value.ToString();
			}
		}
	}
}

