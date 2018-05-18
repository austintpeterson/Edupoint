using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;

using DebugSession;

namespace DebugSession
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblTotal;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblMales;
		private System.Windows.Forms.Label lbl;
		private System.Windows.Forms.Button btnCount;
		private System.Windows.Forms.Label lblFemale;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.btnCount = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblFemale = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMales = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCount
            // 
            this.btnCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCount.Location = new System.Drawing.Point(96, 130);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(120, 34);
            this.btnCount.TabIndex = 0;
            this.btnCount.Text = "&Count";
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total Number of Students:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(230, 94);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(116, 33);
            this.lblTotal.TabIndex = 2;
            // 
            // lblFemale
            // 
            this.lblFemale.Location = new System.Drawing.Point(230, 23);
            this.lblFemale.Name = "lblFemale";
            this.lblFemale.Size = new System.Drawing.Size(116, 34);
            this.lblFemale.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(13, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(217, 34);
            this.label4.TabIndex = 3;
            this.label4.Text = "Total Females:";
            // 
            // lblMales
            // 
            this.lblMales.Location = new System.Drawing.Point(230, 58);
            this.lblMales.Name = "lblMales";
            this.lblMales.Size = new System.Drawing.Size(116, 34);
            this.lblMales.TabIndex = 6;
            // 
            // lbl
            // 
            this.lbl.Location = new System.Drawing.Point(13, 58);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(217, 34);
            this.lbl.TabIndex = 5;
            this.lbl.Text = "Total Males:";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.ClientSize = new System.Drawing.Size(224, 174);
            this.Controls.Add(this.lblMales);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.lblFemale);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCount);
            this.Name = "Form1";
            this.Text = "Debug Session";
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void label1_Click(object sender, System.EventArgs e)
		{
		

		}

		private void btnCount_Click(object sender, System.EventArgs e)
		{
			XmlDocument studentData = null;
			XmlNodeList studentList = null;
			TotalClass totalClass = new TotalClass();//used to be null
            //need instance because TotalClass is reference (user-def) type and not 
            //a value type.  Will not default to anything.

			string gender = "";

			studentData = new XmlDocument();
					studentData.LoadXml("<root>"
						+ "<STUDNT ID=\"7\" Gender=\"M\"></STUDNT>"
						+ "<STUDNT ID=\"16\" Gender=\"F\"></STUDNT>"
						+ "<STUDNT ID=\"22\" Gender=\"F\"></STUDNT>"
						+ "<STUDNT ID=\"25\" Gender=\"M\"></STUDNT>"
						+ "<STUDNT ID=\"27\" Gender=\"F\"></STUDNT>"
						+ "<STUDNT ID=\"32\" Gender=\"M\"></STUDNT>"
						+ "<STUDNT ID=\"35\" Gender=\"f\"></STUDNT>"
						+ "<STUDNT ID=\"45\" Gender=\"M\"></STUDNT>"
						+ "<STUDNT ID=\"4423453244\" Gender=\"F\"></STUDNT>"
						+ "<STUDNT ID=\"44344\" Gender=\"F\"></STUDNT>"
						+ "</root>");

			studentList	= studentData.SelectNodes("//STUDNT");//changed to recognize proper label
			if(studentList != null && studentList.Count > 0)
			{
				foreach(XmlElement student in studentList)
				{
					gender = student.GetAttribute("Gender");
					switch(gender.ToUpper())//to fix XML case issues (f vs F, m vs M)
					{
						case "F":
							totalClass.Females++;
							break;

						default:
						case "M":
							totalClass.Males++;
							break;
					}
				}// end loop
			}

			this.lblMales.Text = totalClass.Males.ToString();
			this.lblFemale.Text = totalClass.Females.ToString();
			this.lblTotal.Text = (totalClass.Females + totalClass.Males).ToString();


		}//btnCount_Click
	}
}
