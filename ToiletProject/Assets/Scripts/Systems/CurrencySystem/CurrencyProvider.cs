using System;
using System.Collections.Generic;
using System.Linq;
using Data.User;

namespace Systems
{
    public class CurrencyProvider : ICurrencyProvider
    {
       public IReadOnlyList<Currency> Currencies { get; private set; }

        public CurrencyProvider(UserData userData)
        {
            Currencies = userData.PlayerCurrencies;
        }

        public Currency GetCurrencyByType(CurrencyType type)
        {
            return Currencies.FirstOrDefault(c => c.Type == type)
                   ?? throw new ArgumentException($"Can't find currency type {type} int currencies");
        }
    }

    public interface ICurrencyProvider
    {
        public Currency GetCurrencyByType(CurrencyType type);
    }
}