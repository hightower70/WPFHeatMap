///////////////////////////////////////////////////////////////////////////////
//
// Heat Map Generator Class
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace WPFHeatMap
{
	public class HeatMap : FrameworkElement
	{
		#region · Data members ·
		private const int GradientNumber = 256; // Number of color gradients

		private VisualCollection m_heat_map_visuals;

		private List<HeatPoint> m_heat_points = new List<HeatPoint>(); // points of the heat map
		private readonly RadialGradientBrush[] m_brushes; // monochrome brushes used for heat map drawing
		#endregion

		#region · Constructor ·

		/// <summary>
		/// Default constructor
		/// </summary>
		public HeatMap()
		{
			// init visuals
			m_heat_map_visuals = new VisualCollection(this);

			// init brushes
			m_brushes = new RadialGradientBrush[GradientNumber];

			for (int i = 0; i < m_brushes.Length; i++)
			{
				m_brushes[i] = new RadialGradientBrush(Color.FromArgb((byte)i, 255, 255, 255), Color.FromArgb(0, 255, 255, 255));
			}
		}
		#endregion

		#region · Visual drawing overides ·
		protected override int VisualChildrenCount
		{
			get
			{
				return m_heat_map_visuals.Count;
			}
		}

		protected override Visual GetVisualChild(int index)
		{
			if (index < 0 || index >= m_heat_map_visuals.Count)
				throw new ArgumentOutOfRangeException("index");

			return m_heat_map_visuals[index];
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
		public void Render()
		{
			double width_height;

			// clear visuals
			m_heat_map_visuals.Clear();

			// draw heatmap points
			DrawingVisual drawing_visual = new DrawingVisual();

			using (DrawingContext dc = drawing_visual.RenderOpen())
			{
				foreach (HeatPoint point in m_heat_points)
				{
					width_height = point.Intensity / 5;

					dc.DrawRectangle(m_brushes[point.Intensity], null, new Rect(point.X - width_height / 2, point.Y - width_height / 2, width_height, width_height));
				}

				m_heat_map_visuals.Add(drawing_visual);
			}
		}

		#endregion
	}
}
