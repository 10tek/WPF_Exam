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

namespace Exam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<int, HeroesList> pages = new Dictionary<int, HeroesList>();
        private readonly int MaxPageCnt;
        private HeroesList heroesList;
        private StarWarsPeopleService service = new StarWarsPeopleService();
        private bool isClosed = true;

        public MainWindow()
        {
            InitializeComponent();
            MaxPageCnt = (int)Math.Ceiling(service.GetPage().Count / 10.0);
        }

        private void LoadBtnClick(object sender, RoutedEventArgs e)
        {
            if (pageTB.Text is null || !int.TryParse(pageTB.Text, out var page) || page > MaxPageCnt) return;
            starwarsTB.Opacity = 0;
            isClosed = false;
            dataGrid.Opacity = 1;
            closeBtn.Opacity = 1;
            dataGrid.Opacity = 1;
            if (pages.ContainsKey(page))
            {
                dataGrid.ItemsSource = pages[page].Heroes;
                return;
            }
            var service = new StarWarsPeopleService();
            heroesList = service.GetPage(page);
            dataGrid.ItemsSource = heroesList.Heroes;
            pages.Add(page, heroesList);
        }

        private void CloseBtnClick(object sender, RoutedEventArgs e)
        {
            if (isClosed) return; 
            isClosed = true;
            starwarsTB.Opacity = 1;
            closeBtn.Opacity = 0;
            dataGrid.Opacity = 0;
        }
    }
}
