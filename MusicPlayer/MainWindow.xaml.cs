using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MusicPlayer
{
    public partial class MainWindow : Window
    {
        string MediaLink = "";
        private string[] MusicList;
        private MediaPlayer mediaPlayer = new MediaPlayer();
        private bool is_check = false;
        private bool userIsDraggingSlider = false;

        public MainWindow()
        {
            InitializeComponent();
            Load_left();

            music_slider.ApplyTemplate();
            Thumb thumb = (music_slider.Template.FindName("PART_Track", music_slider) as Track).Thumb;
            thumb.MouseEnter += new MouseEventHandler(thumbclick);

            BrushConverter bc = new BrushConverter();
            toolbar.Fill = (Brush)bc.ConvertFrom(Properties.Settings.Default.Theme);
            setting.Background = (Brush)bc.ConvertFrom(Properties.Settings.Default.Theme);
            track_name.Text = "Mr Music\ninstagram : @mrsfgwork";
        }

        private void thumbclick(object sender, MouseEventArgs e)
        {
            MouseButtonEventArgs args = new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, MouseButton.Left);
            args.RoutedEvent = MouseLeftButtonDownEvent;
            (sender as Thumb).RaiseEvent(args);
        }

        private void Load_left(string SearchWord = "")
        {
            mpanel_left.Children.Clear();
            IOrderedEnumerable<FileInfo> file_entity;
            if (Directory.Exists(Properties.Settings.Default.Address))
            {
                if (SearchWord == "")
                    file_entity = Directory.GetFiles(Properties.Settings.Default.Address).Select(f => new FileInfo(f)).Where(p => p.Extension.Contains("mp3")).OrderByDescending(f => f.CreationTime);
                else
                    file_entity = Directory.GetFiles(Properties.Settings.Default.Address).Select(f => new FileInfo(f)).Where(p => p.FullName.ToLower().Contains(SearchWord.ToLower()) && p.Extension.Contains("mp3")).OrderByDescending(f => f.CreationTime);
            }
            else
            {
                file_entity = Directory.GetFiles("c:\\").Select(f => new FileInfo(f)).OrderByDescending(f => f.CreationTime);
            }

            Color shadow = new Color() { ScA = 1, ScB = 0, ScG = 0, ScR = 0 };
            DropShadowBitmapEffect myDropShadowEffect = new DropShadowBitmapEffect()
            {
                Color = shadow,
                Direction = 0,
                ShadowDepth = 0,
                Opacity = 0.4
            };

            int i = 0;
            MusicList = new string[file_entity.Count()];
            foreach (var name in file_entity)
            {
                MusicList[i] = name.ToString();
                i++;
                Label image = new Label()
                {
                    Width = 22,
                    Height = 22,
                    Margin = new Thickness(4, 0, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Background = new ImageBrush(new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/ic_play_white.png")))
                };

                MusicClick bgrid = new MusicClick()
                {
                    Background = new SolidColorBrush(Color.FromRgb(255, 255, 255)),
                    Margin = new Thickness(10, 5, 10, 5),
                    Width = 236,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    BitmapEffect = myDropShadowEffect,
                    CornerRadius = new CornerRadius(6),
                    Cursor = Cursors.Hand,
                    Link = name.ToString(),
                    Image = image
                };
                bgrid.MouseLeftButtonDown += PlayMusic;
                bgrid.MouseEnter += HoverMode;
                bgrid.MouseLeave += LeaveMode;

                BrushConverter bc = new BrushConverter();
                Border border = new Border()
                {
                    BorderThickness = new Thickness(1),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Height = 64,
                    Width = 64,
                    Background = (Brush)bc.ConvertFrom(Properties.Settings.Default.Theme),
                    CornerRadius = new CornerRadius(30),
                    Margin = new Thickness(10, 10, 0, 10),
                    VerticalAlignment = VerticalAlignment.Top,
                };

                TextBlock namelbl = new TextBlock()
                {
                    Text = (System.IO.Path.GetFileName(name.FullName)).Substring(0, (System.IO.Path.GetFileName(name.FullName)).Length - 4),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(84, 14, 0, 0),
                    FontSize = 16,
                    FontWeight = FontWeights.Bold,
                    Width = 156,
                    Height = 46,
                    Padding = new Thickness(0, 0, 10, 0),
                    Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0)),
                    TextWrapping = TextWrapping.Wrap
                };

                Grid grid = new Grid();
                bgrid.Child = grid;
                border.Child = image;
                grid.Children.Add(border);
                grid.Children.Add(namelbl);

                mpanel_left.Children.Add(bgrid);
            }
            mediaPlayer.MediaEnded += MediaEnded;
        }

        private void MediaEnded(object sender, EventArgs e)
        {
            ResetPanel();
            for (int i = 0; i < MusicList.Length; i++)
            {
                if(MediaLink == MusicList[i])
                {                    
                    if (i == MusicList.Length - 1) MediaLink = MusicList[0];
                    else MediaLink = (MusicList.Length > 1) ? MusicList[i + 1] : MusicList[i];
                    mediaPlayer.Open(new Uri(MediaLink));
                    mediaPlayer.Play();
                    ChangeDetail();
                    break;
                }
            }                        
        }

        private void timer_tick(object sender, EventArgs e)
        {
            if ((mediaPlayer.Source != null) && (mediaPlayer.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
            {
                music_slider.Minimum = 0;
                music_slider.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                music_slider.Value = mediaPlayer.Position.TotalSeconds;
            }
        }

        private void HoverMode(object sender, MouseEventArgs e)
        {
            ((MusicClick)sender).Background = new SolidColorBrush(Color.FromRgb(255, 255, 200));
        }
        private void LeaveMode(object sender, MouseEventArgs e)
        {
            ((MusicClick)sender).Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void PlayMusic(object sender, MouseButtonEventArgs e)
        {
            ResetPanel();
            is_check = true;
            main_btn.Visibility = Visibility.Visible;
            next_btn.Visibility = Visibility.Visible;
            prev_btn.Visibility = Visibility.Visible;
            music_slider.Visibility = Visibility.Visible;
            time_label.Visibility = Visibility.Visible;

            ((MusicClick)sender).Image.Margin = new Thickness(0);
            ((MusicClick)sender).Image.Background = new ImageBrush(new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/ic_pause_white.png")));

            main_btn_img.Background = new ImageBrush(new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/ic_pause_black.png")));
            main_btn_img.Margin = new Thickness(0);
            MediaLink = ((MusicClick)sender).Link.ToString();
            mediaPlayer.Open(new Uri(((MusicClick)sender).Link.ToString()));
            mediaPlayer.Play();
            ChangeDetail();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_tick;
            timer.Start();
        }

        private void ResetPanel()
        {
            foreach (var item in mpanel_left.Children)
            {
                if (item is FrameworkElement)
                {
                    (item as MusicClick).Image.Background = new ImageBrush(new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/ic_play_white.png")));
                    (item as MusicClick).Image.Margin = new Thickness(4, 0, 0, 0);
                }
            }
        }

        private void Toolbar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Minimize_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Setting_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Border)sender).Background.Opacity = 0.8f;
        }

        private void Setting_MouseLeave(object sender, MouseEventArgs e)
        {            
            ((Border)sender).Background.Opacity = 1;
        }

        private void Main_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (is_check)
            {
                main_btn_img.Background = new ImageBrush(new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/ic_play_black.png")));
                main_btn_img.Margin = new Thickness(4, 0, 0, 0);
                mediaPlayer.Pause();
                is_check = false;
            }
            else
            {
                main_btn_img.Background = new ImageBrush(new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/ic_pause_black.png")));
                main_btn_img.Margin = new Thickness(0);
                mediaPlayer.Play();
                is_check = true;
            }

            foreach (var item in mpanel_left.Children)
            {
                if (item is FrameworkElement)
                {
                    if ((item as MusicClick).Link == MediaLink)
                    {
                        if (!is_check)
                        {
                            (item as MusicClick).Image.Background = new ImageBrush(new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/ic_play_white.png")));
                            (item as MusicClick).Image.Margin = new Thickness(4, 0, 0, 0);
                        }
                        else
                        {
                            (item as MusicClick).Image.Background = new ImageBrush(new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/ic_pause_white.png")));
                            (item as MusicClick).Image.Margin = new Thickness(0);
                        }
                    }
                }
            }
        }

        private void Setting_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AddFolder addFolder = new AddFolder();
            addFolder.ShowDialog();
            if (addFolder.DialogResult.HasValue && addFolder.DialogResult.Value)
            {
                mpanel_left.Children.Clear();
                Load_left();
            }
        }

        private void Search_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search_word = ((TextBox)sender).Text;
            Load_left(search_word);
            if (search_word != "Search")
            {
                ClearBtn.Visibility = Visibility.Visible;
            }
            if (search_word.Length == 0)
            {
                ClearBtn.Visibility = Visibility.Hidden;
            }
        }

        private void Search_box_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (search_box.Text == "Search")
            {
                search_box.Clear();
            }
        }

        private void MainForm_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();
            if (search_box.Text == "")
            {
                search_box.Text = "Search";
                Load_left();
            }
        }

        private void ClearBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            search_box.Clear();
            mscroll_left.ScrollToVerticalOffset(0);
            ClearBtn.Visibility = Visibility.Hidden;
        }

        private void sliProgress_DragStarted(object sender, DragStartedEventArgs e)
        {
            userIsDraggingSlider = true;
        }

        private void sliProgress_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            userIsDraggingSlider = false;
            mediaPlayer.Position = TimeSpan.FromSeconds(music_slider.Value);
        }
        private void sliProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            time_label.Content = TimeSpan.FromSeconds(music_slider.Value).ToString(@"mm\:ss") + " / " + TimeSpan.FromSeconds(mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds).ToString(@"mm\:ss");
        }

        private void Music_slider_MouseMove(object sender, MouseEventArgs e)
        {
            Point currentPos = e.GetPosition(music_slider);
            Track _track = music_slider.Template.FindName("PART_Track", music_slider) as Track;

            music_slider.ToolTip = TimeSpan.FromSeconds(_track.ValueFromPoint(currentPos)).ToString(@"mm\:ss");
        }

        private void Next_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < MusicList.Length; i++)
            {
                if (MusicList[i] == MediaLink)
                {
                    if (i < MusicList.Length - 1)
                        MediaLink = MusicList[i + 1];
                    else
                        MediaLink = MusicList[0];

                    mediaPlayer.Open(new Uri(MediaLink));
                    mediaPlayer.Play();
                    ChangeDetail();
                    break;
                }
            }
            main_btn_img.Background = new ImageBrush(new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/ic_pause_black.png")));
            main_btn_img.Margin = new Thickness(0);
            is_check = true;
        }

        private void Prev_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < MusicList.Length; i++)
            {
                if (MusicList[i] == MediaLink)
                {
                    if (i == 0)
                        MediaLink = MusicList[MusicList.Length - 1];
                    else
                        MediaLink = MusicList[i - 1];

                    mediaPlayer.Open(new Uri(MediaLink));
                    mediaPlayer.Play();
                    ChangeDetail();
                    break;
                }
            }
            main_btn_img.Background = new ImageBrush(new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/ic_pause_black.png")));
            main_btn_img.Margin = new Thickness(0);
            is_check = true;
        }

        private void ChangeDetail()
        {
            track_name.Text = System.IO.Path.GetFileName(MediaLink);
            track_name.Text = track_name.Text.Substring(0, track_name.Text.Length - 4);

            TagLib.File file = TagLib.File.Create(MediaLink);
            var mStream = new MemoryStream();
            var firstPicture = file.Tag.Pictures.FirstOrDefault();
            if (firstPicture != null)
            {
                try
                {
                    byte[] pData = firstPicture.Data.Data;
                    mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                    var bm = new System.Drawing.Bitmap(mStream, false);
                    mStream.Dispose();

                    var col1 = bm.GetPixel(0, 0);
                    var col2 = bm.GetPixel(bm.Width - 1, bm.Height - 1);

                    toolbar.Fill = new SolidColorBrush(Color.FromRgb(col1.R, col1.G, col1.B));
                    rec_left.Fill = new SolidColorBrush(Color.FromRgb(col1.R, col1.G, col1.B));
                    LinearGradientBrush linearGradient = new LinearGradientBrush(Color.FromRgb(col1.R, col1.G, col1.B), Color.FromRgb(col2.R, col2.G, col2.B), new Point(0.5, 0), new Point(0.5, 1));
                    rec_right.Fill = linearGradient;

                    main_image.Visibility = Visibility.Hidden;
                    music_image.Background = new ImageBrush(Imaging.CreateBitmapSourceFromHBitmap(bm.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions()));

                    if (LightOrDark.getDarkorLight(bm) < 0.490f)
                    {
                        track_name.Foreground = Brushes.White;
                        time_label.Foreground = Brushes.White;
                    }
                    else
                    {
                        track_name.Foreground = new SolidColorBrush(Color.FromRgb(73, 73, 73));
                        time_label.Foreground = new SolidColorBrush(Color.FromRgb(73, 73, 73));
                    }
                }
                catch
                {
                    BrushConverter bc = new BrushConverter();

                    main_image.Visibility = Visibility.Visible;
                    toolbar.Fill = (Brush)bc.ConvertFrom(Properties.Settings.Default.Theme);
                    rec_left.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    music_image.Background = new LinearGradientBrush(Color.FromRgb(30, 144, 255), Color.FromRgb(14, 205, 161), new Point(0.5, 0), new Point(0.5, 1));
                    rec_right.Fill = new SolidColorBrush(Color.FromRgb(241, 241, 241));
                    track_name.Foreground = new SolidColorBrush(Color.FromRgb(73, 73, 73));
                    time_label.Foreground = new SolidColorBrush(Color.FromRgb(73, 73, 73));
                }
            }
            else
            {
                BrushConverter bc = new BrushConverter();
                
                main_image.Visibility = Visibility.Visible;
                toolbar.Fill = (Brush)bc.ConvertFrom(Properties.Settings.Default.Theme);
                rec_left.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                music_image.Background = new LinearGradientBrush(Color.FromRgb(30, 144, 255), Color.FromRgb(14, 205, 161), new Point(0.5, 0), new Point(0.5, 1));
                rec_right.Fill = new SolidColorBrush(Color.FromRgb(241, 241, 241));
                track_name.Foreground = new SolidColorBrush(Color.FromRgb(73, 73, 73));
                time_label.Foreground = new SolidColorBrush(Color.FromRgb(73, 73, 73));
            }

            ResetPanel();
            foreach (var item in mpanel_left.Children)
            {
                if (item is FrameworkElement)
                {
                    if ((item as MusicClick).Link == MediaLink)
                    {
                        (item as MusicClick).Image.Background = new ImageBrush(new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/ic_pause_white.png")));
                        (item as MusicClick).Image.Margin = new Thickness(0);
                    }
                }
            }
        }

        private void MainForm_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            volume_slider.Visibility = Visibility.Visible;
            mediaPlayer.Volume += (e.Delta > 0) ? 0.1 : -0.1;
            volume_slider.Value = mediaPlayer.Volume;

            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
            timer.Start();
            timer.Tick += (sender1, args) =>
            {
                timer.Stop();
                volume_slider.Visibility = Visibility.Hidden;
            };
        }

        private void Mscroll_left_MouseEnter(object sender, MouseEventArgs e)
        {
            mscroll_left.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
        }

        private void Mscroll_left_MouseLeave(object sender, MouseEventArgs e)
        {
            mscroll_left.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
        }
    }
}