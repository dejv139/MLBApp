using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace MLBApp
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GET();
        }

        public async void GET()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync("http://lookup-service-prod.mlb.com/json/named.search_player_all.bam?sport_code='mlb'&active_sw='Y'&name_part='cole%25'");

            string json = await response.Content.ReadAsStringAsync();

            dynamic jokeFromAPI = JsonConvert.DeserializeObject<OmegaLUL>(json);




            A.Content = jokeFromAPI.name_display_first_last;

        }
    }
}
