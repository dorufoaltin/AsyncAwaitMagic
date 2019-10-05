using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace DeadLock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly object _firstLock = new object();
        readonly object _secondLock = new object();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(ChickenThread);
            Task.Factory.StartNew(EggThread);
        }

        void ChickenThread()
        {
            Thread.CurrentThread.Name = "Chicken Thread";

            lock (_firstLock) 
            {
                Thread.Sleep(1000);
                lock (_secondLock)
                {
                }
            }
        }

        private void EggThread()
        {
            Thread.CurrentThread.Name = "Egg Thread";

            Thread.Sleep(500); // Egg Thread is Lazy

            lock (_secondLock)
            {
                lock (_firstLock)
                {
                }
            }
        }
    }
}
