using System.Windows.Media;
using Xceed.Wpf.Toolkit;

namespace kursach.Modules
{
    public class XceedColorItemAdapter 
    {
        public Color Color { get; }
        public string DisplayName { get; }

        public XceedColorItemAdapter(Color color, string displayName)
        {
            Color = color;
            DisplayName = displayName;
        }
    }
}
