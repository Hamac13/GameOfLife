﻿#pragma checksum "..\..\GridDef.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9A900090E0FB0A4556F3525B2A2C54EB57CE39147CBF1C440F42DA18C51B1511"
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
    /// GridDef
    /// </summary>
    public partial class GridDef : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\GridDef.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider GridSet;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\GridDef.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label RowsCount;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\GridDef.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label GridSize;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\GridDef.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox GridColourSet;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\GridDef.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem Default;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\GridDef.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem Inverted;
        
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
            
            #line 24 "..\..\GridDef.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CloseWindow);
            
            #line default
            #line hidden
            return;
            case 2:
            this.GridSet = ((System.Windows.Controls.Slider)(target));
            
            #line 25 "..\..\GridDef.xaml"
            this.GridSet.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.GridSlider_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.RowsCount = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.GridSize = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.GridColourSet = ((System.Windows.Controls.ComboBox)(target));
            
            #line 40 "..\..\GridDef.xaml"
            this.GridColourSet.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.GridColourSet_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Default = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 7:
            this.Inverted = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

