using System.Collections.ObjectModel;
using UnityEngine.UIElements;
using UnityMvvmToolkit.Common.Interfaces;

namespace UnityMvvmToolkit.UITK.BindableUIElements
{
    [UxmlElement]
    public abstract partial class BindableListView<TItemBindingContext> : 
        BindableListView<TItemBindingContext, ObservableCollection<TItemBindingContext>>
        where TItemBindingContext : ICollectionItem
    {
    }
}