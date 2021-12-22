
namespace DesignPatterns.GammaCategorization.CreationalDesignPatterns.Builder
{
    public class FunctionalBuilder
    {
        public static void Main()
        {
            PhoneBuilder phoneBuilder = new PhoneBuilder();
            MobilePhone mobilePhone = phoneBuilder.SetBrand("Samsung").SetModel("Galaxy A71").SetPrice(600).BuildPhone();
            mobilePhone.Display();
        }
    }

    public class MobilePhone
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int Price { get; set; }

        public void Display()
        {
            Console.WriteLine($"Brand: {Brand}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Price: {Price}");
        }
    }

    public class PhoneBuilder
    {
        public readonly List<Action<MobilePhone>> actionList = new List<Action<MobilePhone>>();

        public PhoneBuilder SetBrand(string brand)
        {
            actionList.Add(x => x.Brand = brand);
            return this;
        }
        public PhoneBuilder SetModel(string model)
        {
            actionList.Add(x => x.Model = model);
            return this;
        }

        public MobilePhone BuildPhone()
        {
            MobilePhone phone = new MobilePhone();
            actionList.ForEach(x => x(phone));
            return phone;
        }
    }

    public static class PriceBuilder
    {
        public static PhoneBuilder SetPrice(this PhoneBuilder phoneBuilder, int price)
        {
            phoneBuilder.actionList.Add(x => x.Price = price);
            return phoneBuilder;
        }
    }
}
