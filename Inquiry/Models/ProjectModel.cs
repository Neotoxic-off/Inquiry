using System;
using System.Collections.ObjectModel;

namespace Inquiry.Models
{
	public class ProjectModel: BaseModel
	{
		private ObservableCollection<IO.FileModel> _files;
		public ObservableCollection<IO.FileModel> Files
		{
			get { return _files; }
			set { SetProperty(ref _files, value); }
		}
    }
}

