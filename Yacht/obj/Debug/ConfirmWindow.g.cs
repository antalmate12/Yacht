﻿#pragma checksum "..\..\ConfirmWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "57419943529C4C8088DC8CAAA805090917306A55"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Yacht {
    
    
    /// <summary>
    /// ConfirmWindow
    /// </summary>
    public partial class ConfirmWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 45 "..\..\ConfirmWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbKolcsNev;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\ConfirmWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbKolcsAbout;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\ConfirmWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbHajoNev;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\ConfirmWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DpMettol;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\ConfirmWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DpMeddig;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\ConfirmWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbHonnan;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\ConfirmWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbHova;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\ConfirmWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonConfirm;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\ConfirmWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonCancel;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\ConfirmWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxKolcs;
        
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
            System.Uri resourceLocater = new System.Uri("/Yacht;component/confirmwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ConfirmWindow.xaml"
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
            
            #line 10 "..\..\ConfirmWindow.xaml"
            ((System.Windows.Controls.Grid)(target)).Loaded += new System.Windows.RoutedEventHandler(this.GridLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TbKolcsNev = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TbKolcsAbout = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TbHajoNev = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.DpMettol = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.DpMeddig = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.TbHonnan = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.TbHova = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.ButtonConfirm = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\ConfirmWindow.xaml"
            this.ButtonConfirm.Click += new System.Windows.RoutedEventHandler(this.ButtonConfirm_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ButtonCancel = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\ConfirmWindow.xaml"
            this.ButtonCancel.Click += new System.Windows.RoutedEventHandler(this.ButtonCancel_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.ListBoxKolcs = ((System.Windows.Controls.ListBox)(target));
            
            #line 61 "..\..\ConfirmWindow.xaml"
            this.ListBoxKolcs.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBoxKolcs_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
