namespace AzureCacheforRedisApp.Entities
{
    public class City
    {
        public int Population { get; set; }
        public string Name { get; set; }
        
        public City(int population, string name)
        {
            this.Population = population;
            this.Name = name;
        }
    }
}