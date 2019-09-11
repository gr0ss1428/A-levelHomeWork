namespace Task5
{
    public abstract class Flower
    {
        public abstract string Type { get; }
        public double Price { get; set; }
        public int Count { get; set; }

        public Flower(double price, int count)
        {
            Price = price;
            Count = count;
        }

        public override bool Equals(object obj)
        {
            if (obj is Flower)
            {
                Flower flower = obj as Flower;
                return (Type == flower.Type && Price == flower.Price);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string GetInfo()
        {
            return $"Type: {Type}, Count: {Count}, Price:{Price}, PriceAll:{Count * Price}\n";
        }
    }
}