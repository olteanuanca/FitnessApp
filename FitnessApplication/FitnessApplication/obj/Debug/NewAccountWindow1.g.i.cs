﻿#pragma checksum "..\..\NewAccountWindow1.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E5C14692E759522746D7DF346B5438CD0CEBDBAC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FitnessApplication;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace FitnessApplication {
    
    
    /// <summary>
    /// NewAccountWindow1
    /// </summary>
    public partial class NewAccountWindow1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\NewAccountWindow1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EmailAdress_textbox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\NewAccountWindow1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Continue_button;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\NewAccountWindow1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Password_textbox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\NewAccountWindow1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FirstName_textbox;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\NewAccountWindow1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LastName_textbox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\NewAccountWindow1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Username_textbox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\NewAccountWindow1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ProfilePic;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\NewAccountWindow1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Browse_button;
        
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
            System.Uri resourceLocater = new System.Uri("/FitnessApplication;component/newaccountwindow1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NewAccountWindow1.xaml"
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
            this.EmailAdress_textbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Continue_button = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\NewAccountWindow1.xaml"
            this.Continue_button.Click += new System.Windows.RoutedEventHandler(this.Continue_button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Password_textbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.FirstName_textbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.LastName_textbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Username_textbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.ProfilePic = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.Browse_button = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\NewAccountWindow1.xaml"
            this.Browse_button.Click += new System.Windows.RoutedEventHandler(this.Browse_button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

