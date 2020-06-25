using System;
using System.Windows;
using System.Data.Entity;


namespace Laba8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly EntityContext entityContext;
        public MainWindow()
        {
            InitializeComponent();
            entityContext = new EntityContext("Laba8.Properties.Settings.AvtoConnection");
            InitCarList();
        }

        private void InitCarList()
        {
            entityContext.Cars.Load();
            dgCars.DataContext = entityContext.Cars.Local;

        }

        private void BtnAddCar_Click(object sender, RoutedEventArgs e)
        {
            Car newCar = new Car();
            EditCarWindow dialog = new EditCarWindow(newCar, false);
            if (dialog.ShowDialog() == true)
            {
                entityContext.Cars.Add(newCar);
                entityContext.SaveChanges();
                dialog.Close();
            }

        }

        private void BtnEditCar_Click(object sender, RoutedEventArgs e)
        {

            Car selectedCar = dgCars.SelectedItem as Car;
            if (selectedCar != null)
            {
                EditCarWindow dialog = new EditCarWindow(selectedCar, true);
                if (dialog.ShowDialog() == true)
                {
                    entityContext.SaveChanges();
                    dialog.Close();
                }
                else
                {
                    entityContext.Entry(selectedCar).Reload();
                    dgCars.DataContext = null;
                    dgCars.DataContext = entityContext.Cars.Local;
                }
            }
        }

        private void BtnDeleteCar_Click(object sender, RoutedEventArgs e)
        {
            Car deletedCar = dgCars.SelectedItem as Car;
            if (deletedCar != null)
            {
                var result = MessageBox.Show("Are you sure?", "Delete car from list", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    entityContext.Cars.Remove(deletedCar);
                    entityContext.SaveChanges();
                }
            }
        }

        private void DgCars_LoadingRow(object sender, System.Windows.Controls.DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
    }
}
