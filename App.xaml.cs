﻿namespace DemyAI {
    public partial class App : Application {
        public App(LoginPage loginPage) {
            InitializeComponent();

            MainPage = loginPage;
        }
    }
}
