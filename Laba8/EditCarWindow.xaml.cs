using System.Windows;

namespace Laba8
{
    /// <summary>
    /// Логика взаимодействия для EditCarWindow.xaml
    /// </summary>
    public partial class EditCarWindow : Window
    {
      
        private Car car;

        public EditCarWindow(Car car, bool isEditMode)
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            this.car = car;
            DataContext = this.car;
            if (isEditMode)
            {
                Title = "Edit Car";
            }
            else
            {
                Title = "Add Car";
            }
        }

        public Car GetCar()
        {
            return car;
        }
        private void BtnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
