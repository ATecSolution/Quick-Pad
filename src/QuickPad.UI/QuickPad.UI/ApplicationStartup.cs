﻿using Windows.ApplicationModel.Resources;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuickPad.Mvc;
using QuickPad.Mvvm;
using QuickPad.Mvvm.Commands;
using QuickPad.Mvvm.Commands.Actions;
using QuickPad.Mvvm.Commands.Clipboard;
using QuickPad.Mvvm.Commands.Editing;
using QuickPad.Mvvm.Models.Theme;
using QuickPad.Mvvm.ViewModels;
using QuickPad.Mvvm.Views;
using QuickPad.UI.Common.Dialogs;
using QuickPad.UI.Common.Helpers;
using QuickPad.UI.Common.Theme;

namespace QuickPad.UI
{
    public class ApplicationStartup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            // MVC and ViewModels
            services.AddSingleton<ApplicationController<StorageFile, IRandomAccessStream, WindowsDocumentManager>, ApplicationController<StorageFile, IRandomAccessStream, WindowsDocumentManager>>();
            services.AddSingleton<SettingsViewModel<StorageFile, IRandomAccessStream>>(provider => provider.GetService<WindowsSettingsViewModel>());
            services.AddSingleton<WindowsSettingsViewModel, WindowsSettingsViewModel>();
            services.AddTransient<DocumentViewModel<StorageFile, IRandomAccessStream>, DocumentViewModel<StorageFile, IRandomAccessStream>>();
            services.AddSingleton<DefaultTextForegroundColor, DefaultTextForegroundColor>();
            services.AddTransient<IFindAndReplaceView<StorageFile, IRandomAccessStream>, FindAndReplaceViewModel<StorageFile, IRandomAccessStream>>();
            services.AddTransient<RtfDocument, RtfDocument>();
            services.AddTransient<TextDocument, TextDocument>();
            services.AddSingleton<WindowsDocumentManager, WindowsDocumentManager>();
            services.AddSingleton<IDocumentViewModelStrings, WindowsDocumentViewModelStrings>();
            services.AddTransient<ResourceLoader>(provider => ResourceLoader.GetForCurrentView());

            services.AddSingleton<IVisualThemeSelector, VisualThemeSelector>();

            services.AddTransient<AskToSave, AskToSave>();
            services.AddTransient<WelcomeDialog, WelcomeDialog>();
            services.AddTransient<IGoToLineView<StorageFile, IRandomAccessStream>, GoToLine>();
            services.AddSingleton<MainPage, MainPage>();

            services.AddSingleton<IShowGoToCommand<StorageFile, IRandomAccessStream>, ShowGoToCommand<StorageFile, IRandomAccessStream>>();
            services.AddSingleton<IShowGoToCommand<StorageFile, IRandomAccessStream>, ShowGoToCommand<StorageFile, IRandomAccessStream>>();
            services.AddSingleton<IShareCommand<StorageFile, IRandomAccessStream>, ShareCommand>();
            services.AddSingleton<ICutCommand<StorageFile, IRandomAccessStream>, CutCommand>();
            services.AddSingleton<ICopyCommand<StorageFile, IRandomAccessStream>, CopyCommand>();
            services.AddSingleton<IPasteCommand<StorageFile, IRandomAccessStream>, PasteCommand>();
            services.AddSingleton<IDeleteCommand<StorageFile, IRandomAccessStream>, DeleteCommand>();
            services.AddSingleton<IContentChangedCommand<StorageFile, IRandomAccessStream>, ContentChangedCommand>();
            services.AddSingleton<IEmojiCommand<StorageFile, IRandomAccessStream>, EmojiCommand>();
            services.AddSingleton<ICompactOverlayCommand<StorageFile, IRandomAccessStream>, CompactOverlayCommand>();
            services.AddSingleton<IRateAndReviewCommand<StorageFile, IRandomAccessStream>, RateAndReviewCommand>();
            services.AddSingleton<QuickPadCommands<StorageFile, IRandomAccessStream>, QuickPadCommands<StorageFile, IRandomAccessStream>>();
            services.AddSingleton<IQuickPadCommands<StorageFile, IRandomAccessStream>>(provider => provider.GetService <QuickPadCommands<StorageFile, IRandomAccessStream>>());
            services.AddSingleton<PasteCommand, PasteCommand>();

            services.AddSingleton(_ => Application.Current as IApplication<StorageFile, IRandomAccessStream>);
            // Add additional services here.
        }

        public static void Configure(IConfigurationBuilder configuration)
        {
            // Add additional configuration here.
        }
    }
}
