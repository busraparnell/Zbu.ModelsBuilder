﻿using System.Collections.Generic;
using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Models.PublishedContent;

namespace Umbraco.ModelsBuilder
{
    public static class PublishedPropertyTypeExtensions
    {
        public static KeyValuePair<int, string>[] PreValues(this PublishedPropertyType propertyType)
        {
            return ApplicationContext.Current.Services.DataTypeService
                .GetPreValuesCollectionByDataTypeId(propertyType.DataType.Id)
                .PreValuesAsArray
                .Select(x => new KeyValuePair<int, string>(x.Id, x.Value))
                .ToArray();
        }
    }
}
