﻿#pragma checksum "..\..\OpleidingenWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6BBB8C6CBB8EE31F3B50A10FF5AA11BE"
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


namespace Taak3 {
    
    
    /// <summary>
    /// OpleidingenWindow
    /// </summary>
    public partial class OpleidingenWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\OpleidingenWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxProgrammas;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\OpleidingenWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonDoorgeven;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\OpleidingenWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock GekendTextBlock;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\OpleidingenWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxGekend;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\OpleidingenWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxTeVolgen;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\OpleidingenWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TeVolgendTextBlock;
        
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
            System.Uri resourceLocater = new System.Uri("/OpleidingenDragDrop;component/opleidingenwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\OpleidingenWindow.xaml"
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
            this.ListBoxProgrammas = ((System.Windows.Controls.ListBox)(target));
            
            #line 7 "..\..\OpleidingenWindow.xaml"
            this.ListBoxProgrammas.MouseMove += new System.Windows.Input.MouseEventHandler(this.DragListBox_MouseMove);
            
            #line default
            #line hidden
            
            #line 8 "..\..\OpleidingenWindow.xaml"
            this.ListBoxProgrammas.Drop += new System.Windows.DragEventHandler(this.DropListBox_Drop);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ButtonDoorgeven = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\OpleidingenWindow.xaml"
            this.ButtonDoorgeven.Click += new System.Windows.RoutedEventHandler(this.ButtonDoorgeven_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.GekendTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.ListBoxGekend = ((System.Windows.Controls.ListBox)(target));
            
            #line 29 "..\..\OpleidingenWindow.xaml"
            this.ListBoxGekend.MouseMove += new System.Windows.Input.MouseEventHandler(this.DragListBox_MouseMove);
            
            #line default
            #line hidden
            
            #line 30 "..\..\OpleidingenWindow.xaml"
            this.ListBoxGekend.Drop += new System.Windows.DragEventHandler(this.DropListBox_Drop);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ListBoxTeVolgen = ((System.Windows.Controls.ListBox)(target));
            
            #line 42 "..\..\OpleidingenWindow.xaml"
            this.ListBoxTeVolgen.MouseMove += new System.Windows.Input.MouseEventHandler(this.DragListBox_MouseMove);
            
            #line default
            #line hidden
            
            #line 43 "..\..\OpleidingenWindow.xaml"
            this.ListBoxTeVolgen.Drop += new System.Windows.DragEventHandler(this.DropListBox_Drop);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TeVolgendTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

