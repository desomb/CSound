using csound6netlib;
using System.Windows.Controls;

namespace CsoundProject.Views
{
    /// <summary>
    /// Logique d'interaction pour PianoPage.xaml
    /// </summary>
    public partial class PianoPage : Page
    {
        const string orc1 = @"
sr=44100
ksmps=32
nchnls=2
0dbfs=1
instr 1 
aout vco2 0.5, 440
outs aout, aout
endin";
        const string orc2 = @"
sr=44100
ksmps=32
nchnls=2
0dbfs=1
instr 1 
aout vco2 10.5, 440
outs aout, aout
endin";
        const string orc3 = @"
sr=44100
ksmps=32
nchnls=2
0dbfs=1
instr 1 
aout vco2 20.5, 440
outs aout, aout
endin";
        const string orc4 = @"
sr=44100
ksmps=32
nchnls=2
0dbfs=1
instr 1 
aout vco2 30.5, 440
outs aout, aout
endin";
        const string orc5 = @"
sr=44100
ksmps=32
nchnls=2
0dbfs=1
instr 1 
aout vco2 40.5, 440
outs aout, aout
endin";
        const string orc6 = @"
sr=44100
ksmps=32
nchnls=2
0dbfs=1
instr 1 
aout vco2 50.5, 440
outs aout, aout
endin";
        const string orc7 = @"
sr=44100
ksmps=32
nchnls=2
0dbfs=1
instr 1 
aout vco2 60.5, 440
outs aout, aout
endin";
        const string orc8 = @"
sr=44100
ksmps=32
nchnls=2
0dbfs=1
instr 1 
aout vco2 70.5, 440
outs aout, aout
endin";

        public PianoPage()
        {
            this.InitializeComponent();
            using (var c = new Csound6Net())
            {
                string orc = null;
                for (int i = 0; i < 8; i++)
                {
                    if (i == 0)
                    {
                        orc = orc1;
                    }
                    if (i == 1)
                    {
                        orc = orc2;
                    }
                    if (i == 2)
                    {
                        orc = orc3;
                    }
                    if (i == 3)
                    {
                        orc = orc4;
                    }
                    if (i == 4)
                    {
                        orc = orc5;
                    }
                    if (i == 5)
                    {
                        orc = orc6;
                    }
                    if (i == 6)
                    {
                        orc = orc7;
                    }
                    if (i == 7)
                    {
                        orc = orc8;
                    }
                    c.CompileOrc(orc);       // Compile the Csound Orchestra string
                    c.ReadScore("i1 0 0.5\n");   // Compile the Csound score as a string constant

                    c.Start();  // When compiling from strings, Start() is needed before performing
                    c.Perform();// Run Csound to completion
                    c.Stop();   // At this point, Csound is already stopped, but this call is here
                    i++;
                }
            }
        }

    }
}
