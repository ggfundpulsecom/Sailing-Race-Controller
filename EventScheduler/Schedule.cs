using System;
using System.Threading;

namespace EventScheduler
{
	// delegate for OnTrigger() event
	public delegate void Invoke(string scheduleName);

	// enumeration for schedule types
	public enum ScheduleType { ONETIME, INTERVAL, DAILY, WEEKLY, MONTHLY };

	// base class for all schedules
	abstract public class Schedule : IComparable
	{
		public event Invoke OnTrigger;
		protected string m_name;		// name of the schedule
		protected ScheduleType m_type;	// type of schedule
		protected bool m_active;		// is schedule active ?

		protected DateTime m_startTime;	// time the schedule starts
		protected DateTime m_stopTime;	// ending time for the schedule
		protected DateTime m_nextTime;	// time when this schedule is invoked next, used by scheduler

		// m_fromTime and m_toTime are used to defined a time range during the day
		// between which the schedule can run.
		// This is useful to define a range of working hours during which a schedule can run
		protected TimeSpan m_fromTime;
		protected TimeSpan m_toTime;

		// Array containing the 7 weekdays and their status
		// Using DayOfWeek enumeration for index of this array
		// By default Sunday and Saturday are non-working days
		bool[] m_workingWeekDays = new bool[]{false, true, true, true, true, true, false};

		// time interval in seconds used by schedules like IntervalSchedule
		long m_interval = 0;

		// Accessor for type of schedule
		public ScheduleType Type
		{
			get { return m_type; }
		}

		// Accessor for name of schedule
		// Name is set in constructor only and cannot be changed
		public string Name 
		{
			get { return m_name; }
		}

		public bool Active
		{
			get { return m_active; }
			set { m_active = value; }
		}

		// check if no week days are active
		protected bool NoFreeWeekDay()
		{
			bool check = false;
			for (int index=0; index<7; check = check|m_workingWeekDays[index], index++);
			return check;
		}

		// Setting the status of a week day
		public void SetWeekDay(DayOfWeek day, bool On)
		{
			m_workingWeekDays[(int)day] = On;
			Active = true; // assuming

			// Make schedule inactive if all weekdays are inactive
			// If a schedule is not using the weekdays the array should not be touched
			if (NoFreeWeekDay())
				Active = false;
		}

		// Return if the week day is set active
		public bool WeekDayActive(DayOfWeek day)
		{
			return m_workingWeekDays[(int)day];
		}

		// Method which will return when the Schedule has to be invoked next
		// This method is used by Scheduler for sorting Schedule objects in the list
		public DateTime NextInvokeTime
		{
			get { return m_nextTime; }
		}

		// Accessor for m_startTime
		public DateTime StartTime
		{
			get { return m_startTime; }
			set
			{
				// start time can only be in future
				if (value.CompareTo(DateTime.Now) <= 0)
					throw new SchedulerException("Start Time should be in future");
				m_startTime = value;
			}
		}

		// Accessor for m_interval in seconds
		// Put a lower limit on the interval to reduce burden on resources
		// I am using a lower limit of 30 seconds
		public long Interval
		{
			get { return m_interval; }
			set {
				if (value < 30)
					throw new SchedulerException("Interval cannot be less than 60 seconds");
				m_interval = value;
			}
		}

		// Constructor
		public Schedule(string name, DateTime startTime, ScheduleType type)
		{
			StartTime = startTime;
			m_nextTime = startTime;
			m_type = type;
			m_name = name;
		}

		// Sets the next time this Schedule is kicked off and kicks off events on
		// a seperate thread, freeing the Scheduler to continue
		public void TriggerEvents()
		{
			CalculateNextInvokeTime(); // first set next invoke time to continue with rescheduling
			ThreadStart ts = new ThreadStart(KickOffEvents);
			Thread t = new Thread(ts);
			t.Start();
		}

		// Implementation of ThreadStart delegate.
		// Used by Scheduler to kick off events on a seperate thread
		private void KickOffEvents()
		{
			if (OnTrigger != null)
				OnTrigger(Name);
		}

		// To be implemented by specific schedule objects when to invoke the schedule next
		internal abstract void CalculateNextInvokeTime();

		// check to see if the Schedule can be invoked on the week day it is next scheduled 
		protected bool CanInvokeOnNextWeekDay()
		{
			return m_workingWeekDays[(int)m_nextTime.DayOfWeek];
		}

		// Check to see if the next time calculated is within the time range
		// given by m_fromTime and m_toTime
		// The ranges can be during a day, for eg. 9 AM to 6 PM on same day
		// or overlapping 2 different days like 10 PM to 5 AM (i.e over the night)
		protected bool IsInvokeTimeInTimeRange()
		{
			if (m_fromTime < m_toTime) // eg. like 9 AM to 6 PM
				return (m_nextTime.TimeOfDay > m_fromTime && m_nextTime.TimeOfDay < m_toTime);
			else // eg. like 10 PM to 5 AM
				return (m_nextTime.TimeOfDay > m_toTime && m_nextTime.TimeOfDay < m_fromTime);
		}

		// IComparable interface implementation is used to sort the array of Schedules
		// by the Scheduler
		public int CompareTo(object obj)
		{
			if (obj is Schedule)
			{
				return m_nextTime.CompareTo(((Schedule)obj).m_nextTime);
			}
			throw new Exception("Not a Schedule object");
		}
	}
}
