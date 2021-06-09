using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace dz_bank
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bank_data data;
        public MainWindow()
        {
            InitializeComponent();

            data = bank_data.CreateBankData();

            ComboBoxDep.ItemsSource = data.DepartamentsBank;

        }

        private void ComboBoxDep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listDbBView.ItemsSource = data.BankClients.Where(find);
        }

        //Workers arg это текущий элемент 
        /// <summary>
        /// возвращает работника с id, как у департамент
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool find(BankClient arg)
        {
            return arg.DepartmentId == (ComboBoxDep.SelectedItem as Departaments).DepartmentId;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxDep.Items.Refresh();
            listDbBView.Items.Refresh();
        }

    
        

        /// <summary>
        /// удалить клиента в Отделе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var Delette_Client = (BankClient)listDbBView.SelectedItem;
            data.BankClients.Remove(Delette_Client);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            data.Perevod(NameOtp.Text, Convert.ToInt32(CountSumma.Text), NamePolu.Text);
        }

        /// <summary>
        /// Капитализация вклада. Каждый месяц (сумма / на %) / 12 месяцкв
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            data.Kapitalize(NameClientaVclada.Text);
        }

        /// <summary>
        /// сортировка по возрасу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listDbBView.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Age", ListSortDirection.Ascending));

        }
    }
}
