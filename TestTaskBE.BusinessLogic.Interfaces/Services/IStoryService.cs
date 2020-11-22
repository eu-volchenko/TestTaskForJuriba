using System;
using System.Collections.Generic;
using TestTaskBE.Common.WebModels;
using TestTaskBE.Contracts.Enums;
using TestTaskBE.Contracts.ResponseModels.Home;

namespace TestTaskBE.BusinessLogic.Interfaces.Services
{
    public interface IStoryService
    {
        List<ArticleResponseModel> GetStoriesBySection(SectionType sectionType);

        List<ArticleResponseModel> GetStoriesBySection(SectionType sectionType, Func<Result, bool> condition);

        List<ArticleGroupByDateResponseModel> GetArticleGroupBySection(SectionType sectionType);
    }
}
