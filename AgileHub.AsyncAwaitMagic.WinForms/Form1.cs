using AgileHub.AsyncAwaitMagic.Standard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgileHub.AsyncAwaitMagic.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DemoService service = new DemoService();

            var saveResult = service.SaveNewDemoTextSyncHack("someValue");

            if (saveResult)
                return;

            MessageBox.Show($"Reached the end with result: {saveResult}!");
        }
















        private void button2_Click(object sender, EventArgs e)
        {
            bool saveResult = false;

            var task = Task.Factory.StartNew(() =>
            {
                DemoService service = new DemoService();

                saveResult = service.SaveNewDemoTextSyncHack("someValue");

                if (saveResult)
                    return;
            });

            task.Wait();

            MessageBox.Show($"Reached the end with result: {saveResult}!");
        }
    }
}
