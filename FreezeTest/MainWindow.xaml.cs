using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FreezeTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<String> _imgUrlList = new List<string>()
        {
            "http://wallpaperswide.com/download/apple_mac_os_x_high_sierra___extended-wallpaper-2048x1152.jpg",
            "http://wallpaperswide.com/download/solenice-wallpaper-2048x1152.jpg",
            "http://wallpaperswide.com/download/lonely_leaf-wallpaper-2048x1152.jpg",
            "http://wallpaperswide.com/download/it_is_useless_to_resist___darth_vader-wallpaper-2048x1152.jpg",
            "http://wallpaperswide.com/download/halloween_2017____your_time_has_come-wallpaper-2048x1152.jpg",
            "http://wallpaperswide.com/download/bugatti_chiron_3-wallpaper-2048x1152.jpg",
            "http://wallpaperswide.com/download/moon-wallpaper-2048x1152.jpg",
            "http://wallpaperswide.com/download/cute_pembroke_welsh_corgi_puppies_running-wallpaper-2048x1152.jpg",
            "http://wallpaperswide.com/download/daydreaming_2-wallpaper-2048x1152.jpg",
            "http://wallpaperswide.com/download/assassins_creed_origins_ancient_egypt-wallpaper-2048x1152.jpg",
            "http://wallpaperswide.com/download/most_beautiful_spring_landscapes_on_earth-wallpaper-2048x1152.jpg",
            "http://wallpaperswide.com/download/desk-wallpaper-2048x1152.jpg",
            "http://wallpaperswide.com/download/beautiful_mountains_of_the_world-wallpaper-2048x1152.jpg",
            "http://wallpaperswide.com/download/warhammer_40000_dawn_of_war_iii_3_ork_faction-wallpaper-2048x1152.jpg",
            "http://wallpaperswide.com/download/pirates_of_the_caribbean_dead_men_tell_no_tales_jack_sparrow_5k-wallpaper-2048x1152.jpg",
            "http://wallpaperswide.com/download/armenian_beauty_tavush_hayk_photography-wallpaper-2048x1152.jpg",
        };


        public MainWindow()
        {
            InitializeComponent();
            this.BtnNext.Click += BtnNext_Click;
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            var idx = new Random().Next(_imgUrlList.Count);
            var url = _imgUrlList[idx];
            var client = new WebClient();
            var resBytes = client.DownloadData(url);

            using (var ms = new MemoryStream(resBytes))
            {
                var bi = new BitmapImage();
                bi.BeginInit();
                bi.CacheOption = BitmapCacheOption.OnLoad;
                bi.StreamSource = ms;
                bi.EndInit();
                //bi.Freeze();
                this.ImgObj.Source = bi;
            }
        }
    }
}
