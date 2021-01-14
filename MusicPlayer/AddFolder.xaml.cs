using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace MusicPlayer
{
    public partial class AddFolder : Window
    {
        public AddFolder()
        {
            InitializeComponent();
            AddressBar.Text = Properties.Settings.Default.Address;
            BrushConverter bc = new BrushConverter();
            toolbar.Fill = (Brush)bc.ConvertFrom(Properties.Settings.Default.Theme);
            addfolder_btn.Background = (Brush)bc.ConvertFrom(Properties.Settings.Default.Theme);
            AddressBar.BorderBrush = (Brush)bc.ConvertFrom(Properties.Settings.Default.Theme);
        }

        private void Toolbar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Addfolder_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult dialogResult = dialog.ShowDialog();
            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                AddressBar.Text = dialog.SelectedPath;
                Properties.Settings.Default.Address = dialog.SelectedPath;
                Properties.Settings.Default.Save();
                DialogResult = true;
                Close();
            }
        }

        private void set_theme(object sender, MouseButtonEventArgs e)
        {
            var col = ((Border)sender).Background;
            Properties.Settings.Default.Theme = col.ToString();
            Properties.Settings.Default.Save();
            System.Diagnostics.Process.Start(System.Windows.Application.ResourceAssembly.Location);
            System.Windows.Application.Current.Shutdown();
        }

        private void Color_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ((Border)sender).Background.Opacity = 0.5f;
        }

        private void Color_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ((Border)sender).Background.Opacity = 1;
        }
    }
}
