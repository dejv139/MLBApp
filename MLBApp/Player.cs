using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLBApp
{
    public class Player
    {
        public string position { get; set; }
        public string birth_country { get; set; }
        public string weight { get; set; }
        public string birth_state { get; set; }
        public string name_display_first_last { get; set; }
        public string college { get; set; }
        public string height_inches { get; set; }
        public string name_display_roster { get; set; }
        public string sport_code { get; set; }
        public string bats { get; set; }
        public string name_first { get; set; }
        public string team_code { get; set; }
        public string birth_city { get; set; }
        public string height_feet { get; set; }
        public DateTime pro_debut_date { get; set; }
        public string team_full { get; set; }
        public string team_abbrev { get; set; }
        public DateTime birth_date { get; set; }
        public string throws { get; set; }
        public string league { get; set; }
        public string name_display_last_first { get; set; }
        public string position_id { get; set; }
        public string high_school { get; set; }
        public string name_use { get; set; }
        public string player_id { get; set; }
        public string name_last { get; set; }
        public string team_id { get; set; }
        public string service_years { get; set; }
        public string active_sw { get; set; }
    }

    public class QueryResults
    {
        public DateTime created { get; set; }
        public string totalSize { get; set; }
        public List<Player> row { get; set; }
    }

    public class QueryResult
    {
        public DateTime created { get; set; }
        public string totalSize { get; set; }
        public Player row { get; set; }
    }

    public class SearchPlayerAll
    {
        public string copyRight { get; set; }
        public QueryResults queryResults { get; set; }
    }

    public class OmegaLUL
    {
        public SearchPlayerAll search_player_all { get; set; }
    }

    public class OmegaLUL2
    {
        public SearchPlayerAll2 search_player_all { get; set; }
    }

    public class SearchPlayerAll2
    {
        public string copyRight { get; set; }
        public QueryResult queryResults { get; set; }
    }
}
