///////////////////////////////////////////////////////////////////////////////
//
// Heat Map Generator Class
///////////////////////////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPFHeatMap
{
	public class HeatMap
	{
		#region · Data members ·
		private const int GradientNumber = 256; // Number of color gradients
		private List<HeatPoint> m_heat_points = new List<HeatPoint>(); // points of the heat map
		private readonly RadialGradientBrush[] m_brushes; // monochrome brushes used for heat map drawing
		#endregion

		#region · Constructor ·

		/// <summary>
		/// Default constructor
		/// </summary>
		public HeatMap()
		{
			// init brushes
			m_brushes = new RadialGradientBrush[GradientNumber];

			for(int i=0; i<m_brushes.Length;i++)
			{
				m_brushes[i] = new RadialGradientBrush(Color.FromArgb((byte)i, 255, 255, 255), Color.FromArgb(0, 255, 255, 255));
			}
		}
		#endregion

		#region · Public members ·

		/// <summary>
		/// Adds one point to the heat map
		/// </summary>
		/// <param name="in_heat_point">Point to add</param>
		public void AddHeatPoint(HeatPoint in_heat_point)
		{
			m_heat_points.Add(in_heat_point);
		}

		/// <summary>
		/// Clear content (points) of the heat map
		/// </summary>
		public void Clear()
		{
			m_heat_points.Clear();
		}

		/// <summary>
		/// Renders heat map content into the given canvas. The rendering is done using monochrome color (white) and need colorizing effect to have custom palette.
		/// </summary>
		/// <param name="in_canvas">Canvas to render</param>
		public void Render(Canvas in_canvas)
		{
			in_canvas.Children.Clear();

			foreach(HeatPoint point in m_heat_points)
			{
				Rectangle rect = new Rectangle();
				rect.Width = point.Intensity / 5;
				rect.Height = point.Intensity / 5;

				rect.Fill = m_brushes[point.Intensity];

				Canvas.SetLeft(rect, point.X - rect.Width / 2);
				Canvas.SetTop(rect, point.Y - rect.Height / 2);



				in_canvas.Children.Add(rect);
			}
		}
		#endregion
	} 
}
