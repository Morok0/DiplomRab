﻿#pragma checksum "..\..\DoctorReception.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5A2ED1A0BC3A76EB3FACAFFB2CE26505F101710996E19C419279B627C3D7B3B9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using ДипломнаяРабота;


namespace ДипломнаяРабота {
    
    
    /// <summary>
    /// DoctorReception
    /// </summary>
    public partial class DoctorReception : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\DoctorReception.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid TableReception;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\DoctorReception.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid1;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\DoctorReception.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox началоПриёмаTextBox;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\DoctorReception.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox конецПриёмаTextBox;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\DoctorReception.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox диагнозTextBox;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\DoctorReception.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox лечениеTextBox;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\DoctorReception.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid TablePatient;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\DoctorReception.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid2;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\DoctorReception.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox услугаИлиПроцедураTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/ДипломнаяРабота;component/doctorreception.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DoctorReception.xaml"
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
            this.TableReception = ((System.Windows.Controls.DataGrid)(target));
            
            #line 16 "..\..\DoctorReception.xaml"
            this.TableReception.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 17 "..\..\DoctorReception.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Add);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 24 "..\..\DoctorReception.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Delete);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 31 "..\..\DoctorReception.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Update);
            
            #line default
            #line hidden
            return;
            case 5:
            this.grid1 = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.началоПриёмаTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.конецПриёмаTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.диагнозTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.лечениеTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.TablePatient = ((System.Windows.Controls.DataGrid)(target));
            
            #line 62 "..\..\DoctorReception.xaml"
            this.TablePatient.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 63 "..\..\DoctorReception.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Patient);
            
            #line default
            #line hidden
            return;
            case 12:
            this.grid2 = ((System.Windows.Controls.Grid)(target));
            return;
            case 13:
            this.услугаИлиПроцедураTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

