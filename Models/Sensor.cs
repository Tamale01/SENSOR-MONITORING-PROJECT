namespace SensorMonitor.Models
{
    public class Sensor
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string Name { get; set; }

        public Location Location { get; set; }

        public Sensor()
        {
            
        }
    }
}
