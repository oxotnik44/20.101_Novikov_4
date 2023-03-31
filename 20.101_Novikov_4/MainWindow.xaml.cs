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
using _20._101_Novikov_4.Entity;
namespace _20._101_Novikov_4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void LoadForm(string specialityTitle)
        {
            //поиск в базе  групп по определенной специальности
            var dbContext = new Entities();
            var groups = dbContext.Group
                .Where(g => g.Speciality.Title == specialityTitle)
                .OrderByDescending(g => g.IdGroup)
                .ToList();
            //если найдены группы
            if (groups.Any())
            {
                LoadData.ItemsSource = groups;
            }
            //если  не найденны группы
            else
            {
                MessageBox.Show("Группы с заданной специальностью не найдены");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //отправляем название группы и делаем проверку через try catch
            try
            {
                string group = "15.02.09 Аддитивные технологии";
                LoadForm(group);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

    }
}
