using System.Collections.Generic;
using TestTaskBE.BusinessLogic.Interfaces.WebProviders;
using TestTaskBE.Common.Configuration;
using TestTaskBE.Common.Helpers;
using TestTaskBE.Common.WebModels;
using TestTaskBE.Contracts.Enums;

namespace TestTaskBE.BusinessLogic.Providers
{
    public class WebProvider : IWebProvider
    {
        private readonly NancyData _nancyData;

        public WebProvider(NancyData nancyData)
        {
            _nancyData = nancyData;
        }

        public ArticlesNYT GetArticlesNyt(SectionType sectionType)
        {
            return WebHelper.Get<ArticlesNYT>($"{_nancyData.TopStoriesUrl}{sectionType.ToString().ToLower()}.json?api-key={_nancyData.NancyApiKey}");
        }
    }
}
