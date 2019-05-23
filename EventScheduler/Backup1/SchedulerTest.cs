using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using EventScheduler;

namespace EventSchedulerTest
{
	/// <summary>
	/// Summary description for SchedulerTest.
	/// </summary>
	public class SchedulerTest : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button CloseBtn;
		private System.Windows.Forms.Button TestBtn;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SchedulerTest()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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
			this.button1 = new System.Windows.Forms.Button();
			this.CloseBtn = new System.Windows.Forms.Button();
			this.TestBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(25, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(168, 24);
			this.button1.TabIndex = 0;
			this.button1.Text = "Show Scheduler";
			this.button1.Click += new System.EventHandler(this.ShowSchedules);
			// 
			// CloseBtn
			// 
			this.CloseBtn.Location = new System.Drawing.Point(53, 78);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.Size = new System.Drawing.Size(112, 22);
			this.CloseBtn.TabIndex = 2;
			this.CloseBtn.Text = "Close";
			this.CloseBtn.Click += new System.EventHandler(this.OnClose);
			// 
			// TestBtn
			// 
			this.TestBtn.Location = new System.Drawing.Point(25, 42);
			this.TestBtn.Name = "TestBtn";
			this.TestBtn.Size = new System.Drawing.Size(168, 22);
			this.TestBtn.TabIndex = 11;
			this.TestBtn.Text = "Test Code";
			this.TestBtn.Click += new System.EventHandler(this.Test);
			// 
			// SchedulerTest
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(218, 109);
			this.Controls.Add(this.TestBtn);
			this.Controls.Add(this.CloseBtn);
			this.Controls.Add(this.button1);
			this.Name = "SchedulerTest";
			this.Text = "Testing Scheduler";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new SchedulerTest());
		}

		private void ShowSchedules(object sender, System.EventArgs e)
		{
			SchedulerUI.ShowSchedules();
		}

		private void Test(object sender, System.EventArgs e)
		{
			MessageBox.Show("Test will now create all types of schedules and opens Schedules View");

			// create and add different types of schedules
			Schedule s = new IntervalSchedule("Test_Interval", DateTime.Now.AddMinutes(1), 45, TimeSpan.Zero, new TimeSpan(TimeSpan.TicksPerDay));
			s.OnTrigger += new EventScheduler.Invoke(ScheduleCallBack);
			Scheduler.AddSchedule(s);
			s = new OneTimeSchedule("Test_Onetime", DateTime.Now.AddMinutes(1.5));
			s.OnTrigger += new EventScheduler.Invoke(ScheduleCallBack);
			Scheduler.AddSchedule(s);
			s = new DailySchedule("Test_daily", DateTime.Now.AddMinutes(2));
			s.OnTrigger += new EventScheduler.Invoke(ScheduleCallBack);
			Scheduler.AddSchedule(s);
			s = new WeeklySchedule("Test_weekly", DateTime.Now.AddMinutes(2.5));
			s.OnTrigger += new EventScheduler.Invoke(ScheduleCallBack);
			Scheduler.AddSchedule(s);
			s = new MonthlySchedule("Test_monthly", DateTime.Now.AddMinutes(3));
			s.OnTrigger += new EventScheduler.Invoke(ScheduleCallBack);
			Scheduler.AddSchedule(s);

			// kick off the Schedules View
			SchedulerUI.ShowSchedules();
		}

		private void ScheduleCallBack(string scheduleName)
		{
			MessageBox.Show("ScheduleCallBack called from " 
					+ scheduleName + " @ " + DateTime.Now.ToLongTimeString());
		}

		private void OnClose(object sender, System.EventArgs e)
		{
			Close();
		}
	}
}
