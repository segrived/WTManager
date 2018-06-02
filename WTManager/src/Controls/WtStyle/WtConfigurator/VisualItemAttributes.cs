using System;

namespace WtManager.Controls.WtStyle.WtConfigurator
{
    [AttributeUsage(AttributeTargets.Property)]
    public class VisualItemAttribute : Attribute
    {
        public Type RendererType { get; private set; }

        public string GroupTitle { get; private set; }

        public VisualItemAttribute(Type rendererType, string group)
        {
            this.RendererType = rendererType;
            this.GroupTitle = group;
        }
    }

    public class VisualItemCustomizationAttribute : Attribute
    {
        public int CustomHeight { get; private set; }

        public VisualItemCustomizationAttribute(int customHeight = -1)
        {
            this.CustomHeight = customHeight;
        }
    }

    public class VisualItemDependentOnAttribute : Attribute
    {
        public string DependentProperty { get; private set; }
        public bool ReverseDependent { get; private set; }

        public VisualItemDependentOnAttribute(string dependentOnPropertName, bool reverseDependent = false)
        {
            this.DependentProperty = dependentOnPropertName;
            this.ReverseDependent = reverseDependent;
        }
    }
}
