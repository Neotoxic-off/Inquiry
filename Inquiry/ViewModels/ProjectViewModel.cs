using System;
using System.Collections.ObjectModel;
using System.Reflection;
using Inquiry.Models;
using Inquiry.Models.IO;
using static Inquiry.Models.BaseModel;

namespace Inquiry.ViewModels
{
	public class ProjectViewModel: BaseViewModel
	{
		private ProjectModel _projectModel;
		public ProjectModel projectModel
		{
			get { return _projectModel; }
			set { SetProperty(ref _projectModel, value); }
		}

		public AsyncDelegateCommand AddFolderCommand { get; set; }
		public AsyncDelegateCommand AddFileCommand { get; set; }

		public ProjectViewModel()
		{
			LoadModels();
            LoadCommands();
        }

		private void LoadModels()
		{
            projectModel = new ProjectModel()
            {
                Files = new ObservableCollection<Models.IO.FileModel>()
            };
        }

		private void LoadCommands()
		{
			AddFolderCommand = new AsyncDelegateCommand(AddFolder);
			AddFileCommand = new AsyncDelegateCommand(AddFile);
        }

		private async Task AddFolder(object data)
		{
            
        }

        private async Task AddFile(object data)
        {
            IEnumerable<FileResult> result = await FilePicker.PickMultipleAsync();

            if (result != null)
            {
				foreach (FileResult file in result)
				{
                    AddFileToModel(file.FullPath);
                }
            }
        }

		private void AddFileToModel(string path)
		{
            FileModel file = null;

            if (IsSelected(path) == false && IsValid(path) == true)
            {
                file = new FileModel()
                {
                    Path = path,
                    Content = File.ReadAllText(path)
                };
				
                projectModel.Files.Add(file);
            }
        }

		private bool IsValid(string path)
		{
			string file = Path.GetFileName(path);
			string extension = Path.GetExtension(file);
			Console.WriteLine(path);
			Console.WriteLine(file);
			Console.WriteLine(extension);
            List<string> filters = new List<string>()
			{
				".cs"
			};

            return (filters.Contains(extension));
		}

		private bool IsSelected(string path)
		{
			foreach (FileModel file in projectModel.Files)
			{
				if (file.Path == path)
				{
					return (true);
				}
			}

			return (false);
		}
    }
}

