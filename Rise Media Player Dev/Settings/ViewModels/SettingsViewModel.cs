﻿using Rise.App.Settings;
using Rise.App.Views;
using System.Collections.Generic;

namespace Rise.App.ViewModels
{
    public class SettingsViewModel : SettingsManager
    {
        private SidebarViewModel SBViewModel => App.SBViewModel;

        // Empty constructor.
        public SettingsViewModel() { }

        public string[] OpenLocations = new string[10]
        {
            "HomePage", "PlaylistsPage", "DevicesPage", "SongsPage", "ArtistsPage",
            "AlbumsPage", "GenresPage", "LocalVideosPage", "StreamingPage", "NowPlayingPage"
        };

        private readonly string[] _iconPacks = new string[2]
        {
            "Default", "Colorful"
        };

        public List<string> GeneralTags = new List<string>
        {
            "HomePage", "PlaylistsPage", "DevicesPage", "NowPlayingPage"
        };

        public List<string> MusicTags = new List<string>
        {
            "SongsPage", "ArtistsPage", "AlbumsPage", "GenresPage"
        };

        public List<string> VideoTags = new List<string>
        {
            "LocalVideosPage", "StreamingPage"
        };

        #region Appearance
        public int Theme
        {
            get => (int)Get("Appearance", nameof(Theme), 2);
            set => Set("Appearance", nameof(Theme), value);
        }

        public bool SquareAlbumArt
        {
            get => (bool)Get("Appearance", nameof(SquareAlbumArt), false);
            set => Set("Appearance", nameof(SquareAlbumArt), value);
        }

        public int OpenTo
        {
            get => (int)Get("Appearance", nameof(OpenTo), 0);
            set => Set("Appearance", nameof(OpenTo), value);
        }

        public string Open =>
            OpenLocations[(int)Get("Appearance", nameof(OpenTo), 0)];

        public bool PickUp
        {
            get => (bool)Get("Appearance", nameof(PickUp), false);
            set => Set("Appearance", nameof(PickUp), value);
        }

        public bool CompactMode
        {
            get => (bool)Get("Appearance", nameof(CompactMode), true);
            set => Set("Appearance", nameof(CompactMode), value);
        }

        public bool ColoredSettingsIcons
        {
            get => (bool)Get("Appearance", nameof(ColoredSettingsIcons), true);
            set => Set("Appearance", nameof(ColoredSettingsIcons), value);
        }

        public bool TrackHistory
        {
            get => (bool)Get("Appearance", nameof(TrackHistory), false);
            set => Set("Appearance", nameof(TrackHistory), value);
        }

        public bool CuratedPlaylists
        {
            get => (bool)Get("Appearance", nameof(CuratedPlaylists), false);
            set => Set("Appearance", nameof(CuratedPlaylists), value);
        }
        #endregion

        #region Media Library
        public int Deletion
        {
            get => (int)Get("MediaLibrary", nameof(Deletion), 0);
            set => Set("MediaLibrary", nameof(Deletion), value);
        }

        public bool SeparateLocal
        {
            get => (bool)Get("MediaLibrary", nameof(SeparateLocal), false);
            set => Set("MediaLibrary", nameof(SeparateLocal), value);
        }

        public bool DisableOnline
        {
            get => (bool)Get("MediaLibrary", nameof(DisableOnline), false);
            set => Set("MediaLibrary", nameof(DisableOnline), value);
        }
        #endregion

        #region Navigation
        public int Resize
        {
            get => (int)Get("Navigation", nameof(Resize), 0);
            set => Set("Navigation", nameof(Resize), value);
        }

        public bool Hamburger
        {
            get => (bool)Get("Navigation", nameof(Hamburger), false);
            set => Set("Navigation", nameof(Hamburger), value);
        }

        public string CurrentPack => _iconPacks[IconPack];
        public int IconPack
        {
            get => (int)Get("Local", nameof(IconPack), 0);
            set
            {
                Set("Local", nameof(IconPack), value);
                MainPage.Current.ChangeIconPack(CurrentPack);
            }
        }

        public bool ShowAllGeneral
        {
            get => ShowAtAGlance || ShowDevices || ShowPlaylists || ShowHelpCentre || ShowNowPlaying;
            set
            {
                ShowAtAGlance = value;
                ShowDevices = value;
                ShowPlaylists = value;
                ShowHelpCentre = value;
                ShowNowPlaying = value;

                OnPropertyChanged(nameof(ShowAtAGlance));
                OnPropertyChanged(nameof(ShowDevices));
                OnPropertyChanged(nameof(ShowPlaylists));
                OnPropertyChanged(nameof(ShowHelpCentre));
                OnPropertyChanged(nameof(ShowNowPlaying));
            }
        }

        public bool ShowAllMusic
        {
            get
            {
                bool vis = ShowSongs || ShowArtists || ShowAlbums || ShowGenres;
                if (!vis)
                {
                    ShowMusicHeader = false;
                }

                OnPropertyChanged(nameof(ShowMusicHeader));
                return vis;
            }
            set
            {
                ShowMusicHeader = value;
                ShowSongs = value;
                ShowArtists = value;
                ShowAlbums = value;
                ShowGenres = value;

                OnPropertyChanged(nameof(ShowSongs));
                OnPropertyChanged(nameof(ShowArtists));
                OnPropertyChanged(nameof(ShowAlbums));
                OnPropertyChanged(nameof(ShowGenres));
            }
        }

