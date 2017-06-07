using System.Windows;

namespace WPFHeatMap
{
	public static class AttachedTitle
	{
		public static readonly DependencyProperty TitleProperty =
			DependencyProperty.RegisterAttached(
				"Title",
				typeof(string),
				typeof(AttachedTitle),
				new PropertyMetadata(string.Empty));

		public static void SetTitle(DependencyObject obj, string value)
		{
			obj.SetValue(TitleProperty, value);
		}

		public static string GetTitle(DependencyObject obj)
		{
			return (string)obj.GetValue(TitleProperty);
		}

	}
}
