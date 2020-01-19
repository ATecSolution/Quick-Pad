﻿using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Uwp.Helpers;
using QuickPad.Mvvm;
using QuickPad.Mvvm.Models;
using QuickPad.Mvvm.ViewModels;

namespace QuickPad.UI.Common.Helpers
{
    public class TextDocument : DocumentModel<StorageFile, IRandomAccessStream>
    {
        public TextDocument(
            TextBox document
            , ILogger<TextDocument> logger
            , DocumentViewModel<StorageFile, IRandomAccessStream> viewModel
            , WindowsSettingsViewModel settings
            , IApplication<StorageFile, IRandomAccessStream> app)
            : base(logger, viewModel, settings, app)
        {
            Document = document;
        }

        public TextBox Document { get; }

        public override bool CanCopy => Document.SelectionLength > 0;
        public override bool CanPaste => true;
        public override bool CanRedo => Document.CanRedo;
        public override bool CanUndo => Document.CanUndo;

        public override void Redo()
        {
            Document.Redo();
        }

        public override void Undo()
        {
            Document.Undo();
        }

        public override async Task LoadFromStream(QuickPadTextSetOptions options, IRandomAccessStream stream)
        {
            var memoryStream = new InMemoryRandomAccessStream();
            var bytes = Encoding.UTF8.GetBytes("\r");
            var buffer = bytes.AsBuffer();
            await memoryStream.WriteAsync(buffer);

            memoryStream.Seek(0);

            Text = stream.ReadTextAsync(ViewModel.CurrentEncoding).Result;
        }

        public override Action<string, bool> Paste => (s, b) => Document.SelectedText = s;

        public override void BeginUndoGroup()
        {
        }

        public override void EndUndoGroup()
        {
        }

        public override void SetSelectedText(string text)
        {
            Document.SelectedText = text;
        }

        public override (int start, int length) GetSelectionBounds()
        {
            return (Document.SelectionStart, Document.SelectionLength);
        }

        public override (int start, int length) SetSelectionBound(int start, int length)
        {
            Document.SelectionStart = start;
            Document.SelectionLength = length;

            return GetSelectionBounds();
        }

        public override void SetText(QuickPadTextSetOptions options, string value)
        {
            Document.Text = value;
        }

        public override void GetText(QuickPadTextGetOptions options, out string value)
        {
            value = Document.Text;
        }
    }
}