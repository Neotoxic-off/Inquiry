using System;
using System.Collections.ObjectModel;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Android.Provider.DocumentsContract;

namespace Inquiry.Scan
{
	public class Core
	{
        private SyntaxTree syntaxTree { get; set; }
        private CompilationUnitSyntax Root { get; set; }

        public Core()
		{
            
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

