using System;
using System.Collections.ObjectModel;
using System.Reflection;
using Inquiry.Models;
using Inquiry.Models.IO;
using Inquiry.Interfaces;
using System.Threading;
using CommunityToolkit.Maui.Storage;

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

        private Scan.Core _scanCore;
        public Scan.Core scanCore
        {
            get { return _scanCore; }
            set { SetProperty(ref _scanCore, value); }
        }

        private string _logs;
		public string Logs
		{
			get { return _logs; }
			set { SetProperty(ref _logs, value); }
		}

		public AsyncDelegateCommand AddFolderCommand { get; set; }
		public DelegateCommand RemoveFileCommand { get; set; }

        public ProjectViewModel()
		{
			LoadModels();
            LoadCommands();
        }

		private void Log(string message)
		{
			Logs = message;
		}

		private void LoadModels()
		{
            Log("loading models");

            projectModel = new ProjectModel()
            {
                Files = new ObservableCollection<FileModel>()
            };

			scanCore = new Scan.Core();

            Log("models loaded");
        }

		private void LoadCommands()
		{
            Log("loading commands");

            AddFolderCommand = new AsyncDelegateCommand(AddFolder);
			RemoveFileCommand = new DelegateCommand(RemoveFile);

            Log("commands loaded");
        }

		private void RemoveFile(object data)
		{
            foreach (FileModel file in projectModel.Files)
			{
				if (file.Path == $"{data}")
				{
					projectModel.Files.Remove(file);
                }
			}
		}

		private async Task AddFolder(object data)
		{
            Log("selecting folder project");
            CancellationToken cancellationToken = new CancellationToken();
			FolderPickerResult folder = await FolderPicker.Default.PickAsync(cancellationToken);
			string[] files = null;

            if (folder != null)
			{
				Log($"folder selected '{folder.Folder.Path}'");
                files = Directory.GetFiles(folder.Folder.Path, "*.cs", SearchOption.AllDirectories);
                Log("searching files");
                foreach (string file in files)
				{
                    AddFileToModel(file);
                }
                Log($"{projectModel.Files.Count} files added");
            }
        }

		private void AddFileToModel(string path)
		{
            FileModel file = null;

            if (IsSelected(path) == false)
            {
                file = new FileModel()
                {
                    Path = path,
                    Content = File.ReadAllText(path)
                };
				
                projectModel.Files.Add(file);
            }
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

