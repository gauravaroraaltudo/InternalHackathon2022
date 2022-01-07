using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.LayoutService.Configuration;
using Sitecore.LayoutService.ItemRendering;
using Sitecore.LayoutService.Presentation.Pipelines.RenderJsonRendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hackathon.Foundation.SitecoreExtensions.RenderingExtension
{
    public class RenderingParamExtension : BaseRenderJsonRendering
    {
        public RenderingParamExtension(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void SetResult(RenderJsonRenderingArgs args)
        {
            Assert.ArgumentNotNull((object)args, nameof(args));
            Assert.IsNotNull((object)args.Result, "args.Result should not be null");
            if (args.Rendering == null || args.Rendering.Item == null)
                return;
            Item item = args.Rendering.Item;
            if (item == null)
                return;

            var renderedJsonRendering = new RenderedJsonRendering(args.Result);
            if (renderedJsonRendering.RenderingParams == null)
            {
                return;
            }

            try
            {
                IDictionary<string, string> paramKeyValues = renderedJsonRendering.RenderingParams;

                if (paramKeyValues != null && paramKeyValues.Count > 0)
                {
                    foreach (var param in args.Result.RenderingParams.ToList())
                    {
                        string value = string.Empty;

                        value = GetValue(param.Value);

                        if (!string.IsNullOrEmpty(value))
                        {
                            paramKeyValues[param.Key] = value;
                        }
                        else
                        {
                            paramKeyValues[param.Key] = string.Empty;
                        }
                    }
                    args.Result.RenderingParams = paramKeyValues;
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error occured in AddRenderingVariantValue.SetResult()", ex.Message);
            }
        }

        private string GetValue(string paramValue)
        {
            string value = string.Empty;
            ID sourceId;

            if (ID.TryParse(paramValue, out sourceId))
            {
                var sourceItem = Sitecore.Context.Database.GetItem(sourceId);

                if (sourceItem != null)
                {
                    value = sourceItem["value"];
                }
            }
            else
            {
                value = paramValue;
            }
            return value;
        }
    }
}