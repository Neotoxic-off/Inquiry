using System;
namespace Inquiry.Models.IO
{
	public class FileModel : BaseModel
	{
		private string _path;
		public string Path
		{
			get { return _path; }
			set { SetProperty(ref _path, value); }
		}

        private string _content;
        public string Content
        {
            get { return _content; }
            set { SetProperty(ref _content, value); }
        }
    }
}

