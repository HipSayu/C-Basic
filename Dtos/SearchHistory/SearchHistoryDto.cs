using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppMobileBackEnd.Dtos.SearchHistory
{
    public class SearchHistoryDto
    {        
        public int IdSearchHistory { get; set; }

        public string Search { get; set; }

        public DateTime TimeSearch { get; set; }
    }
}
