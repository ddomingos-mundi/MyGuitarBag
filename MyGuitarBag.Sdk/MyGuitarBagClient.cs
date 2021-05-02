using MyGuitarBag.Sdk.Resources;
using MyGuitarBag.Sdk.Resources.Interfaces;
using RestSharp.Easy;
using RestSharp.Easy.Interfaces;

namespace MyGuitarBag.Sdk
{
    public class MyGuitarBagClient : IMyGuitarBagClient
    {
        public IGuitarResource Guitar { get; set; }

        public MyGuitarBagClient(Configuration config)
        {
            this.Initialize(new Configuration
            {
                ApiUrl = config.ApiUrl,
                TraceId = config.TraceId,
                UserAgent = $"MyGuitarBag SDK - {config.UserAgent}"
            }); ;
        }

        private void Initialize(Configuration config)
        {
            IEasyRestClient client = new EasyRestClient(
                config.ApiUrl,
                requestKey: config.TraceId,
                userAgent: $"Mundipagg SDK Lifecycle - {config?.UserAgent ?? string.Empty}"
            );

            this.Guitar = new GuitarResource(client);
        }
    }
}
