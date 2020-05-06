using JFLAP_MyApproach.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JFLAP_MyCopy
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

        private void btn_FiniteAutomatonMainForm_Click(object sender, RoutedEventArgs e)
        {
            FiniteAutomatonForm finiteAutomatonForm = new FiniteAutomatonForm();
            this.Visibility = Visibility.Hidden;
            finiteAutomatonForm.Show();
        }

        private void btn_RegExForm_Click(object sender, RoutedEventArgs e)
        {
            RegExForm regExForm = new RegExForm();
            this.Visibility = Visibility.Hidden;
            regExForm.Show();
        }
    }
}
