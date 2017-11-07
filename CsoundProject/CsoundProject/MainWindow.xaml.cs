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
        public Button btn = new Button();


        public MainWindow()
        {
            InitializeComponent();
            Example1();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            // do something
            Example1();

            //btn.Background = Brushes.Blue;
        }

        //Debug.WriteLine("test");

        public void Example1()
        {
            Debug.WriteLine("test");
            /*   using (var c = new Csound6Net())
               {
                   c.Compile(new string[] { "csoundqdt-temp.csd" });  // Compile a pre-defined test1.csd file, includes Start()
                  // c.Perform();        // This call runs Csound to completion (saving Stop() for next example)
               }*/

            using (var c = new Csound6Net())
            {
                // Using SetOption() to configure Csound: here to output in realtime

                c.CompileOrc(orc);       // Compile the Csound Orchestra string
                c.ReadScore("i1 0 1\n");   // Compile the Csound score as a string constant

                c.Start();  // When compiling from strings, Start() is needed before performing
                c.Perform();// Run Csound to completion
                c.Stop();   // At this point, Csound is already stopped, but this call is here
            }               // as it is something that you would generally call in real-world 

        }

        const string orc = @"
sr=44100
ksmps=32
nchnls=2
0dbfs=1
instr 1 
aout vco2 0.5, 440
outs aout, aout
endin";
    }
}
