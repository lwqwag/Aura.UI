﻿using Aura.UI.Attributes;
using Aura.UI.Helpers;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Microsoft.Toolkit.Extensions;
using System;

namespace Aura.UI.Controls.Indicators
{
    [TemplatePart(Name = "PART_HText", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_SText", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_LText", Type = typeof(TextBlock))]
    public class HSLIndicator : TemplatedControl
    {
        TextBlock H_;
        TextBlock S_;
        TextBlock L_;
        public HSLIndicator()
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

            this.H_ = this.GetControl<TextBlock>(e, "PART_HText");
            this.S_ = this.GetControl<TextBlock>(e, "PART_SText");
            this.L_ = this.GetControl<TextBlock>(e, "PART_LText");
            this.PropertyChanged += HSLIndicator_PropertyChanged;
        }

        private void HSLIndicator_PropertyChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
            this.UpdateHSL(new HSLStruct(ColorToShow));
        }

        internal void UpdateHSL(HSLStruct @struct)
        {
            this.H_.Text = (Math.Round(@struct.hue, 1) * 360).ToString().Truncate(3);
            var sat = Math.Round(@struct.saturation / 1, 3) * 100;
            var lg = Math.Round(@struct.lightness / 1, 3) * 100;
            if (sat  == 100)
            {
                this.S_.Text = sat.ToString().Truncate(3) + "%";
            }
            else if (sat > 9 & sat < 100)
            {
                this.S_.Text = sat.ToString().Truncate(2) + "%";
                return;
            }
            else
            {
                this.S_.Text = sat.ToString().Truncate(1) + "%";
                return;
            }
            if (lg == 100)
            {
                this.L_.Text = lg.ToString().Truncate(3) + "%";
            }
            else if(lg > 9 & lg < 100)
            {
                this.L_.Text = lg.ToString().Truncate(2) + "%";
                return;
            }
            else
            {
                this.L_.Text = lg.ToString().Truncate(1) + "%";
                return;
            }

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
