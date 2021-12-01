﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AC.Placeholder.Extensions;
using Umbraco.Web.Routing;
using Umbraco.Core.Composing;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Composing;

namespace AC.Placeholder.Components
{
    /// <summary>
    /// Filter out all components from the request, so it's not accessable via URL
    /// </summary>
    public class FilterOutComponent : IComponent
    {
        public void Initialize()
        {
            
            PublishedRequestBuilder.
            PublishedContentRequest
            PublishedRequest.Prepared += PublishedRequest_Prepared;
        }

        private void PublishedRequest_Prepared(object sender, EventArgs e)
        {
            if (sender is PublishedRequest request)
            {
                if (!request.PublishedContent.TemplateId.HasValue && request.PublishedContent.Parent.IsComponent())
                {
                    request.SetRedirect("~/");
                }

                if (request.PublishedContent.IsComponent())
                {
                    request.SetRedirect("~/");
                }
            }
        }

        public void Terminate()
        {
            PublishedRequest.Prepared -= PublishedRequest_Prepared;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}