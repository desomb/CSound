using csound6netlib;
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

namespace CsoundProject.Views
{
    /// <summary>
    /// Logique d'interaction pour CSoundCreationPage.xaml
    /// </summary>
    public partial class CSoundCreationPage : Page
    {
        public CSoundCreationPage()
        {
            InitializeComponent();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var c = new Csound6Net())
            {
                //Using SetOption() to configure Csound: here to output in realtime

                c.CompileOrc(orc);       // Compile the Csound Orchestra string
                c.ReadScore("i1 0 1\n");   // Compile the Csound score as a string constant

                c.Start();  // When compiling from strings, Start() is needed before performing
                c.Perform();// Run Csound to completion
                c.Stop();   // At this point, Csound is already stopped, but this call is here
            }
        }
    }
}
