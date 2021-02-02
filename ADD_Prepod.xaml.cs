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
using System.Windows.Shapes;

namespace Proect_Demo
{
    /// <summary>
    /// Логика взаимодействия для ADD_Prepod.xaml
    /// </summary>
    public partial class ADD_Prepod : Window
    {
        public demo_bdEntities bd_stud = new demo_bdEntities();
        public ADD_Prepod()
        {
            InitializeComponent();
        }
        private void load_class(object sender, RoutedEventArgs e)
        {
            var class_A = bd_stud.class_tab;
            group.ItemsSource = class_A.ToList();
        }
        private void load_class1(object sender, RoutedEventArgs e)
        {
            var class_B = bd_stud.pol_tab;
            pol.ItemsSource = class_B.ToList();
        }
        private void add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (fname_add.Text == "Введите отчество" || name_add.Text == "Введите имя" || fam_add.Text == "Введите фамилию" || log_add.Text == "Введите логин" || pass_add.Text == "Введите пароль" || group.SelectedIndex == -1 || pol.SelectedIndex == -1 || date.SelectedDate == null)
                {
                    MessageBox.Show("Вы указали не все данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {

                    if (group.SelectedIndex == -1)
                    {
                        group.SelectedIndex = 5;
                    }

                    bd_stud.logins.Add(new logins
                    {
                        login = log_add.Text,
                        password = pass_add.Text,
                        rool = 2,
                        id_user = 1

                    });

                    bd_stud.prepod.Add(new prepod
                    {
                        fname = fam_add.Text,
                        fatherName = fname_add.Text,
                        sname = name_add.Text,
                        id_pol = pol.SelectedIndex + 1,

                        id_class = group.SelectedIndex + 1,
                    });
                    bd_stud.SaveChanges();
                    
                    MessageBox.Show("Данные успешно сохранены");
                    clear_Click(sender, e);
                }
        }
            catch (Exception)
            {
                MessageBox.Show("Проверьте введённые данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
}
        ////private void RefreshDG()
        ////{

        ////    DB0.Clear();

        ////    var contractcollection = DB.Contracts.Include("Partner").Include("Respemp").Include("CurrencyOFContract");
        ////    foreach (var item in contractcollection)
        ////    {
        ////        DB0.Add(item);
        ////    }

        ////}

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            fname_add.Text = "Введите отчество";
            fname_add.Foreground = Brushes.LightGray;
            name_add.Text = "Введите имя";
            name_add.Foreground = Brushes.LightGray;
            fam_add.Text = "Введите фамилию";
            fam_add.Foreground = Brushes.LightGray;
            log_add.Text = "Введите логин";
            log_add.Foreground = Brushes.LightGray;
            pass_add.Text = "Введите пароль";
            pass_add.Foreground = Brushes.LightGray;
            group.SelectedIndex = -1;
            pol.SelectedIndex = -1;
            date.Text = null;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void fam_add_GotFocus(object sender, RoutedEventArgs e)
        {
            if (fam_add.Text == "Введите фамилию")
            {
                fam_add.Text = "";
                fam_add.Foreground = Brushes.Black;
            }
        }

        private void fam_add_LostFocus(object sender, RoutedEventArgs e)
        {
            if (fam_add.Text == "")
            {
                fam_add.Text = "Введите фамилию";
                fam_add.Foreground = Brushes.LightGray;
            }
        }

        private void name_add_GotFocus(object sender, RoutedEventArgs e)
        {
            if (name_add.Text == "Введите имя")
            {
                name_add.Text = "";
                name_add.Foreground = Brushes.Black;
            }
        }

        private void name_add_LostFocus(object sender, RoutedEventArgs e)
        {
            if (name_add.Text == "")
            {
                name_add.Text = "Введите имя";
                name_add.Foreground = Brushes.LightGray;
            }
        }

        private void fname_add_GotFocus(object sender, RoutedEventArgs e)
        {
            if (fname_add.Text == "Введите отчество")
            {
                fname_add.Text = "";
                fname_add.Foreground = Brushes.Black;
            }
        }

        private void fname_add_LostFocus(object sender, RoutedEventArgs e)
        {
            if (fname_add.Text == "")
            {
                fname_add.Text = "Введите отчество";
                fname_add.Foreground = Brushes.LightGray;
            }
        }

        private void log_add_GotFocus(object sender, RoutedEventArgs e)
        {
            if (log_add.Text == "Введите логин")
            {
                log_add.Text = "";
                log_add.Foreground = Brushes.Black;
            }
        }

        private void log_add_LostFocus(object sender, RoutedEventArgs e)
        {
            if (log_add.Text == "")
            {
                log_add.Text = "Введите логин";
                log_add.Foreground = Brushes.LightGray;
            }
        }

        private void pass_add_GotFocus(object sender, RoutedEventArgs e)
        {
            if (pass_add.Text == "Введите пароль")
            {
                pass_add.Text = "";
                pass_add.Foreground = Brushes.Black;
            }
        }

        private void pass_add_LostFocus(object sender, RoutedEventArgs e)
        {
            if (pass_add.Text == "")
            {
                pass_add.Text = "Введите пароль";
                pass_add.Foreground = Brushes.LightGray;
            }
        }
    }
}
