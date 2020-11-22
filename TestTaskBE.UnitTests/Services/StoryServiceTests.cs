using Moq;
using System;
using System.Linq;
using TestTaskBE.BusinessLogic.Interfaces.Factories;
using TestTaskBE.BusinessLogic.Interfaces.WebProviders;
using TestTaskBE.BusinessLogic.Mappings;
using TestTaskBE.BusinessLogic.Services;
using TestTaskBE.Common.WebModels;
using TestTaskBE.Contracts.Enums;
using TestTaskBE.Contracts.ResponseModels.Home;
using Xunit;

namespace TestTaskBE.BusinessLogic.UnitTests.Services
{
    public class StoryServiceTests
    {
        [Fact]
        public void GetStoriesBySectionReturnsDataWithAllStoriesForHomeSection()
        {
            var sectionType = SectionType.Home;
            var mockProvider = new Mock<IWebProvider>();
            mockProvider.Setup(provider => provider.GetArticlesNyt(sectionType)).Returns(GetArticles());

            var mockMapperFabric = new Mock<IMapperFactory>();
            mockMapperFabric.Setup(fabric => fabric.GetMapper<ArticlesNYT, ArticleResponseModel>()).Returns(new ArticleNytToArticleResponseModelMapper());

            var storyService = new StoryService(mockProvider.Object, mockMapperFabric.Object);

            var result = storyService.GetStoriesBySection(sectionType);

            Assert.Equal(GetArticles().results.Count, result.Count);
        }

        [Fact]
        public void GetArticleGroupBySectionReturnsDataWithAllStoriesForHomeSection()
        {
            var sectionType = SectionType.Home;
            var mockProvider = new Mock<IWebProvider>();
            mockProvider.Setup(provider => provider.GetArticlesNyt(sectionType)).Returns(GetArticles());

            var mockMapperFabric = new Mock<IMapperFactory>();
            mockMapperFabric.Setup(fabric => fabric.GetMapper<ArticlesNYT, ArticleGroupByDateResponseModel>()).Returns(new ArticlesNytToArticleGroupResponseMapper());

            var storyService = new StoryService(mockProvider.Object, mockMapperFabric.Object);

            var result = storyService.GetArticleGroupBySection(sectionType);

            Assert.Equal(GetArticles().results.Count, result.Count);
        }

        [Fact]
        public void GetStoriesBySectionReturnsDataWithAllStoriesForHomeSectionWithFilter()
        {
            var sectionType = SectionType.Home;
            var mockProvider = new Mock<IWebProvider>();
            mockProvider.Setup(provider => provider.GetArticlesNyt(sectionType)).Returns(GetArticles());

            var mockMapperFabric = new Mock<IMapperFactory>();
            mockMapperFabric.Setup(fabric => fabric.GetMapper<ArticlesNYT, ArticleResponseModel>()).Returns(new ArticleNytToArticleResponseModelMapper());

            var storyService = new StoryService(mockProvider.Object, mockMapperFabric.Object);

            var result = storyService.GetStoriesBySection(sectionType, x => x.section.ToLower() == "home");

            Assert.Equal(GetArticles().results.Where(x => x.section == "home").Count(), result.Count);
        }

        private ArticlesNYT GetArticles()
        {
            var article = new ArticlesNYT()
            {
                status = "OK",
                copyright = "Some information",
                section = "home",
                last_updated = DateTime.Now,
                num_results = 2,
                results = new System.Collections.Generic.List<Result>()
                {
                    new Result
                    {
                        section = "us",
                        subsection = "politics",
                        title = "Business and World Leaders Move On as Trump Fights to Reverse Election",
                        @abstract = "test",
                        url = "http://test.com",
                        uri = "http://test2.com",
                        byline = "tset",
                        item_type = "Article",
                        updated_date = DateTime.Now,
                        created_date = DateTime.Now,
                        published_date = DateTime.Now,
                        material_type_facet = "",
                        kicker = "",
                        short_url = "test"
                    },

                     new Result
                    {
                        section = "us",
                        subsection = "politics",
                        title = "Business and World Leaders Move On as Trump Fights to Reverse Election 2",
                        @abstract = "test",
                        url = "http://test.com",
                        uri = "http://test2.com",
                        byline = "tset",
                        item_type = "Article",
                        updated_date = DateTime.Now.AddDays(3),
                        created_date = DateTime.Now.AddDays(3),
                        published_date = DateTime.Now.AddDays(3),
                        material_type_facet = "",
                        kicker = "",
                        short_url = "test"
                    }
                }
            };

            return article;
        }
    }
}