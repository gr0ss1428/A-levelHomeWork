namespace Task5
{
    internal class Rose : Flower
    {
        private string typeFlower;

        public override string Type
        {
            get
            {
                return typeFlower;
            }
        }

        public Rose(string type, double price, int count = 1) : base(price, count)
        {
            typeFlower = type;
        }
    }
}