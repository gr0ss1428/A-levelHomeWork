namespace Task5
{
    internal class Clove : Flower
    {
        private string typeFlower;

        public override string Type
        {
            get
            {
                return typeFlower;
            }
        }

        public Clove(string type, double price, int count = 1) : base(price, count)
        {
            typeFlower = type;
        }
    }
}