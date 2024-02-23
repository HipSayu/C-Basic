using AppMobileBackEnd.Dtos.SearchHistory;

namespace AppMobileBackEnd.Services.Interfaces
{
    public interface ISearchHistoryServices
    {
        List<SearchHistoryDto> GetAll();

        void Create(CreateSearchHistoryDto input);

        void Delete(int IdSearchHistory);
    }
}
