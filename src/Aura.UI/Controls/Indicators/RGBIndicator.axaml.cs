﻿using Aura.UI.Attributes;
using Aura.UI.Helpers;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace Aura.UI.Controls.Indicators
{
    [TemplatePart(Name = "PART_RText", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_GText", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_BText", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_AText", Type = typeof(TextBlock))]
    public class RGBIndicator : TemplatedControl
    {
        TextBlock R_;
        TextBlock G_;
        TextBlock B_;
        TextBlock A_; 
        public RGBIndicator()
        {
            this.InitializeComponent();
        }

        public Color ColorToShow
        {
            get { return GetValue(ColorToShowProperty); }
            set { SetValue(ColorToShowProperty, value); }
        }
        public static readonly StyledProperty<Color> ColorToShowProperty =
            AvaloniaProperty.Register<HSLIndicator, Color>(nameof(ColorToShow), Colors.White);


        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            this.R_ = this.GetControl<TextBlock>(e, "PART_RText");
            this.G_ = this.GetControl<TextBlock>(e, "PART_GText");
            this.B_ = this.GetControl<TextBlock>(e, "PART_BText");
            this.A_ = this.GetControl<TextBlock>(e, "PART_AText");

            this.PropertyChanged += RGBIndicator_PropertyChanged;
        }

        private void RGBIndicator_PropertyChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
            this.UpdateRGB(new RGBStruct(ColorToShow));
        }

        internal void UpdateRGB(RGBStruct @struct)
        {
            this.R_.Text = @struct.r.ToString();
            this.G_.Text = @struct.g.ToString();
            this.B_.Text = @struct.b.ToString();
            this.A_.Text = @struct.a.ToString();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
