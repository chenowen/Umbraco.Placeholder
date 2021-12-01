﻿using System;
using System.Linq;
using AC.Placeholder.Components;
using AC.Placeholder.ContentStructures;
using AC.Placeholder.Resolvers;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace AC.Placeholder
{
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class ServicesRegister : IComposer
    {
        public ServicesRegister()
        {

        }

        public void Compose(Composition composition)
        {
            //Redirect Component to home page or it's parent page
            composition.Components().Append<FilterOutComponent>();



            //Setup content structure
            composition.Components().Append<InitialComponentFolderComponent>();

            // Resolvers
            composition.Register(typeof(IComponentResolver), typeof(ComponentResolver), Lifetime.Singleton);
            composition.Register(typeof(IPlaceholderResolver), typeof(PlaceholderResolver), Lifetime.Singleton);
        }

        public void Compose(IUmbracoBuilder builder)
        {
            builder.Components().Append<FilterOutComponent>();
            
            throw new NotImplementedException();
        }
    }
}