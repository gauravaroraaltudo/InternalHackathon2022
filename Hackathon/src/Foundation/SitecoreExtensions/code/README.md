# Sitecore JSS with SSR
### Hackathon.Foundation.SitecoreExtensions

This project contains the customizations in the JSS pipelines.
We have customized the following sections of Layout Service in this project.
- Rendering Parameters
- Layout Service Context
- Route Data

## Rendering Paramters
> Hackathon.Foundation.SitecoreExtensions.RenderingExtension.RenderingParamExtension

By default, Sitecore provides rendering parameters as Key-Value pairs. In classic MVC, when we have DropLink datatype in Rendering Parameters we use to get the refered item in the code but when we move to JSS,  front-end(React JS or Angular JS) don't have luxury to reach sitecore and fetch details from there. In order to make things work, we have customized the pipeline so that when rendering parameters are delivered through Layout service then those can be easily utilised through front-end.

## Layout Service Context
> Hackathon.Foundation.SitecoreExtensions.ContextData.ItemUrlContext

By default, Sitecore provides very few details in Layout service context. We wanted to have the URL of current page in Layout Service. So, we extended it as well. This can serve as a foundation for further optimizations need in Layout Service Context.

![Alt text](../../../../../../screenshots/ExtendedLayoutServiceContext.png?raw=true "Optional Title")

## Route Data
> Hackathon.Foundation.SitecoreExtensions.Transformer.CustomLayoutTransformer

By default, Sitecore provides a lot of data in route section which has performance impact. We have reduce the data send in route which is not required. By doing this the JSON size will be reduced making out solution more effective.
