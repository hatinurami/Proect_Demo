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

namespace Proect_Demo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static public int sw_roll = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        enum Roll
        {
            Zavuch = 1,
            Uchitel,
            Admin
        }

        private void login_stud_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(sender, e);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (log_tectbox.Text.Length > 0 && password_textbox.Password.Length > 0)
                {
                    demo_bdEntities bd_stud = new demo_bdEntities();
                    var av = bd_stud.logins;
                    Administrator adm = new Administrator();
                    Student stud = new Student();
                    Zavuch zavuch = new Zavuch();
                    var result = av.Where(i => i.login == log_tectbox.Text && i.password == password_textbox.Password);
                    if (result.Count() == 1)
                    {
                        this.Hide();
                        sw_roll = (int)result.FirstOrDefault().rool;
                        switch (sw_roll)
                        {
                            case (byte)Roll.Zavuch:
                                zavuch.ShowDialog();
                                break;
                            case (byte)Roll.Uchitel:
                                stud.ShowDialog();
                                break;
                            case (byte)Roll.Admin:
                                adm.ShowDialog();
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Не найдено данной комбинации\nЛогин - {0}\nПароль - {1}", log_tectbox.Text, password_textbox.Password),
                            "Предупреждение!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("Поля Логин и Пароль - обязательны к заполнению!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            catch (Exception msg)
            {

                MessageBox.Show(msg.Message);
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }

       
    }
}
