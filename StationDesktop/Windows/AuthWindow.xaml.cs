using Microsoft.EntityFrameworkCore;
using StationDesktop.Services;
using System;
using System.Windows;

namespace StationDesktop.Windows
{
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
            BootService.AuthWindow = this;
            ContextService.StationContext = new StationContext();
            LoginTextBox.Focus();
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
        public async void CheckLoginPassword()
        {
            try
            {
                LoginButton.IsEnabled = false;
                var user = await ContextService.StationContext.Users.FirstOrDefaultAsync(u => u.Login == LoginTextBox.Text && u.Password == PasswordTextBox.Password);
                if (user != null)
                {
                    UserService.User = user;
                    BootService.StationWindow = new StationWindow();
                    BootService.StationWindow.Show();
                    this.Close();
                }
                else
                {
                    LoginButton.IsEnabled = true;
                    MessageBox.Show("Неверный логин или пароль", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {

            }
        }


    }
}
