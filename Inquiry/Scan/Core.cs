using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Inquiry.Scan
{
	public class Core
	{
        private SyntaxTree syntaxTree { get; set; }

        public Core()
		{
            var root = syntaxTree.GetCompilationUnitRoot();

            // Extract namespace
            var namespaceDeclaration = root.DescendantNodes().OfType<NamespaceDeclarationSyntax>().FirstOrDefault();
            string namespaceName = namespaceDeclaration?.Name.ToString() ?? "No namespace";

            // Extract class
            var classDeclaration = root.DescendantNodes().OfType<ClassDeclarationSyntax>().FirstOrDefault();
            string className = classDeclaration?.Identifier.ValueText ?? "No class";

            // Extract variables
            var variableDeclarations = root.DescendantNodes().OfType<VariableDeclarationSyntax>();
            foreach (var variableDeclaration in variableDeclarations)
            {
                foreach (var variable in variableDeclaration.Variables)
                {
                    string variableName = variable.Identifier.ValueText;
                    Console.WriteLine($"Variable: {variableName}");
                }
            }

            Console.WriteLine($"Namespace: {namespaceName}");
            Console.WriteLine($"Class: {className}");
        }

        public void Load(string code)
        {
            syntaxTree = CSharpSyntaxTree.ParseText(code);
        }
	}
}

