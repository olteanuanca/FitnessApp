﻿#pragma checksum "..\..\FriendsMenuWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D47865FBDB7B00680EFE005C809C657F9DB7BCA7"
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
    /// FriendsMenuWindow
    /// </summary>
    public partial class FriendsMenuWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\FriendsMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Friends;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\FriendsMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FriendList;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\FriendsMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddFriend_button;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\FriendsMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Messages_button;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\FriendsMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FriendReq_button;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\FriendsMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Message_TB;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\FriendsMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Send_button;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\FriendsMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ToUsername_TB;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\FriendsMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Food;
        
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
            System.Uri resourceLocater = new System.Uri("/FitnessApplication;component/friendsmenuwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\FriendsMenuWindow.xaml"
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
            this.Friends = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\FriendsMenuWindow.xaml"
            this.Friends.Click += new System.Windows.RoutedEventHandler(this.Friends_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.FriendList = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\FriendsMenuWindow.xaml"
            this.FriendList.Click += new System.Windows.RoutedEventHandler(this.FriendList_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.AddFriend_button = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\FriendsMenuWindow.xaml"
            this.AddFriend_button.Click += new System.Windows.RoutedEventHandler(this.AddFriend_button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Messages_button = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\FriendsMenuWindow.xaml"
            this.Messages_button.Click += new System.Windows.RoutedEventHandler(this.Messages_button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.FriendReq_button = ((System.Windows.Controls.Button)(target));
            
            #line 93 "..\..\FriendsMenuWindow.xaml"
            this.FriendReq_button.Click += new System.Windows.RoutedEventHandler(this.FriendReq_button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Message_TB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Send_button = ((System.Windows.Controls.Button)(target));
            
            #line 115 "..\..\FriendsMenuWindow.xaml"
            this.Send_button.Click += new System.Windows.RoutedEventHandler(this.Send_button_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ToUsername_TB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.Food = ((System.Windows.Controls.Button)(target));
            
            #line 120 "..\..\FriendsMenuWindow.xaml"
            this.Food.Click += new System.Windows.RoutedEventHandler(this.Food_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

