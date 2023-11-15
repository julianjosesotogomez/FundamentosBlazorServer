namespace FundamentosBlazorServer.Data
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IDatosDemo _datosDemo;

        public WeatherForecastService(IDatosDemo datosDemo)
        {
            _datosDemo = datosDemo;
        }

        public Task<WeatherForecast[]> GetForecastAsync(DateOnly startDate)
        {
            //Inyección de dependencias 
            var rnd = new Random();
            int numMax = _datosDemo.GetEdad();

            return Task.FromResult(Enumerable.Range(1, numMax).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray());
        }
    }
}
