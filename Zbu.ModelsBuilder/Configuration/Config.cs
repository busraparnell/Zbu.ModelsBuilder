﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zbu.ModelsBuilder.Configuration
{
    public static class Config
    {
        // fixme - the NuGet package should add the .models BuildProvider
        // fixme - the UmbracoPackage should add the .models BuildProvider
        // fixme - we should have our own config section
        // fixme - should ask questions when installing?

        /// <summary>
        /// Gets a value indicating whether "App_Code models" are enabled. 
        /// </summary>
        /// <remarks>
        ///     <para>Indicates whether a "build.models" file should be created in App_Code and associated
        ///     to a build provider so that models created in App_Data are automatically included in the site
        ///     build and made available to the view.</para>
        ///     <para>Default value is <c>false</c> because once enabled, Umbraco will restart anytime models
        ///     are re-generated from the dashboard. This is probably what you want to do, but we're forcing
        ///     you to make a concious decision at the moment.</para>
        ///     <para>Enabling "App_Code models" models also enables "App_Data models".</para>
        /// </remarks>
        public static bool EnableAppCodeModels
        {
            get { return ConfigurationManager.AppSettings["Zbu.ModelsBuilder.CreateAppCodeModelsFile"] == "true"; }
        }

        /// <summary>
        /// Gets a value indicating whether "App_Data models" are enabled.
        /// </summary>
        /// <remarks>
        ///     <para>Default value is <c>false</c>.</para>
        ///     <para>When "App_Data models" is enabled, the dashboard shows the "generate" button so that
        ///     models can be generated in App_Data/Models. Whether they will be just sitting there or loaded
        ///     and compiled depends on EnableAppCoreModels.</para>
        /// </remarks>
        public static bool EnableAppDataModels
        {
            get { return ConfigurationManager.AppSettings["Zbu.ModelsBuilder.EnableAppDataModels"] == "true"
                || EnableAppCodeModels; }
        }

        // fixme - requires the Razor custom engine...
        // fixme - this does not work "out of the box" at the moment
        // fixme - must document this...

        /// <summary>
        /// Gets a value indicating whether "live models" are enabled.
        /// </summary>
        /// <remarks>
        ///     <para>Indicates whether the models created in App_Data are automatically compiled
        ///     and loaded into an assembly referenced by our custom Razor engine, so they are
        ///     available to views and are updated when content types change, without Umbraco
        ///     restarting.</para>
        ///     <para>Default value is <c>false</c>.</para>
        ///     <para>Enabling "live" models also enables "App_Data models".</para>
        /// </remarks>
        public static bool EnableLiveModels
        {
            get { return ConfigurationManager.AppSettings["Zbu.ModelsBuilder.EnableLiveModels"] == "true"; }
        }

        /// <summary>
        /// Gets a value indicating whether to enable the API.
        /// </summary>
        /// <remarks>
        ///     <para>Default value is <c>true</c>.</para>
        ///     <para>The API is used by the Visual Studio extension and the console tool to talk to Umbraco
        ///     and retrieve the content types. It needs to be enabled so the extension & tool can work.</para>
        /// </remarks>
        public static bool EnableApi
        {
            get { return ConfigurationManager.AppSettings["Zbu.ModelsBuilder.EnableApi"] != "false"; }
        }

        /// <summary>
        /// Gets the models namespace.
        /// </summary>
        /// <remarks>No default value. That value could be overriden by other (attribute in user's code...).</remarks>
        public static string ModelsNamespace
        {
            get { return ConfigurationManager.AppSettings["Zbu.ModelsBuilder.ModelsNamespace"]; }
        }

        /// <summary>
        /// Gets a value indicating whether we should enable the models factory.
        /// </summary>
        /// <remarks>Default value is <c>true</c> because no factory is enabled by default in Umbraco.</remarks>
        public static bool EnablePublishedContentModelsFactory
        {
            get { return ConfigurationManager.AppSettings["Zbu.ModelsBuilder.EnablePublishedContentModelsFactory"] != "false"; }
        }

    }
}