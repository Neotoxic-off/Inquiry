using System;
namespace Inquiry.Models
{
	public class ScanStepModel: BaseModel
	{
		public enum States
		{
			Queue,
			Skipped,
			Running,
			Paused,
			Stopped,
			Error,
			Success
		}

		private States _status;
		public States Status
		{
			get { return _status; }
			set { SetProperty(ref _status, value); }
		}
    }
}

