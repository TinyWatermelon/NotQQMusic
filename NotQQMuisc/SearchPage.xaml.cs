using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace NotQQMuisc
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SearchPage : Page
    {
        string searchkey = "";
        ObservableCollection<MusicItem> searchresult = new ObservableCollection<MusicItem>();
        public SearchPage()
        {
            this.InitializeComponent();
            //searchresult = SearchPageitems.GetSearchPageitems(searchkey);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            searchkey = e.Parameter as string;
            searchresult = SearchPageitems.GetSearchPageitems(searchkey);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var seleteditem = (MusicItem)listview1.SelectedItem;
            App.PlayList.Add(seleteditem);
        }
    }
}
