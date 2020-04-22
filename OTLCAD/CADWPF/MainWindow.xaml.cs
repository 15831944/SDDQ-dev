using CADWPF.CADWPF;
using Infrastructure;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
namespace CADWPF
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        public MainWindow()
        {
            InitializeComponent();               

        }
    
        public WorkEnvironment WindowTitle { get; set; } = WorkEnvironment.Instance;

        private void ConductorBase_Click(object sender, RoutedEventArgs e)
        {
            ConductorBase w1 = new ConductorBase();  //实例化ConductorBase窗体w1
            w1.Show();
        }

        private void SurveyInput_Click(object sender, RoutedEventArgs e)
        {
         var surveyInput = new SurveyInput();
            surveyInput.Owner = this;
            surveyInput.ShowDialog();
        }
    }



}
