using System.Collections.Generic;
using TestTaskBE.BusinessLogic.Interfaces.Mappings;
using TestTaskBE.Common.WebModels;
using TestTaskBE.Contracts.ResponseModels.Home;

namespace TestTaskBE.BusinessLogic.Mappings
{
    public class ArticleNytToArticleResponseModelMapper : IMapper<ArticlesNYT, ArticleResponseModel>
    {
        public List<ArticleResponseModel> Map(ArticlesNYT dataToMap)
        {
            var results = new List<ArticleResponseModel>();

            foreach(var item in dataToMap.results)
            {
                var result = new ArticleResponseModel();

                result.Updated = item.updated_date;
                result.Heading = item.title;
                result.Link = item.short_url;

                results.Add(result);
            }

            return results;
        }
    }
}
