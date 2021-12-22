
namespace DesignPatterns.GammaCategorization.CreationalDesignPatterns.Builder
{
    public class FacetedBuilder
    {
        public static void Main()
        {
            ProductBuilder productBuilder = new ProductBuilder();
            Product product = productBuilder.productInfoBuilder.SetName("Phone").SetPrice(600.54f).SetProductionYear(2022)
                                            .productDetailBuilder.SetWeight(230.06f).SetColor("Black").SetStockCount(8);

            product.DisplayProduct();
        }

        public class Product
        {
            public string Name { get; set; }

            public float Price { get; set; }

            public int ProductionYear { get; set; }

            public float Weight { get; set; }

            public string Color { get; set; }

            public int StockCount { get; set; }

            public void DisplayProduct()
            {
                Console.WriteLine($"Name: {Name}");
                Console.WriteLine($"Price: {Price}");
                Console.WriteLine($"ProductionYear: {ProductionYear}");
                Console.WriteLine($"Weight: {Weight}");
                Console.WriteLine($"Color: {Color}");
                Console.WriteLine($"StockCount: {StockCount}");
            }
        }

        public class ProductBuilder
        {
            protected Product product = new Product();

            public ProductInfoBuilder productInfoBuilder => new ProductInfoBuilder(product);

            public ProductDetailBuilder productDetailBuilder => new ProductDetailBuilder(product);

            public static implicit operator Product(ProductBuilder productBuilder)
            {
                return productBuilder.product;
            }
        }

        public class ProductInfoBuilder : ProductBuilder
        {
            public ProductInfoBuilder(Product product)
            {
                this.product = product;
            }

            public ProductInfoBuilder SetName(string name)
            {
                product.Name = name;
                return this;
            }

            public ProductInfoBuilder SetPrice(float price)
            {
                product.Price = price;
                return this;
            }

            public ProductInfoBuilder SetProductionYear(int productionYear)
            {
                product.ProductionYear = productionYear;
                return this;
            }
        }

        public class ProductDetailBuilder : ProductBuilder
        {
            public ProductDetailBuilder(Product product)
            {
                this.product = product;
            }

            public ProductDetailBuilder SetWeight(float weight)
            {
                product.Weight = weight;
                return this;
            }

            public ProductDetailBuilder SetColor(string color)
            {
                product.Color = color;
                return this;
            }

            public ProductDetailBuilder SetStockCount(int stockCount)
            {
                product.StockCount = stockCount;
                return this;
            }
        }
    }
}
