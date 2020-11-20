using System.Collections.Generic;
using System.Threading.Tasks;
using TestTaskBE.Contracts.Enums;
using TestTaskBE.ViewModels.HomeViewModels;

namespace TestTaskBE.BuisnessLogic.Interfaces.Services
{
    public interface IStoryService
    {
        Task<List<ArticleResponseModel>> GetStoriesBySectionAsync(SectionType sectionType);
    }
}
