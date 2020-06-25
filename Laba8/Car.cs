namespace Laba8
{
    public class Car
    {

        private int carId;
        private string brand;
        private string model;
        private string color;
        private int year;

        public string Color
        {
            get
            {
                if (color == null)
                {
                    return "Unknown";
                }
                else
                {
                    return color;
                }
            }

            set => color = value;
        }

        public int CarId { get => carId; set => carId = value; }
        public string Brand { get => brand; set => brand = value; }
        public string Model { get => model; set => model = value; }
        public int Year { get => year; set => year = value; }

        public override string ToString()
        {
            return string.Format("id = {0} - Brand: {1}, Model: {2}, Year: {3}, Color: {4}", CarId, Brand, Model, Year, Color);
        }

    }

}
