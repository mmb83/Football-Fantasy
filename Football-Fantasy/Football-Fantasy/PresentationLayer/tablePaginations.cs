using System.Runtime.InteropServices.JavaScript;

namespace Football_Fantasy.PresentationLayer;

public class tablePaginations
{
    public static List<Object> numberOfPaginationsForAllPlayers()
    {
        List<Object> response = new List<object>();
        int numberOfPaginations = BuisnessLayer.tablePaginations.numberOfPaginationsForAllPlayers();
        response.Add(new
        {
            message=numberOfPaginations
        });
        return response;
    }

    public static List<Object> numberOfPaginationsForSearch(string webName)
    {
        List<Object> response = new List<object>();
        int numberOfPaginations = BuisnessLayer.tablePaginations.numberOfPaginationsForSearch(webName);
        response.Add(new
        {
            message=numberOfPaginations
        });
        return response;
    }

    public static List<Object> numberOfPaginationsForSortAndFilter(int position, int sortType, int mode)
    {
        List<Object> response = new List<object>();
        int numberOfPaginations = BuisnessLayer.tablePaginations.numberOfPaginationsForSortAndFilter(position, sortType, mode);
        response.Add(new
        {
            message=numberOfPaginations
        });
        return response;
    }
    
}