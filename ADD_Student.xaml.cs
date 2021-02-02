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
    /// Логика взаимодействия для ADD_Student.xaml
    /// </summary>
    public partial class ADD_Student : Window
    {
        public demo_bdEntities bd_stud = new demo_bdEntities();
        public ADD_Student()
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
                if (fname_add.Text == "Введите отчество" || name_add.Text == "Введите имя" || fam_add.Text == "Введите фамилию" || rost.Text == "СМ" || ves.Text == "КГ" || group.SelectedIndex == -1 || pol.SelectedIndex == -1 || date.SelectedDate == null)
                {
                    MessageBox.Show("Вы указали не все данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {

                    person per = bd_stud.person.Add(new person
                    {
                        hight = int.Parse(rost.Text),
                        weight = int.Parse(ves.Text),
                    });

                    bd_stud.members.Add(new members
                    {
                        id_person = per.id,
                        fname = fam_add.Text,
                        fatherName = fname_add.Text,
                        sname = name_add.Text,
                        data_rogd = date.SelectedDate ?? DateTime.MinValue,
                        id_pol = pol.SelectedIndex + 1,
                        id_class = group.SelectedIndex + 1,
                    });
                    bd_stud.SaveChanges();
                    MessageBox.Show("Данные сохранены.");
                    clear_Click(sender, e);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте введённые данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            fname_add.Text = "Введите отчество";
            fname_add.Foreground = Brushes.LightGray;
            name_add.Text = "Введите имя";
            name_add.Foreground = Brushes.LightGray;
            fam_add.Text = "Введите фамилию";
            fam_add.Foreground = Brushes.LightGray;
            rost.Text = "СМ";
            rost.Foreground = Brushes.LightGray;
            ves.Text = "КГ";
            ves.Foreground = Brushes.LightGray;
            group.SelectedIndex = -1;
            pol.SelectedIndex = -1;
            date.Text = null;
            
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Close();
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

        private void ves_GotFocus(object sender, RoutedEventArgs e)
        {
            if (ves.Text == "КГ")
            {
                ves.Text = "";
                ves.Foreground = Brushes.Black;
            }
        }

        private void ves_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ves.Text == "")
            {
                ves.Text = "КГ";
                ves.Foreground = Brushes.LightGray;
            }
        }

        private void rost_GotFocus(object sender, RoutedEventArgs e)
        {
            if (rost.Text == "СМ")
            {
                rost.Text = "";
                rost.Foreground = Brushes.Black;
            }
        }

        private void rost_LostFocus(object sender, RoutedEventArgs e)
        {
            if (rost.Text == "")
            {
                rost.Text = "СМ";
                rost.Foreground = Brushes.LightGray;
            }
        }
    }
}
