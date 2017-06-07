using System;
using System.Windows;

namespace WPFHeatMap
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		HeatMap m_heat_map = new HeatMap();

		public MainWindow()
		{
			InitializeComponent();

			cbColors.SelectedIndex = 0;
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			RenderContent();
		}

		private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			RenderContent();
		}

		/// <summary>
		/// Renders random heat map
		/// </summary>
		private void RenderContent()
		{
			m_heat_map.Clear();

			Random rRand = new Random();
			// Loop variables
			int x;
			int y;
			byte intense;

			// Lets loop 500 times and create a random point each iteration
			for (int i = 0; i < 1000; i++)
			{
				// Pick random locations and intensity
				x = rRand.Next(0, (int)(cHeatMap.ActualWidth - 1));
				y = rRand.Next(0, (int)(cHeatMap.ActualHeight - 1));
				intense = (byte)rRand.Next(0, 255);

				// Add heat point to heat points list
				m_heat_map.AddHeatPoint(new HeatPoint(x, y, intense));
			}

			m_heat_map.Render(cHeatMap);

		}
	}
}
