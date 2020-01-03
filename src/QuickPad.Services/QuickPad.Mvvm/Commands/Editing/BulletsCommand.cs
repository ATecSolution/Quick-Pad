﻿using System.Threading.Tasks;
using Windows.UI.Text;
using QuickPad.Mvvm.ViewModels;

namespace QuickPad.Mvvm.Commands.Editing
{
    public class BulletsCommand : SimpleCommand<DocumentViewModel>
    {
        public BulletsCommand()
        {
            Executioner = viewModel =>
            {
                viewModel.Document.BeginUndoGroup();
                viewModel.Document.Selection.ParagraphFormat.ListType = 
                    viewModel.Document.Selection.ParagraphFormat.ListType == MarkerType.Bullet 
                        ? MarkerType.None 
                        : MarkerType.Bullet;
                viewModel.Document.EndUndoGroup();

                viewModel.OnPropertyChanged(nameof(viewModel.Text));

                return Task.CompletedTask;
            };
        }
    }
}