﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProNatur_Biomarkt_GmbH
{
    public partial class LoadingScreen : Form
    {
        private int loadingBarValue;

        public LoadingScreen()
        {
            InitializeComponent();
        }
        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            loadingBarTimer.Start();

        }
        private void loadingBarTimer_Tick(object sender, EventArgs e)
        {

            loadingBarValue += 1;
            lblLoadingProgress.Text  =  loadingBarValue.ToString() + "%";  
            loadingProgressbar.Value = loadingBarValue;
            if (loadingBarValue >= loadingProgressbar.Maximum)
            {
                loadingBarTimer.Stop();
                // Finish loading the show main menu screen

                MainMenuScreen mainMenuScreen = new MainMenuScreen();
                mainMenuScreen.Show();
                this.Hide();

            }

        }

    }
}
