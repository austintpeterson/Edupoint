using System;

namespace DebugSession
{
	/// <summary>
	/// Summary description for TotalClass.
	/// </summary>
	public class TotalClass
	{
		/// <summary>
		/// Gets and Sets number of males
		/// </summary>
		public int Males
		{
			set{this.males = value;}
			get{return this.males;}
		}
        //changed to 0 so it counts from the correct start int.
		private int males = 0;

		/// <summary>
		/// Gets and Sets number of females
		/// </summary>
		public int Females
		{
			set{this.females = value;}
			get{return this.females;}
		}
		private int females = 0;
	}//end class
}
