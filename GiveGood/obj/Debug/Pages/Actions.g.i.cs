﻿#pragma checksum "..\..\..\Pages\Actions.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E623B42AF9B3ADD011186A315D19780207C68A3AF71982CC1D9EE18A2286D76F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using GiveGood.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace GiveGood.Pages {
    
    
    /// <summary>
    /// Actions
    /// </summary>
    public partial class Actions : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 30 "..\..\..\Pages\Actions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Found;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Pages\Actions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SearchText;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Pages\Actions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Search;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Pages\Actions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddAction;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Pages\Actions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Type;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Pages\Actions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Status;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Pages\Actions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock District;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Pages\Actions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TypeFilt;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Pages\Actions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox StatusFilt;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Pages\Actions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox DistrictFilt;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Pages\Actions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox isOwned;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Pages\Actions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ActionList;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GiveGood;component/pages/actions.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\Actions.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\Pages\Actions.xaml"
            ((GiveGood.Pages.Actions)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Found = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.SearchText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.Search = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\..\Pages\Actions.xaml"
            this.Search.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Search_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AddAction = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\Pages\Actions.xaml"
            this.AddAction.Click += new System.Windows.RoutedEventHandler(this.AddAction_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Type = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.Status = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.District = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.TypeFilt = ((System.Windows.Controls.ComboBox)(target));
            
            #line 49 "..\..\..\Pages\Actions.xaml"
            this.TypeFilt.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TypeFilt_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.StatusFilt = ((System.Windows.Controls.ComboBox)(target));
            
            #line 50 "..\..\..\Pages\Actions.xaml"
            this.StatusFilt.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.StatusFilt_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.DistrictFilt = ((System.Windows.Controls.ComboBox)(target));
            
            #line 51 "..\..\..\Pages\Actions.xaml"
            this.DistrictFilt.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DistrictFilt_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.isOwned = ((System.Windows.Controls.CheckBox)(target));
            
            #line 56 "..\..\..\Pages\Actions.xaml"
            this.isOwned.Checked += new System.Windows.RoutedEventHandler(this.isOwned_Checked);
            
            #line default
            #line hidden
            
            #line 56 "..\..\..\Pages\Actions.xaml"
            this.isOwned.Unchecked += new System.Windows.RoutedEventHandler(this.isOwned_Checked);
            
            #line default
            #line hidden
            return;
            case 13:
            this.ActionList = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 14:
            
            #line 93 "..\..\..\Pages\Actions.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.buttonView_Click);
            
            #line default
            #line hidden
            break;
            case 15:
            
            #line 94 "..\..\..\Pages\Actions.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.buttonEdit_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

