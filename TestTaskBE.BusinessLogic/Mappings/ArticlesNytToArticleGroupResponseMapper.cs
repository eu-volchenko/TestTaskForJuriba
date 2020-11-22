using System.Collections.Generic;
using System.Linq;
using TestTaskBE.BusinessLogic.Interfaces.Mappings;
using TestTaskBE.Common.Extensions;
using TestTaskBE.Common.WebModels;
using TestTaskBE.Contracts.ResponseModels.Home;

namespace TestTaskBE.BusinessLogic.Mappings
{
    public class ArticlesNytToArticleGroupResponseMapper : IMapper<ArticlesNYT, ArticleGroupByDateResponseModel>
    {
        public List<ArticleGroupByDateResponseModel> Map(ArticlesNYT dataToMap)
        {
            dataToMap.ThrowIfNull(nameof(dataToMap));

            var mappedResults = new List<ArticleGroupByDateResponseModel>();

            var dateGroups = dataToMap.results.GroupBy(x => x.updated_date.ToString("yyyy-MM-dd"));

            foreach (var group in dateGroups)
            {
                var mappedResult = new ArticleGroupByDateResponseModel();

                mappedResult.Date = group.Key;
                mappedResult.Total = group.Count();

                mappedResults.Add(mappedResult);
            }

            return mappedResults;
        }
    }
}
