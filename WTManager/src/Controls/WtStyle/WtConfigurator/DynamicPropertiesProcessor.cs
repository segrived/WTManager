using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WTManager.Controls.WtStyle.WtConfigurator
{
    public class DynamicPropertiesProcessor
    {
        private readonly IVisualProviderObject _dataObject;

        private PropertyInfo[] Properties => this._dataObject.GetType().GetProperties();

        public DynamicPropertiesProcessor(IVisualProviderObject dataObject)
        {
            this._dataObject = dataObject;
        }

        public IEnumerable<string> EnumerateGroupNames()
        {
            return this.Properties.Select(this.GetGroupName).Distinct();
        }

        private bool IsVisualRendererProperty(PropertyInfo prop)
            => prop.GetCustomAttribute<VisualItemAttribute>() != null;

        private string GetGroupName(PropertyInfo prop) 
            => prop.GetCustomAttribute<VisualItemAttribute>()?.GroupTitle ?? String.Empty;

        public List<PropertyInfo> GetGroupProperties(string groupName)
        {
            var propertiesList = new List<PropertyInfo>();

            foreach (var prop in this.Properties)
            {
                if (this.IsVisualRendererProperty(prop) && this.GetGroupName(prop) == groupName)
                    propertiesList.Add(prop);
            }
            return propertiesList;
        }
    }
}