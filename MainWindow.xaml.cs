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

        void ThreadJob()
        {
            Console.WriteLine("\t\t\t\tLocking firstLock");
            lock (_firstLock)
            {
                Console.WriteLine("\t\t\t\tLocked firstLock");
                // Wait until we're fairly sure the first thread
                // has grabbed secondLock
                Thread.Sleep(1000);
                Console.WriteLine("\t\t\t\tLocking secondLock");
                lock (_secondLock)
                {
                    Console.WriteLine("\t\t\t\tLocked secondLock");
                }
                Console.WriteLine("\t\t\t\tReleased secondLock");
            }
            Console.WriteLine("\t\t\t\tReleased firstLock");
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(ThreadJob);

            // Wait until we're fairly sure the other thread
            // has grabbed firstLock
            Thread.Sleep(500);
            Console.WriteLine("Locking secondLock");
            lock (_secondLock)
            {
                Console.WriteLine("Locked secondLock");
                Console.WriteLine("Locking firstLock");
                lock (_firstLock)
                {
                    Console.WriteLine("Locked firstLock");
                }
                Console.WriteLine("Released firstLock");
            }
            Console.WriteLine("Released secondLock");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(AddNewNumber);

            int sum = 0;

            foreach (var item in _allValues)
            {
                sum += item;

                Thread.Sleep(1);
            }
        }

        private void AddNewNumber()
        {
            Thread.Sleep(100);
            _allValues.Add(2);
        }
    }
}
