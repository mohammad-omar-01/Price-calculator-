namespace PriceCalculator
{
    public class AdditionalCost
    {
        public string Description { get; set; }
        public double CostAmount { get; set; }
        private double _costPersentage;
        public double CostPersentage
        {
            get { return _costPersentage; }
            set
            {
                if (value > 0) _costPersentage = value / 100;
                else _costPersentage = 0;
            }
        }

        public AdditionalCost()
        {

        }
        public AdditionalCost(string description, double costAmount, double costPersentage)
        {
            Description = description;
            CostAmount = costAmount;
            CostPersentage = costPersentage;
        }

    }
}
