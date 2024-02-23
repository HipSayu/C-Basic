using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppMobileBackEnd.Dtos.SearchHistory
{
    public class CreateSearchHistoryDto
    {
        public string Search { get; set; }

        public DateTime TimeSearch { get; set; }
    }
}
