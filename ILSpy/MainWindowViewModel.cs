﻿// Copyright (c) 2021 Siegfried Pammer
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

using System.Composition;

using ICSharpCode.ILSpy.Analyzers;
using ICSharpCode.ILSpy.AssemblyTree;
using ICSharpCode.ILSpy.Docking;
using ICSharpCode.ILSpyX;

using TomsToolbox.Wpf;

namespace ICSharpCode.ILSpy
{
	[Export]
	[Shared]
	public class MainWindowViewModel(AssemblyTreeModel assemblyTreeModel, AnalyzerTreeViewModel analyzerTreeViewModel, SettingsService settingsService, LanguageService languageService) : ObservableObject
	{
		public DockWorkspace Workspace => DockWorkspace.Instance;
		public SessionSettings SessionSettings => settingsService.SessionSettings;
		public LanguageService LanguageService => languageService;
		public AssemblyListManager AssemblyListManager => settingsService.AssemblyListManager;

		public AnalyzeCommand AnalyzeCommand { get; } = new(assemblyTreeModel, analyzerTreeViewModel);
	}
}
