
using System;
using System.Windows.Forms;

namespace GraphForm
{
	public class DecimalTrackBar : TrackBar
	{
		private double val;
		private double scaleVal;
		private double min;
		private double max;
		private double increment;

//		private System.ComponentModel.Container components = null;

		public DecimalTrackBar() : base()
		{
			// Setup the control with a resolution of 1/10000
			base.Minimum = 0;			// Must be zero for calculations below to work
			base.Maximum = 10000;
			base.Value = 0;
			base.TickFrequency = 1000;

			max			= 100;
			min			= 0;
			val			= 0;
			increment	= 1;

			UpdateScaleVal();
			UpdateVal();
		}


//		protected override void Dispose(bool disposing)
//		{
//			if (disposing)
//			{
//				if (components != null)
//				{
//					components.Dispose();
//				}
//			}
//			base.Dispose(disposing);
//		}

		protected override void OnValueChanged(EventArgs e)
		{
Console.WriteLine("ValueChanged");
			base.OnValueChanged(e);
//			UpdateScaleVal();
//			UpdateVal();
		}


		protected override void OnScroll(EventArgs e)
		{
			base.OnScroll(e);
			UpdateScaleVal();
			UpdateVal();
		}

//		private void InitializeComponent()
//		{
//			components = new System.ComponentModel.Container();
//		}


//		public override int Value
//		{
//			get { return 1; }
//			set
//			{
//
//				Console.WriteLine("Value: " + value);
//			}
//		}

		public new double Value
		{
			get
			{
				return val;
			}

			set
			{
//				Console.WriteLine("Value called");
				if (val < min)
				{
					val = min;
				}
				else if (val > max)
				{
					val = max;
				}
				else
				{
					val = value;
				}
				UpdateScaleVal();

				// Push the change to base.Value
//				base.Value = (int)(scaleVal * base.Maximum);
//				OnValueChanged(null);
			}
		}

		
		public new double Minimum
		{
			get
			{
				return min;
			}

			set
			{
				min = value;
				UpdateVal();
			}
		}


		public new double Maximum
		{
			get
			{
				return max;
			}

			set
			{
				max = value;
				UpdateVal();
			}
		}


		// New functionality, so "new" keyword isn't necessary
		public double Increment
		{
			get
			{
				return increment;
			}

			set
			{
				increment = value;
			}
		}


		private void UpdateScaleVal()
		{
			// Don't hardcode slider resolution here in case we decide to change it in the constructor
			//   NOTE: Still assuming the base.Minimum is 0
			scaleVal = (double)base.Value / base.Maximum;
		}

		private void UpdateVal()
		{
			Value = scaleVal * (max - min) + min;
		}
	}
}

