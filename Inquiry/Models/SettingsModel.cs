using System;
namespace Inquiry.Models
{
	public class SettingsModel: BaseModel
	{
		private Version _version;
		public Version Version
		{
			get { return _version; }
			set { SetProperty(ref _version, value); }
		}

        private string _author;
        public string Author
        {
            get { return _author; }
            set { SetProperty(ref _author, value); }
        }
    }
}

