using System;
using System.ComponentModel;
using FormattedNumberEntrySample;
using FormattedNumberEntrySample.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(FormattedNumberEntry), typeof(FormattedNumberEntryRenderer))]
namespace FormattedNumberEntrySample.iOS
{
	public class FormattedNumberEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null)
			{
				Control.EditingChanged -= Control_EditingChanged;
			}
			if (e.NewElement != null)
			{
				Control.EditingChanged += Control_EditingChanged;
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName.Equals(nameof(FormattedNumberEntry.Value)))
			{
				var element = ((FormattedNumberEntry)Element);
				// 5. Format number, and place the formatted text in newText
				var newText = $"{element.Value:#,##0}";

				// 6. Set the Text property of our control to newText
				Control.Text = newText;

			}
			else
			{
				base.OnElementPropertyChanged(sender, e);
			}

		}

		void Control_EditingChanged(object sender, EventArgs e)
		{
			var element = ((FormattedNumberEntry)Element);
			// Oh boy, thank you internet: http://stackoverflow.com/a/34922332

			// 1. Stop listening for changes on our control Text property
			if (!element.ShouldReactToTextChanges) return;
			element.ShouldReactToTextChanges = false;

			// 2. Get the current cursor position
			var selectedRange = Control.SelectedTextRange;

			// 3. Take the control’s text, lets name it oldText
			var oldText = Control.Text;

			// 4. Parse oldText into a number, lets name it number
			var number = FormattedNumberEntry.DumbParse(oldText);
			element.Value = number;

			// 5. Format number, and place the formatted text in newText
			var newText = $"{number:#,##0}";

			// 6. Set the Text property of our control to newText
			Control.Text = newText;

			// 7. Calculate the new cursor position
			var change = -1 * (oldText.Length - newText.Length);
			var newPosition = Control.GetPosition(selectedRange.Start, (nint)change);

			// 8. Set the new cursor position
			if (newPosition != null) // before we fail miserably
			{
				Control.SelectedTextRange = Control.GetTextRange(newPosition, newPosition);
			}

			// 9. Start listening for changes on our control’s Text property
			element.ShouldReactToTextChanges = true;
		}
	}
}

