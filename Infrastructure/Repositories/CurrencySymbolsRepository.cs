using Domain.Entities;
using Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    class CurrencySymbolsRepository : ICurrencySymbolsRepository
    {
        public CurrencySymbolEntity GetCurrencySymbolsFromAfile()
        {
            var currencySymbolsEntity = new CurrencySymbolEntity();

            var inputJson = File.ReadAllText(@"..\Data\JSONresult.txt");

            currencySymbolsEntity = JsonConvert.DeserializeObject<CurrencySymbolEntity>(inputJson);

            return currencySymbolsEntity;
        }
    }
}
