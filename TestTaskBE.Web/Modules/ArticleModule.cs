using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using TestTaskBE.BusinessLogic.Interfaces.Services;
using TestTaskBE.Contracts.Enums;
using TestTaskBE.Contracts.ResponseModels.Home;

namespace TestTaskBE.Web.Modules
{
    public class ArticleModule : NancyModule
    {
        public ArticleModule(IStoryService storyService)
        {
            Get("/", _ => $"test");

            Get("/list/{section}", args =>
            {
                if (Enum.TryParse(args.section.Value, out SectionType sectionType))
                {
                    var stories = storyService.GetStoriesBySection(sectionType);

                    return Response.AsJson(stories);
                }

                throw new ArgumentException("Section is incorrect");
            });

            Get("/list/{section}/first", args =>
            {
                if (Enum.TryParse(args.section.Value, out SectionType sectionType))
                {
                    var stories = storyService.GetStoriesBySection(sectionType);

                    return Response.AsJson(stories.FirstOrDefault());
                }

                throw new ArgumentException("Section is incorrect");
            });

            Get("/list/{section}/{updatedDate}", args =>
            {
                if (Enum.TryParse(args.section.Value, out SectionType sectionType))
                {
                    var updateDate = args.updatedDate.Value;

                    List<ArticleResponseModel> stories = storyService.GetStoriesBySection(sectionType, x => x.updated_date.ToString("yyyy-MM-dd") == updateDate);

                    return Response.AsJson(stories);
                }

                throw new ArgumentException("Section is incorrect");
            });

            Get("/group/{section}", args =>
            {
                if (Enum.TryParse(args.section.Value, out SectionType sectionType))
                {
                    var groups = storyService.GetArticleGroupBySection(sectionType);

                    return Response.AsJson(groups);
                }

                throw new ArgumentException("Section is incorrect");
            });

            Get("/article/{shortUrl}", args =>
            {
                var shortUrl = args.shortUrl.Value;

                List<ArticleResponseModel> stories = storyService.GetStoriesBySection(SectionType.Home, x => x.short_url.Contains(shortUrl));

                return shortUrl;
            });
        }
    }
}
