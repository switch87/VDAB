﻿#pragma checksum "..\..\DataBindingWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E221EB0721584055C6FBD3CA2ACDC53D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace DataBinding {
    
    
    /// <summary>
    /// DataBindingWindow
    /// </summary>
    public partial class DataBindingWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\DataBindingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox grootteTextBox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\DataBindingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider grootteSlider;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\DataBindingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lettertypeComboBox;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\DataBindingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel veranderPanel;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\DataBindingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox veranderTextBox;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\DataBindingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button veranderButton;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\DataBindingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button toonNaamButton;
        
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
            System.Uri resourceLocater = new System.Uri("/DataBinding;component/databindingwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DataBindingWindow.xaml"
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
            this.grootteTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.grootteSlider = ((System.Windows.Controls.Slider)(target));
            return;
            case 3:
            this.lettertypeComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.veranderPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.veranderTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.veranderButton = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\DataBindingWindow.xaml"
            this.veranderButton.Click += new System.Windows.RoutedEventHandler(this.veranderButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.toonNaamButton = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\DataBindingWindow.xaml"
            this.toonNaamButton.Click += new System.Windows.RoutedEventHandler(this.toonNaamButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

