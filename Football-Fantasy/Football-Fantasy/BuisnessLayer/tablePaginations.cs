using System;
using Football_Fantasy.DataAccessLayer;
using Football_Fantasy.BuisnessLayer;
namespace Football_Fantasy.BuisnessLayer;

public class tablePaginations
{
    public static int numberOfPaginationsForSortAndFilter(int position, int sortType, int mode)
    {
        int numberOfPaginations = 0;
        List<Player> players = DataAccessLayer.player.getAllPlayersOfDatabase();
        List<Player> filteredPlayers= new List<Player>();
        List<Player> sortedAndFilteredPlayers = new List<Player>();
        if (position <= 4)
        {
            foreach (var player in players)
            {
                if (player.element_type == position)
                {
                    filteredPlayers.Add(player);
                }
            }
        }
        else
        {
            foreach (var player in players)
            {
                if (player.team == (position-4))
                {
                    filteredPlayers.Add(player);
                }
            }
        }
        if (sortType == 1)
        {
            sortedAndFilteredPlayers = filteredPlayers.OrderBy(o => o.now_cost).ToList();
            if (mode == 1)
            {
                sortedAndFilteredPlayers.Reverse();
            }

            numberOfPaginations = (sortedAndFilteredPlayers.Count / 20) + 1;
            return numberOfPaginations;
        }
        sortedAndFilteredPlayers = filteredPlayers.OrderBy(o => o.event_points).ToList();
        if (mode == 1)
        {
            sortedAndFilteredPlayers.Reverse();
            numberOfPaginations = (sortedAndFilteredPlayers.Count / 20) + 1;
            return numberOfPaginations;
        }
        numberOfPaginations = (sortedAndFilteredPlayers.Count / 20) + 1;
        return numberOfPaginations;
    }
    public static int numberOfPaginationsForAllPlayers()
    {
        List<Player> players = DataAccessLayer.player.getAllPlayersOfDatabase();
        int numberOfPaginations = (players.Count / 20) + 1;
        return numberOfPaginations;
    }

    public static int numberOfPaginationsForSearch(string webName)
    {
        int numberOfPaginations = 0;
        List<Player> response = new List<Player>();
        List<Player> players = new List<Player>();
        List<Player> searchedPlayers = new List<Player>();
        players = DataAccessLayer.player.getAllPlayersOfDatabase();
        StringComparison comp = StringComparison.OrdinalIgnoreCase;
        foreach (var player in players)
        {
            if (player.web_name.Contains(webName, comp))
            {
                searchedPlayers.Add(player);
            }
        }
        if (searchedPlayers.Count > 0)
        {
            numberOfPaginations = (searchedPlayers.Count / 20) + 1;
            return numberOfPaginations;
        }
        int[] wordPoints = new int[players.Count];
        for (int j = 0; j < players.Count; j++)
        {
            for (int i = 0; i < players[j].web_name.Length && i < webName.Length ; i++)
            {
                if (players[j].web_name[i] == webName[i])
                {
                    wordPoints[j]++;
                }
            }
        }
        int maxValue = wordPoints.Max();
        if (maxValue == 0)
        {
            return 0;
        }
        int indexOfMax = Array.IndexOf(wordPoints, maxValue);
        searchedPlayers.Add(players[indexOfMax]);
        numberOfPaginations = (searchedPlayers.Count / 20) + 1;
        return numberOfPaginations;
    }
}