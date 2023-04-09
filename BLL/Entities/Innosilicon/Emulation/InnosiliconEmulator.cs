using BLL.Entities.Innosilicon.Response;

namespace BLL.Entities.Innosilicon.Emulation
{
    internal class InnosiliconEmulator
    {
        private const string _type = "INNOSILICON";

        private string _jwt;
        public string Jwt
        {
            get { return _jwt; }
            private set { _jwt = value; }
        }

        private string _ip;
        public string Ip
        {
            get { return _ip; }
            private set { _ip = value; }
        }

        public string Type
        {
            get { return _type; }
        }

        private Random _random;

        public InnosiliconEmulator()
        {
            Ip = Guid.NewGuid().ToString();
            Jwt = Guid.NewGuid().ToString();
            _random = new Random();
        }

        public InnosiliconSummaryResult GetSummary()
        {
            return new InnosiliconSummaryResult()
            {
                DEVS = new InnosiliconSummaryDevice[1] {
                    new InnosiliconSummaryDevice() {
                        Status = "Alive",
                        Temperature = _random.Next(50, 70),
                        HashRate = _random.NextDouble() * (10-5) + 5 // от 5 до 10
                    }
                }
            };
        }
    }
}
