using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;//new
using System.Linq;//new (for fast sorting)

namespace Sorter
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnRun;
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
			this.btnRun = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnRun
			// 
			this.btnRun.Location = new System.Drawing.Point(32, 24);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(200, 56);
			this.btnRun.TabIndex = 0;
			this.btnRun.Text = "&Run";
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(264, 104);
			this.Controls.Add(this.btnRun);
			this.Name = "Form1";
			this.Text = "Sorter";
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRun_Click(object sender, System.EventArgs e)
		{
            //parse
            List<Person> personList = parse();

            //sort
            personList = sort(personList);

            //write
            write(personList);
        }

        //parse input.txt into a Person obj List
        private List<Person> parse()
        {
            string fileName = "input.txt";
            List<Person> parsedList = new List<Person>();

            //read in file
            try
            {
                var lines = File.ReadAllLines(fileName);
                for (var i = 0; i < lines.Length; i += 1)
                {
                    var line = lines[i];
                    //throw out empty lines - guard clause
                    if (String.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }else
                    {
                        Person p = new Person(line);
                        parsedList.Add(p);
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                System.Windows.Forms.MessageBox.Show("Exception: "+e.Message);
            }

            return parsedList; 
        }

        //sort obj List by last and then first name
        private List<Person> sort(List<Person> list)
        {
            return list.OrderBy(p => p.getlName()).ThenBy(p => p.getfName()).ToList();
        }

        //write to output.txt
        private void write(List<Person> list)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("output.txt"))
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        //write single lastnames without whitespace (Marr)
                        if (list[i].getfName() == "")
                        {
                            writer.WriteLine(list[i].getlName());
                        }
                        else
                        {
                            writer.WriteLine(list[i].getfName() + " " + list[i].getlName());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                System.Windows.Forms.MessageBox.Show("Exception: " + e.Message);
            }
        } 
	}
}
