﻿#pragma checksum "..\..\ButtonWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "203BDE5AE556001AC44587AC1F657A9D"
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


namespace WpfCursus {
    
    
    /// <summary>
    /// ButtonWindow
    /// </summary>
    public partial class ButtonWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\ButtonWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridje;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\ButtonWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonRed;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\ButtonWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonGreen;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\ButtonWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonBlue;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfCursus;component/buttonwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ButtonWindow.xaml"
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
            this.gridje = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.ButtonRed = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\ButtonWindow.xaml"
            this.ButtonRed.Click += new System.Windows.RoutedEventHandler(this.ButtonKleur_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ButtonGreen = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\ButtonWindow.xaml"
            this.ButtonGreen.Click += new System.Windows.RoutedEventHandler(this.ButtonKleur_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ButtonBlue = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\ButtonWindow.xaml"
            this.ButtonBlue.Click += new System.Windows.RoutedEventHandler(this.ButtonKleur_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

