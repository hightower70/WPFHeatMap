///////////////////////////////////////////////////////////////////////////////
//
// Heat Map Point
///////////////////////////////////////////////////////////////////////////////
namespace WPFHeatMap
{
	public struct HeatPoint
	{
		public int X;
		public int Y;
		public byte Intensity;

		public HeatPoint(int in_x, int in_y, byte in_intensity)
		{
			X = in_x;
			Y = in_y;
			Intensity = in_intensity;
		}
	}
}
