﻿#pragma checksum "..\..\GridDef.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5AA2C29997B4A49F942A687C1B4768DA4A99386F733DC6731E660587DA3E655D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
using WPFGOL3;


namespace WPFGOL3 {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 2 "..\..\GridDef.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WPFGOL3.MainWindow Main_Window;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\GridDef.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridMain;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\GridDef.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button generator;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\GridDef.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Reset;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\GridDef.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button autoGenerator;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\GridDef.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button savingPrivateParts;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\GridDef.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button loadingButton;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\GridDef.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exitButton;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\GridDef.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Generations;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\GridDef.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label AliveCells;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\GridDef.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Speed;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\GridDef.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox speedBox;
        
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
            System.Uri resourceLocater = new System.Uri("/WPFGOL3;component/griddef.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\GridDef.xaml"
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
            this.Main_Window = ((WPFGOL3.MainWindow)(target));
            return;
            case 2:
            this.gridMain = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.generator = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\GridDef.xaml"
            this.generator.Click += new System.Windows.RoutedEventHandler(this.generate);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Reset = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\GridDef.xaml"
            this.Reset.Click += new System.Windows.RoutedEventHandler(this.reset);
            
            #line default
            #line hidden
            return;
            case 5:
            this.autoGenerator = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\GridDef.xaml"
            this.autoGenerator.Click += new System.Windows.RoutedEventHandler(this.auto);
            
            #line default
            #line hidden
            return;
            case 6:
            this.savingPrivateParts = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\GridDef.xaml"
            this.savingPrivateParts.Click += new System.Windows.RoutedEventHandler(this.save);
            
            #line default
            #line hidden
            return;
            case 7:
            this.loadingButton = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\GridDef.xaml"
            this.loadingButton.Click += new System.Windows.RoutedEventHandler(this.load);
            
            #line default
            #line hidden
            return;
            case 8:
            this.exitButton = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\GridDef.xaml"
            this.exitButton.Click += new System.Windows.RoutedEventHandler(this.closeWindow);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Generations = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.AliveCells = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.Speed = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.speedBox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

