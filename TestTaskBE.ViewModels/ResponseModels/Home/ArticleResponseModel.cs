using System;

namespace TestTaskBE.Contracts.ResponseModels.Home
{
    public class ArticleResponseModel
    {
        public string Heading { get; set; }

        public DateTime Updated { get; set; }

        public string Link { get; set; }
    }
}
