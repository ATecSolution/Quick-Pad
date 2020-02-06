﻿using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;
using QuickPad.Mvvm.Commands;
using QuickPad.Mvvm.ViewModels;

namespace QuickPad.Mvvm.Views
{
    public interface IDocumentView : IView
    {
        DocumentViewModel ViewModel { get; set; }

        event Action<IDocumentView, QuickPadCommands> Initialize;
        event Func<DocumentViewModel, Task<bool>> ExitApplication;
        event Func<DocumentViewModel, StorageFile, Task> LoadFromFile;
        event Action<RoutedEventArgs> GainedFocus;
    }
}