using System.Collections.Generic;
using System.Threading.Tasks;
using TestTaskBE.BuisnessLogic.Interfaces.Services;
using TestTaskBE.Contracts.Enums;
using TestTaskBE.ViewModels.HomeViewModels;

namespace TestTaskBE.BuisnessLogic.Services
{
    class StoryService : IStoryService
    {
        public async Task<List<ArticleResponseModel>> GetStoriesBySectionAsync(SectionType sectionType)
        {
            
        }
    }
}
