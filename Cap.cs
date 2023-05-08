namespace PriceCalculator
{
    public class Cap
    {
        public double CapAmount { get; set; }
        private double _capPersentage;
        public double CapPersentage
        {
            get { return _capPersentage; }
            set
            {
                if (value > 0) _capPersentage = value / 100;
                else _capPersentage = 0;
            }
        }
        public Cap() { }
        public Cap(double CapAmount, double capPerentage)
        {
            this.CapAmount = CapAmount;
            CapPersentage = capPerentage;
        }
    
       

    }
}
