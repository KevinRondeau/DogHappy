﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace DogFetchApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// Athor: Kevin Rondeau
    public partial class App : Application
    {
        public App()
        {
            {
                var lang = DogFetchApp.Properties.Settings.Default.Language;
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            }
        }
    }
}
