﻿using Avalonia;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls
{
    public class ShadowButton : MaterialButton
    {
        /// <summary>
        /// Defines the padding of the Shadow
        /// </summary>
        public Thickness ShadowPadding
        {
            get => GetValue(ShadowPaddingProperty);
            set => SetValue(ShadowPaddingProperty, value);
        }
        public static readonly StyledProperty<Thickness> ShadowPaddingProperty =
            AvaloniaProperty.Register<ShadowButton, Thickness>(nameof(ShadowPadding), new Thickness(5));

        /// <summary>
        /// Gets or sets the <see cref="BoxShadow"/> of the Button
        /// </summary>
        public BoxShadow BoxShadow
        {
            get => GetValue(BoxShadowProperty);
            set => SetValue(BoxShadowProperty, value);
        }
        public static readonly StyledProperty<BoxShadow> BoxShadowProperty =
            AvaloniaProperty.Register<ShadowButton, BoxShadow>(nameof(BoxShadow), new BoxShadow() { Blur = 5, Color = Colors.Black });
    }
}
