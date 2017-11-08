using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using csound6netlib;
using System.Diagnostics;

namespace CsoundProject
{
    class MainClass : ObservableBase
    {

        #region Constructeur
        public MainClass()
        {
            this.ChampsRecherche = "Toto";
        }
        #endregion

        #region Propriété ChampsRecherche

        /// <summary>
        /// Propriété sotckant le champs de la recherche
        /// </summary>
        public string ChampsRecherche
        {
            get { return _ChampsRecherche; }
            set
            {
                if (_ChampsRecherche != value)
                {
                    _ChampsRecherche = value;
                    this.OnPropertyChanged(_ChampsRechercheChangedEventArgs);
                }
            }
        }

        private string _ChampsRecherche;
        private static readonly PropertyChangedEventArgs _ChampsRechercheChangedEventArgs = new PropertyChangedEventArgs("ChampsRecherche");

        #endregion

        const string orc = @"
sr=44100
ksmps=32
nchnls=2
0dbfs=1
instr 1 
aout vco2 0.5, 440
outs aout, aout
endin";
        const string exe = "i1 0 1\n";


        #region Commande Browse

        /// <summary>
        /// Commande de Recherche
        /// </summary>
        public void Browse()
        {
            using (var c = new Csound6Net())
            {
                //Using SetOption() to configure Csound: here to output in realtime

                c.CompileOrc(orc);       // Compile the Csound Orchestra string
                c.ReadScore("i1 0 1\n");   // Compile the Csound score as a string constant

                c.Start();  // When compiling from strings, Start() is needed before performing
                c.Perform();// Run Csound to completion
                c.Stop();   // At this point, Csound is already stopped, but this call is here
            }               // as it is something that you would generally call in real-world 

        }

        /// <summary>
        /// Définit si la commande "Executer" peut être exécutée.
        /// </summary>
        protected virtual bool CanBrowse()
        {
            if (string.IsNullOrEmpty(this.ChampsRecherche))
            {
               return false;
            }
            return true;
        }

        /// <summary>
        /// Commande "Executer".
        /// </summary>
        public ICommand BrowseCommand
        {
            get
            {
                return _BrowseCommand ?? (_BrowseCommand = new RelayCommand(
                    this.Browse,
                    this.CanBrowse));
            }
        }

        private ICommand _BrowseCommand;

        #endregion

        #region Commande CreateWav

        /// <summary>
        /// TODO: documentation de la commande "Executer".
        /// </summary>
        public void CreateWav()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                this.ChampsRecherche = filename;
            }
        }

        /// <summary>
        /// Définit si la commande "Executer" peut être exécutée.
        /// </summary>
        protected virtual bool CanCreateWav()
        {
            return true;
        }

        /// <summary>
        /// Commande "Executer".
        /// </summary>
        public ICommand AjouterCommand
        {
            get
            {
                return _CreateWavCommand ?? (_CreateWavCommand = new RelayCommand(
                    this.CreateWav,
                    this.CanCreateWav));
            }
        }

        private ICommand _CreateWavCommand;

        #endregion

    }
}
