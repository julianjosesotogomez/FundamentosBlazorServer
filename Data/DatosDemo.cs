namespace FundamentosBlazorServer.Data
{
    public class DatosDemo : IDatosDemo
    {
        private int Edad;

        public DatosDemo()
        {
            Random numRnd = new Random();
            Edad = numRnd.Next(0, 100);
        }

        public int GetEdad()
        {
            return Edad;
        }
    }
}
