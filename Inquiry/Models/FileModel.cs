using System;
namespace Inquiry.Models
{
	public class FileModel : BaseModel
	{
		private string _path;
		public string Path
		{
			get { return _path; }
			set { SetProperty(ref _path, value); }
		}

        private List<string> _content;
        public List<string> Content
        {
            get { return _content; }
            set { SetProperty(ref _content, value); }
        }
    }
}

