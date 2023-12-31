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

        private string _icon;
        public string Icon
        {
            get { return _icon; }
            set { SetProperty(ref _icon, value); }
        }

        private string _color;
        public string Color
        {
            get { return _color; }
            set { SetProperty(ref _color, value); }
        }

        private States _status;
		public States Status
		{
			get { return _status; }
			set { SetProperty(ref _status, value); }
		}

		private Action<object> _action;
		public Action<object> Action
		{
			get { return _action; }
			set { SetProperty(ref _action, value); }
		}

		private string _name;
		public string Name
		{
			get { return _name; }
			set { SetProperty(ref _name, value); }
		}
    }
}

