﻿using UnityEngine.UIElements;
using UnityMvvmToolkit.Core;
using UnityMvvmToolkit.Core.Interfaces;

namespace UnityMvvmToolkit.UITK.BindableUIElements
{
    [UxmlElement]
    public partial class BindingContextProvider : BindingContextProvider<IBindingContext>
    {
        protected override IReadOnlyProperty<IBindingContext> RentBindingContextProperty(IBindingContext context,
            IObjectProvider objectProvider, PropertyBindingData propertyBindingData)
        {
            return objectProvider.RentReadOnlyPropertyAs<IBindingContext>(context, propertyBindingData);
        }
    }
}