using TestTaskBE.Common.WebModels;
using TestTaskBE.Contracts.Enums;

namespace TestTaskBE.BusinessLogic.Interfaces.WebProviders
{
    public interface IWebProvider
    {
        ArticlesNYT GetArticlesNyt(SectionType sectionType);
    }
}
