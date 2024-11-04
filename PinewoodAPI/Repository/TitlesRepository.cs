using PinewoodAPI.Data;
using PinewoodAPI.Interfaces;
using PinewoodAPI.Models;

namespace PinewoodAPI.Repository
{
    public class TitlesRepository : ITitlesRepository
    {
        private readonly DataContext _dataContext;

        public TitlesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public ICollection<Title> GetTitles()
        {
            return _dataContext.Titles.OrderBy(p => p.TitleId).ToList();
        }
    }
}
