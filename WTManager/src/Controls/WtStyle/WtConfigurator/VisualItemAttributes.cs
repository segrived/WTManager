using System;

namespace WTManager.Controls.WtStyle.WtConfigurator
{
    [AttributeUsage(AttributeTargets.Property)]
    public class VisualItemAttribute : Attribute
    {
        public Type RendererType { get; private set; }

        public string GroupTitle { get; private set; }
        public string DisplayText { get; private set; }

        public VisualItemAttribute(Type rendererType, string displayText, string group)
        {
            this.RendererType = rendererType;
            this.GroupTitle = group;
            this.DisplayText = displayText;
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

        public VisualItemDependentOnAttribute(string dependentOnPropertName)
        {
            this.DependentProperty = dependentOnPropertName;
        }
    }

    public class VisualItemExpandibleAttribute : Attribute
    { 
    }
}
