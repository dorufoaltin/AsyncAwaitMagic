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

        readonly List<int> _allValues = Enumerable.Range(0, 9000000).ToList();

       

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
            Thread.Sleep(500);
            lock (_secondLock)
            {
                lock (_firstLock)
                {
                }
            }
        }

        void Button_Click_1(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                Task.Factory.StartNew(CodeWithLocks);
            }
        }

        Object _lockObject = new object();

        void CodeWithLocks()
        {
            lock (_lockObject)
            {
                // This code can be executed by a single Thread at a time
            }
        }

        private void AddNewNumber()
        {
            Thread.Sleep(100);
            _allValues.Add(2);
        }
    }
}
