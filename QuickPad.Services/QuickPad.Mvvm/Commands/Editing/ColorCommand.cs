﻿using System.Threading.Tasks;
using Windows.UI.Text;
using QuickPad.Mvvm.ViewModels;

namespace QuickPad.Mvvm.Commands.Editing
{
    public class ColorCommand : SimpleCommand<DocumentViewModel>
    {
        public ColorCommand()
        {
            Executioner = viewModel =>
            {
                viewModel.Document.Selection.CharacterFormat.ForegroundColor = viewModel.FontColor;
                viewModel.OnPropertyChanged(nameof(viewModel.Text));

                return Task.CompletedTask;
            };
        }
    }
}