using TestTaskBE.BusinessLogic.Factories;
using TestTaskBE.BusinessLogic.Mappings;
using TestTaskBE.Common.WebModels;
using TestTaskBE.Contracts.ResponseModels.Home;
using Xunit;

namespace TestTaskBE.BusinessLogic.UnitTests.Factories
{
    public class MapperFactoryTests
    {
        [Fact]
        public void GetMapperForArticleResponseModel()
        {
            var mapperFactory = new MapperFactory();

            var result = mapperFactory.GetMapper<ArticlesNYT, ArticleResponseModel>();

            Assert.IsType<ArticleNytToArticleResponseModelMapper>(result);
        }

        [Fact]
        public void GetMapperForArticleGroupByDateResponseModel()
        {
            var mapperFactory = new MapperFactory();

            var result = mapperFactory.GetMapper<ArticlesNYT, ArticleGroupByDateResponseModel>();

            Assert.IsType<ArticlesNytToArticleGroupResponseMapper>(result);
        }
    }
}
