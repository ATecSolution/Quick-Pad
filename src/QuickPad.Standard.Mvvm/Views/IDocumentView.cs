﻿using System;
using System.Threading.Tasks;
using QuickPad.Mvvm.Commands;
using QuickPad.Mvvm.ViewModels;

namespace QuickPad.Mvvm.Views
{
    public interface IDocumentView<TStorageFile, TStream> : IView
        where TStream : class
    {
        DocumentViewModel<TStorageFile, TStream> ViewModel { get; set; }

        event Action<IDocumentView<TStorageFile, TStream>, IQuickPadCommands<TStorageFile, TStream>> Initialize;
        event Func<DocumentViewModel<TStorageFile, TStream>, Task<bool>> ExitApplication;
        event Func<DocumentViewModel<TStorageFile, TStream>, TStorageFile, Task> LoadFromFile;
        event Action GainedFocus;
    }
}