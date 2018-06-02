using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WtManager.Controls.WtStyle.WtConfigurator
{
    public class DynamicPropertiesProcessor
    {
        private readonly IVisualSourceObject _dataObject;

        private PropertyInfo[] Properties => this._dataObject.GetType().GetProperties();

        public DynamicPropertiesProcessor(IVisualSourceObject dataObject)
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

        public IEnumerable<DependentInfo> FindDependentControls(string dependencyName)
        {
            foreach (var propertyInfo in this.Properties)
            {
                var dependentOn = propertyInfo.GetCustomAttributes<VisualItemDependentOnAttribute>().ToList();
                var depOn = dependentOn.FirstOrDefault(d => d.DependentProperty == dependencyName);
                if (depOn != null)
                    yield return new DependentInfo(propertyInfo.Name, depOn.ReverseDependent);
            }
        }
    }

    public class DependentInfo
    {
        public string PropertyName;
        public bool IsReversed;

        public DependentInfo(string propertyName, bool isReversed)
        {
            this.PropertyName = propertyName;
            this.IsReversed = isReversed;
        }
    }
}