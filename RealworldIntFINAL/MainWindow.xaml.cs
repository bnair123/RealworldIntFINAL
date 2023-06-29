using RealworldIntFINAL;
using System;
using System.Collections.Generic;
using System.Windows;

namespace non
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public List<User> RegisteredUsers { get; set; } = new(); // List to store registered users

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string enteredUsername = UsernameBox.Password;
            string enteredPassword = PasswordBox.Password;

            // Use UserClass to authenticate the user
            UserClass userClass = new UserClass();
            bool isAuthenticated = userClass.AuthenticateUser(enteredUsername, enteredPassword);

            if (isAuthenticated)
            {
                // Successful login
                UsernameBox.Clear();
                PasswordBox.Clear();

                MessageBox.Show("Login successful!\nClosing Login Screen", "Good boy", MessageBoxButton.OK, MessageBoxImage.Information);

                StocksView stocksView = new StocksView();
                stocksView.Show();
                this.Close();
            }
            else
            {
                // Failed login
                UsernameBox.Clear();
                PasswordBox.Clear();
                MessageBox.Show("Invalid username or password.", "Bad boy", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the entered username and password
            string enteredUsername = UsernameBox.Password;
            string enteredPassword = PasswordBox.Password;

            // Use UserClass to register the user
            UserClass userClass = new UserClass();
            bool isRegistered = userClass.RegisterUser(enteredUsername, enteredPassword);

            if (isRegistered)
            {
                // Successful registration
                MessageBox.Show("Registration successful!", "Good boy", MessageBoxButton.OK, MessageBoxImage.Information);

                // Clear the username and password fields after registration
                UsernameBox.Clear();
                PasswordBox.Clear();
            }
            else
            {
                // Failed registration
                MessageBox.Show("Registration failed. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }

    // Example User class
    public class User
    {
        public User()
        {
            this.Username = Username;
            this.Password = Password;
        }

        public User(List<Stock> stocks)
        {
            this.Username = Username;
            this.Password = Password;
            this.Stocks = stocks;
        }

        public List<Stock> Stocks { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class Stock
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"{Name} {Price}";
        }

        public Stock(string Name, double Price)
        {
            this.Name = Name;
            this.Price = Price;
        }
    }

}
