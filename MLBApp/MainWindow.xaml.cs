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

            var response = await client.GetAsync("http://lookup-service-prod.mlb.com/json/named.search_player_all.bam?sport_code='mlb'&active_sw='Y'&name_part='Cole%25'");

            string json = await response.Content.ReadAsStringAsync();

            dynamic PlayerFromAPI = JsonConvert.DeserializeObject<OmegaLUL>(json);

            PlayerListView.ItemsSource = PlayerFromAPI.search_player_all.queryResults.row;

        }

        private async void PlayerListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HttpClient client = new HttpClient();

            Player player = ((sender as ListView).SelectedItem as Player);
            if (player.position != "P")
            {
                var response = await client.GetAsync("http://lookup-service-prod.mlb.com/json/named.sport_hitting_tm.bam?league_list_id='mlb'&game_type='R'&active_sw=Y&player_id=" + player.player_id);

                string json = await response.Content.ReadAsStringAsync();

                dynamic PlayerFromAPI = JsonConvert.DeserializeObject<Batter>(json);

                A.Content = PlayerFromAPI.sport_hitting_tm.queryResults.row.avg;
            }
            else
            {
                var response = await client.GetAsync("http://lookup-service-prod.mlb.com/json/named.sport_career_pitching.bam?league_list_id='mlb'&game_type='R'&player_id=" + player.player_id);

                string json = await response.Content.ReadAsStringAsync();

                dynamic PlayerFromAPI = JsonConvert.DeserializeObject<Pitcher>(json);
                
            }
            A.Content = player.name_display_last_first;

        }

    }
}
