using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace NotQQMuisc
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ApplicationDataContainer _appSetting;
        private const string KEY = "MusicName";
        private static int mainpagetime = 0;
        private string fileList = "";
        public ObservableCollection<MusicItem> MainPageItem;
        public ObservableCollection<MusicItem> PlayList = App.PlayList;
        public MainPage()
        {
            this.InitializeComponent();
            _appSetting = ApplicationData.Current.LocalSettings;
            if (_appSetting.Values.ContainsKey(KEY))
            {
                fileList = _appSetting.Values[KEY].ToString();
                listbox1.ItemsSource = fileList.Split('|');
            }
            else
            {
                _appSetting.Values.Add(KEY, fileList);
            }
            if(mainpagetime==0)
            {
                MainPageItem = MainPageitems.GetMainPageitems();
                App.MainPageItem= MainPageItem;
                
                mainpagetime++;
            }
            else
            {
                MainPageItem = App.MainPageItem;
            }
        }
        private void savehistory()
        {
            string fileName = System.IO.Path.GetFileName(searchBox.Text);
            if (!fileList.Contains(fileName))
            {
                fileList += "|" + fileName;
                _appSetting.Values[KEY] = fileList;
                listbox1.ItemsSource = fileList.Split('|');
            }
        }
        private async void play_Click(object sender, RoutedEventArgs e)
        {
            string error = "";
            
            try
            {
                if (App.CurrentMusic == null|| App.PlayList!=null)
                {
                    App.CurrentMusic = App.PlayList[0];
                    player.Source = new Uri(App.CurrentMusic.downUrl, UriKind.Absolute);
                    player.Play();
                }
                else
                {
                    error = "地址错误或未添加至队列";
                }
            }
            catch (Exception)
            {
                error = "无法播放";
            }
            if (error != "")
            {
                await new MessageDialog(error).ShowAsync();
            }

        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            player.Stop();
        }

        private void searchbutton_Click(object sender, RoutedEventArgs e)
        {
            savehistory();
            Frame.Navigate(typeof(SearchPage), searchBox.Text);
            searchBox.Text = "";
        }

        private void listbox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listbox1.SelectedItem == null)
                return;
            //listbox1.SelectedItem.
            Frame.Navigate(typeof(SearchPage), listbox1.SelectedValue);
        }
    }
}
