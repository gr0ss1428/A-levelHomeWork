namespace Task5
{
    internal class Tulip : Flower
    {
        private string typeFlower;

        public override string Type
        {
            get
            {
                return typeFlower;
            }
        }

        public Tulip(string type, double price, int count = 1) : base(price, count)
        {
            typeFlower = type;
        }
    }
}