        public bool ShowAllVideo
        {
            get
            {
                bool vis = ShowLocalVideos || ShowStreaming;
                if (!vis)
                {
                    ShowVideoHeader = false;
                }

                OnPropertyChanged(nameof(ShowVideoHeader));
                return vis;
            }
            set
            {
                ShowVideoHeader = value;
                ShowLocalVideos = value;
                ShowStreaming = value;

                OnPropertyChanged(nameof(ShowLocalVideos));
                OnPropertyChanged(nameof(ShowStreaming));
            }
        }

        public bool ShowMusicHeader
        {
            get => SBViewModel.IsHeaderVisible("Music");
            set => SBViewModel.ChangeHeaderVisibility("Music", value);
        }

        public bool ShowVideoHeader
        {
            get => SBViewModel.IsHeaderVisible("Videos");
            set => SBViewModel.ChangeHeaderVisibility("Videos", value);
        }

        public bool ShowAtAGlance
        {
            get => SBViewModel.IsItemVisible("HomePage");
            set => ChangeItemVisibility("HomePage", value);
        }

        public bool ShowPlaylists
        {
            get => SBViewModel.IsItemVisible("PlaylistsPage");
            set => ChangeItemVisibility("PlaylistsPage", value);
        }

        public bool ShowDevices
        {
            get => SBViewModel.IsItemVisible("DevicesPage");
            set => ChangeItemVisibility("DevicesPage", value);
        }

        public bool ShowSongs
        {
            get => SBViewModel.IsItemVisible("SongsPage");
            set => ChangeItemVisibility("SongsPage", value);
        }

        public bool ShowArtists
        {
            get => SBViewModel.IsItemVisible("ArtistsPage");
            set => ChangeItemVisibility("ArtistsPage", value);
        }

        public bool ShowAlbums
        {
            get => SBViewModel.IsItemVisible("AlbumsPage");
            set => ChangeItemVisibility("AlbumsPage", value);
        }

        public bool ShowGenres
        {
            get => SBViewModel.IsItemVisible("GenresPage");
            set => ChangeItemVisibility("GenresPage", value);
        }

        public bool ShowLocalVideos
        {
            get => SBViewModel.IsItemVisible("LocalVideosPage");
            set => ChangeItemVisibility("LocalVideosPage", value);
        }

        public bool ShowStreaming
        {
            get => SBViewModel.IsItemVisible("StreamingPage");
            set => ChangeItemVisibility("StreamingPage", value);
        }

        public bool ShowHelpCentre
        {
            get => SBViewModel.IsItemVisible("DiscyPage");
            set => ChangeItemVisibility("DiscyPage", value);
        }

        public bool ShowNowPlaying
        {
            get => SBViewModel.IsItemVisible("NowPlayingPage");
            set => ChangeItemVisibility("NowPlayingPage", value);
        }

        private void ChangeItemVisibility(string tag, bool value)
        {
            SBViewModel.ChangeItemVisibility(tag, value);

            if (GeneralTags.Contains(tag))
            {
                OnPropertyChanged(nameof(ShowAllGeneral));
            }
            else if (MusicTags.Contains(tag))
            {
                OnPropertyChanged(nameof(ShowAllMusic));
            }
            else
            {
                OnPropertyChanged(nameof(ShowAllVideo));
            }
        }
        #endregion

        #region Playback
        public bool Gapless
        {
            get => (bool)Get("Playback", nameof(Gapless), false);
            set => Set("Playback", nameof(Gapless), value);
        }

        public int CrossfadeDuration
        {
            get => (int)Get("Playback", nameof(CrossfadeDuration), 0);
            set => Set("Playback", nameof(CrossfadeDuration), value);
        }

        public int ScaleToWindow
        {
            get => (int)Get("Playback", nameof(ScaleToWindow), 0);
            set => Set("Playback", nameof(ScaleToWindow), value);
        }

        public bool GoDevice
        {
            get => (bool)Get("Playback", nameof(GoDevice), false);
            set => Set("Playback", nameof(GoDevice), value);
        }

        public bool ReplaceFlyouts
        {
            get => (bool)Get("Playback", nameof(ReplaceFlyouts), false);
            set => Set("Playback", nameof(ReplaceFlyouts), value);
        }
        #endregion

        #region Setup
        public bool SetupCompleted
        {
            get => (bool)Get("Local", nameof(SetupCompleted), false);
            set => Set("Local", nameof(SetupCompleted), value);
        }

        public int SetupProgress
        {
            get => (int)Get("Local", nameof(SetupProgress), 0);
            set => Set("Local", nameof(SetupProgress), value);
        }
        #endregion

        public int Language
        {
            get => (int)Get("Local", nameof(Language), 0);
            set => Set("Local", nameof(Language), value);
        }
    }
}
