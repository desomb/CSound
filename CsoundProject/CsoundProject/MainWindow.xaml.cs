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

using csound6netlib;
using System.Diagnostics;

namespace CsoundProject
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
        public void Example1()
        {
            // Create an instance of the Csound object within a using block
            using (var c = new Csound6Net())
            {
                c.Compile(new string[] { "csoundqt-temp.csd" });  // Compile a pre-defined test1.csd file, includes Start()
                c.Perform();        // This call runs Csound to completion (saving Stop() for next example)
            }
            //c.Dispose() shuts csound down properly. It is called automatically as a "using" block exits.
        }
    }
}
