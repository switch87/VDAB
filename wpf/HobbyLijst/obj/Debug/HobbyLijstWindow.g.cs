﻿#pragma checksum "..\..\HobbyLijstWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6A0146FA963F8957A18020D1FAF22165"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
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


namespace HobbyLijst {
    
    
    /// <summary>
    /// HobbyLijstWindow
    /// </summary>
    public partial class HobbyLijstWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\HobbyLijstWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxCategorie;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\HobbyLijstWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxHobbies;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\HobbyLijstWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonKies;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\HobbyLijstWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxGekozen;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\HobbyLijstWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonVerwijderen;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\HobbyLijstWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonSamenvatting;
        
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
            System.Uri resourceLocater = new System.Uri("/HobbyLijst;component/hobbylijstwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\HobbyLijstWindow.xaml"
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
            
            #line 4 "..\..\HobbyLijstWindow.xaml"
            ((HobbyLijst.HobbyLijstWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ComboBoxCategorie = ((System.Windows.Controls.ComboBox)(target));
            
            #line 8 "..\..\HobbyLijstWindow.xaml"
            this.ComboBoxCategorie.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBoxCategorie_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ListBoxHobbies = ((System.Windows.Controls.ListBox)(target));
            return;
            case 4:
            this.ButtonKies = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\HobbyLijstWindow.xaml"
            this.ButtonKies.Click += new System.Windows.RoutedEventHandler(this.ButtonKies_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ListBoxGekozen = ((System.Windows.Controls.ListBox)(target));
            return;
            case 6:
            this.ButtonVerwijderen = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\HobbyLijstWindow.xaml"
            this.ButtonVerwijderen.Click += new System.Windows.RoutedEventHandler(this.ButtonVerwijderen_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ButtonSamenvatting = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\HobbyLijstWindow.xaml"
            this.ButtonSamenvatting.Click += new System.Windows.RoutedEventHandler(this.ButtonSamenvatting_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
