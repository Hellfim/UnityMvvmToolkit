using UnityEngine.UIElements;

namespace UnityMvvmToolkit.UITK.BindableUIElements
{
    [UxmlElement]
    public abstract partial class BaseButton : Button
    {
        [UxmlAttribute("enabled")]
        public bool Enabled
        {
            get => enabledSelf;
            set => SetEnabled(value);
        }
    }
}