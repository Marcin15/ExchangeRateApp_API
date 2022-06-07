using ExchangeRateApp_API.Interfaces;
using ExchangeRateApp_API.Queries;

namespace ExchangeRateApp_API.Services
{
    public class OuterWebApiDataReciveCreator<T> : IOuterWebApiDataReciveCreator<T> where T : class
    {
        private readonly IServiceProvider _serviceProvider;
        public OuterWebApiDataReciveCreator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public ICurrencyRatesService<T> GetService(T querry)
        {
            switch (querry.GetType().Name)
            {
                case nameof(HistoricalCurrencyQuery):
                    return (ICurrencyRatesService<T>)_serviceProvider.GetService(typeof(HistoricalCurrencyRatesReceiveService));
                case nameof(LatestCurrencyQuery):
                    return (ICurrencyRatesService<T>)_serviceProvider.GetService(typeof(LatestCurrencyRatesReceiveService));
                default:
                    throw new ArgumentException($"Type {typeof(T)} is not handled");
            }
        }
    }
}
