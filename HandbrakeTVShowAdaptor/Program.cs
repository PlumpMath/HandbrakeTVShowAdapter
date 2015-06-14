using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using HandBrake.Interop;
using HandBrake.Interop.SourceData;

namespace HandbrakeTVShowAdaptor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            var scanningInstance = new HandBrakeInstance();
            scanningInstance.Initialize(1);

            Application.Run(new Form1(scanningInstance));
        }

        public delegate void InvokeDelegate();

        
    }
}
