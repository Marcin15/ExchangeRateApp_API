using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateApp_API.Interfaces;

public interface ICurrencyRatesService<T>
{
    Task<string> ReceiveJsonAsync(T querry);
}

