﻿using Aura.UI.Attributes;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;
using Avalonia.Markup.Xaml;
using Avalonia.Metadata;

namespace Aura.UI.Controls
{
    [TemplatePart(Name = "PART_Thumb", Type = typeof(Thumb))]
    public class FilledSlider : Slider
    {
        public FilledSlider()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public IControlTemplate ThumbTemplate
        {
            get { return GetValue(ThumbTemplateProperty); }
            set { SetValue(ThumbTemplateProperty, value); }
        }
        public static readonly StyledProperty<IControlTemplate> ThumbTemplateProperty =
            AvaloniaProperty.Register<FilledSlider, IControlTemplate>(nameof(ThumbTemplate));

        public object RightContent
        {
            get { return GetValue(RightContentProperty); }
            set { SetValue(RightContentProperty, value); }
        }
        public static readonly StyledProperty<object> RightContentProperty =
            AvaloniaProperty.Register<FilledSlider, object>(nameof(RightContent), "Right");

        public object LeftContent
        {
            get { return GetValue(LeftContentProperty); }
            set { SetValue(LeftContentProperty, value); }
        }
        public static readonly StyledProperty<object> LeftContentProperty =
            AvaloniaProperty.Register<FilledSlider, object>(nameof(LeftContent), "Left");
    }
}
