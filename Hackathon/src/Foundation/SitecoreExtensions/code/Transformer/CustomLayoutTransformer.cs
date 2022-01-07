using Sitecore.JavaScriptServices.ViewEngine.LayoutService.Serialization;
using Sitecore.LayoutService.ItemRendering;
using System.Dynamic;

namespace Hackathon.Foundation.SitecoreExtensions.Transformer
{
    public class CustomLayoutTransformer : LayoutTransformer
    {
        public CustomLayoutTransformer(IPlaceholderTransformer placeholderTransformer) : base(placeholderTransformer)
        {
        }

        public override dynamic Transform(RenderedItem rendered)
        {
            var route = ((rendered.Name == null) ? null : new
            {
                name = rendered.Name,
                fields = rendered.Fields,
                placeholders = PlaceholderTransformer.TransformPlaceholders(rendered.Placeholders)
            });

            dynamic val = new ExpandoObject();

            val.sitecore = new
            {
                context = rendered.Context,
                route = route
            };
            return val;
        }
    }
}