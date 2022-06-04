using ExchangeRateApp_API.Dtos;
using ExchangeRateApp_API.Queries;

namespace ExchangeRateApp_API.Interfaces
{
    public interface ILatestCurrencyService
    {
        Task<LatestCurrencyDtos> GetLatestCurrencyAsync(LatestCurrencyQuery latestCurrencyRequestDto);
    }
}