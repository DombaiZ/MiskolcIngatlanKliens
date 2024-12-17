using MiskolcIngatlanKliens.SubWindows;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiskolcIngatlanKliens
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

        private void IngatlanokAblakNyit(object sender, RoutedEventArgs e)
        {
            IngatlanokWindow ingatlanokWindow = new IngatlanokWindow();
            ingatlanokWindow.ShowDialog();
        }

        private void UgyintezokAblakNyit(object sender, RoutedEventArgs e)
        {

        }
    }
}