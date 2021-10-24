﻿using RMP.App.Dialogs;
using RMP.App.Settings.ViewModels;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace RMP.App.Settings
{
    public sealed partial class AppearancePage : Page
    {
        private SettingsViewModel ViewModel => App.SViewModel;

        private List<string> Themes { get; set; }
        private List<string> Startup { get; set; }

        public AppearancePage()
        {
            InitializeComponent();

            Themes = new List<string>
            {
                ResourceLoaders.AppearanceLoader.GetString("Light"),
                ResourceLoaders.AppearanceLoader.GetString("Dark"),
                ResourceLoaders.AppearanceLoader.GetString("System")
            };

            Startup = new List<string>
            {
                ResourceLoaders.AppearanceLoader.GetString("Home"),
                ResourceLoaders.AppearanceLoader.GetString("Playlists"),
                ResourceLoaders.AppearanceLoader.GetString("Devices"),
                ResourceLoaders.AppearanceLoader.GetString("Songs"),
                ResourceLoaders.AppearanceLoader.GetString("Artists"),
                ResourceLoaders.AppearanceLoader.GetString("Albums"),
                ResourceLoaders.AppearanceLoader.GetString("Genres"),
                ResourceLoaders.AppearanceLoader.GetString("LocalVideos"),
                ResourceLoaders.AppearanceLoader.GetString("Streaming"),
                ResourceLoaders.AppearanceLoader.GetString("NowPlaying")
            };

            DataContext = ViewModel;
        }

        private void SidebarCustomize_Click(object sender, RoutedEventArgs e)
        {
            SettingsDialog.Current.
                SettingsFrame.Navigate(typeof(NavigationPage));

            SettingsDialog.Current.
                Breadcrumbs.Add(ResourceLoaders.AppearanceLoader.GetString("Sidebar"));
        }
    }
}
