using Microsoft.EntityFrameworkCore;
using StationDesktop.Windows;
using System;
using System.Windows;

namespace StationDesktop
{
    public partial class AuthorizationWindow : Window
    {
        #region Объявление переменных
        StationContext context;
        #endregion
        public AuthorizationWindow()
        {
            InitializeComponent();
            LoginTextBox.Focus();
            context = new StationContext();
        }

        #region Обработчики событий
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            CheckLoginPassword();
        }

        private void LoginTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = "0123456789AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz_".IndexOf(e.Text) < 0;
        }

        private void PasswordTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = "0123456789AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz_*.,".IndexOf(e.Text) < 0;
        }
        #endregion


        // <summary>
        // Проверка логина и пароля 
        // </summary>
        private async void CheckLoginPassword()
        {
            try
            {
                LoginButton.IsEnabled = false;
                var user = await context.Users.FirstOrDefaultAsync(u => u.Login == LoginTextBox.Text && u.Password == PasswordTextBox.Password);
                if (user != null)
                {
                    Station station = new Station(user);
                    station.Show();
                    this.Close();
                }
                else
                {
                    LoginButton.IsEnabled = true;
                    MessageBox.Show("Неверный логин или пароль", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch(Exception ex)
            {

            }
        }


    }
}
