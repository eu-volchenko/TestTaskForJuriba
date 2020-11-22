using System;
using System.Collections.Generic;
using System.Linq;
using TestTaskBE.BusinessLogic.Interfaces.Factories;
using TestTaskBE.BusinessLogic.Interfaces.Services;
using TestTaskBE.BusinessLogic.Interfaces.WebProviders;
using TestTaskBE.Common.Extensions;
using TestTaskBE.Common.WebModels;
using TestTaskBE.Contracts.Enums;
using TestTaskBE.Contracts.ResponseModels.Home;

namespace TestTaskBE.BusinessLogic.Services
{
    public class StoryService : IStoryService
    {
        private readonly IWebProvider _webProvider;
        private readonly IMapperFactory _mapperFactory;

        public StoryService(IWebProvider webProvider, IMapperFactory mapperFactory)
        {
            _webProvider = webProvider;
            _mapperFactory = mapperFactory;
        }

        public List<ArticleGroupByDateResponseModel> GetArticleGroupBySection(SectionType sectionType)
        {
            sectionType.ThrowIfDefault(nameof(sectionType));

            var articlesResult = _webProvider.GetArticlesNyt(sectionType);

            if (articlesResult == null || articlesResult.results?.Count == 0)
            {
                throw new System.Exception("Nothing has been returned.");
            }

            return _mapperFactory.GetMapper<ArticlesNYT, ArticleGroupByDateResponseModel>().Map(articlesResult);
        }

        public List<ArticleResponseModel> GetStoriesBySection(SectionType sectionType)
        {
            sectionType.ThrowIfDefault(nameof(sectionType));

            return GetStoriesBySectionAndFilter(sectionType);
        }

        public List<ArticleResponseModel> GetStoriesBySection(SectionType sectionType, Func<Result, bool> condition)
        {
            sectionType.ThrowIfDefault(nameof(sectionType));
            condition.ThrowIfNull(nameof(condition));

            return GetStoriesBySectionAndFilter(sectionType, condition);
        }

        private List<ArticleResponseModel> GetStoriesBySectionAndFilter(SectionType sectionType, Func<Result, bool> condition = null)
        {
            sectionType.ThrowIfDefault(nameof(sectionType));

            var articlesResult = _webProvider.GetArticlesNyt(sectionType);

            if (articlesResult == null || articlesResult.results?.Count == 0)
            {
                throw new System.Exception("Nothing has been returned.");
            }

            if (condition != null)
            {
                articlesResult.results = articlesResult.results.Where(condition).ToList();
            }

            return _mapperFactory.GetMapper<ArticlesNYT, ArticleResponseModel>().Map(articlesResult);
        }
    }
}
