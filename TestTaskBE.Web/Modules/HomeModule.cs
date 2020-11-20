using Nancy;

namespace TestTaskBE.Web.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", _ => "Api works!");

            Get("/list/{section}", args =>
            {
                return args.section;
            });
        }
    }
}
