using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.LayoutService.ItemRendering.Pipelines.GetLayoutServiceContext;
using Sitecore.Links;
using System.Collections.Generic;

namespace Hackathon.Foundation.SitecoreExtensions.ContextData
{
    public class ItemUrlContext : IGetLayoutServiceContextProcessor
    {
        public const string Key = "itemUrl";

        public void Process(GetLayoutServiceContextArgs args)
        {
            if (Context.Item != null)
            {
                Assert.ArgumentNotNull((object)args, nameof(args));
                IDictionary<string, object> contextData = args.ContextData;
                var options = LinkManager.GetDefaultUrlBuilderOptions();

                options.AlwaysIncludeServerUrl = true;
                string link = LinkManager.GetItemUrl(Context.Item, options);

                args.ContextData.Add(Key, link);
            }
        }
    }
}