﻿using Aura.UI.Attributes;
using Aura.UI.Controls.Primitives;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Styling;
using Avalonia.Threading;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Navigation
{
    [TemplatePart(Name = "PART_ToggleNav", Type = typeof(NavigationViewItem))]
    public class NavigationView : TabViewBase, IHeadered
    {
        #region Fields
        NavigationViewItem ToggleNav;
        #endregion

        #region Functionalities
        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            ToggleNav = this.GetControl<NavigationViewItem>(e, "PART_ToggleNav");
            ToggleNav.PointerPressed += ToggleNav_PointerPressed;
        }


        private void ToggleNav_PointerPressed(object sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            ToggleNavigationViewExpansionState(this);
        }

        public static void ToggleNavigationViewExpansionState(NavigationView navigationView)
        {
            var e = navigationView.ExpansionState;
            switch (e)
            {
                case ExpansionState.Total:
                    navigationView.ExpansionState = ExpansionState.Hidden;
                    break;
                case ExpansionState.Hidden:
                    navigationView.ExpansionState = ExpansionState.Total;
                    break;
            }
        }
        #endregion
        #region Properties
        /// <summary>
        /// Get or set the expansion state of the NavigationView
        /// </summary>
        public ExpansionState ExpansionState
        {
            get { return GetValue(ExpansionStateProperty); }
            set { SetValue(ExpansionStateProperty, value); }
        }
        public static readonly StyledProperty<ExpansionState> ExpansionStateProperty =
            AvaloniaProperty.Register<NavigationView, ExpansionState>(nameof(ExpansionState), ExpansionState.Total);

        public object Header
        {
            get => GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }
        public static readonly StyledProperty<object> HeaderProperty =
            AvaloniaProperty.Register<NavigationView, object>(nameof(Header), "Navigation View");

        public ITemplate HeaderTemplate
        {
            get => GetValue(HeaderTemplateProperty);
            set => SetValue(HeaderTemplateProperty, value);
        }
        public static readonly StyledProperty<ITemplate> HeaderTemplateProperty =
            AvaloniaProperty.Register<NavigationView, ITemplate>(nameof(HeaderTemplate));
        #endregion
    }
}
