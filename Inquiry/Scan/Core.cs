using System;
using System.Collections.ObjectModel;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using Inquiry.Models;
using Inquiry.ViewModels;

namespace Inquiry.Scan
{
	public class Core: BaseViewModel
	{
        private ScanModel _scanModel;
        public ScanModel scanModel
        {
            get { return _scanModel; }
            set { SetProperty(ref _scanModel, value); }

        }

        private SyntaxTree syntaxTree { get; set; }
        private CompilationUnitSyntax Root { get; set; }

        public Core()
		{
            LoadModels();
        }

        private void LoadModels()
        {
            scanModel = new ScanModel()
            {
                Steps = new ObservableCollection<ScanStepModel>()
                {
                    new ScanStepModel()
                    {
                        Status = ScanStepModel.States.Queue,
                        Action = new Action<object>(IExtractNamespace),
                        Name = "Extract namespace declaration",
                        Icon = "state_queue.png",
                        Color = "Cyan"
                    },
                    new ScanStepModel()
                    {
                        Status = ScanStepModel.States.Queue,
                        Action = new Action<object>(IExtractClass),
                        Name = "Extract class declaration",
                        Icon = "state_queue.png",
                        Color = "Cyan"
                    },
                    new ScanStepModel()
                    {
                        Status = ScanStepModel.States.Queue,
                        Action = new Action<object>(IExtractVariable),
                        Name = "Extract variable declaration",
                        Icon = "state_queue.png",
                        Color = "Cyan"
                    }
                }
            };
        }

        public void Load(string code)
        {
            syntaxTree = CSharpSyntaxTree.ParseText(code);
            Root = syntaxTree.GetCompilationUnitRoot();
        }

        private ObservableCollection<T> Extractor<T>()
        {
            ObservableCollection<T> list = new ObservableCollection<T>(
                 Root.DescendantNodes().OfType<T>()
            );

            return (list);
        }

        private void IExtractNamespace(object data)
        {
            ExtractNamespaces();
        }

        private void IExtractClass(object data)
        {
            ExtractClass();
        }

        private void IExtractVariable(object data)
        {
            ExtractVariables();
        }

        private ObservableCollection<NamespaceDeclarationSyntax> ExtractNamespaces()
        {
            return (Extractor<NamespaceDeclarationSyntax>());
        }

        private ObservableCollection<ClassDeclarationSyntax> ExtractClass()
        {
            return (Extractor<ClassDeclarationSyntax>());
        }

        private ObservableCollection<VariableDeclarationSyntax> ExtractVariables()
        {
            return (Extractor<VariableDeclarationSyntax>());
        }
    }
}

