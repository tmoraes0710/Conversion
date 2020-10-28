using Converter.Common.Representation;
using Converter.Common.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Converter.Core.Services
{
    public class ConverterService : IConverterService
    {
        public Result<ConversorCoin> ConvertCoin(ConversorCoin coin)
        {

            switch (coin.Type)
            {
                case "BRLTOUSD":
                    coin.ConvertResult = Math.Round(coin.Coin / coin.CurrencyQuote, 2);
                    break;

                case "BRLTOEUR":
                    coin.ConvertResult = Math.Round(coin.Coin / coin.CurrencyQuote, 2);
                    break;

                case "USDTOBRL":
                    coin.ConvertResult = Math.Round(coin.Coin * coin.CurrencyQuote, 2);
                    break;
                case "EURTOBRL":
                    coin.ConvertResult = Math.Round(coin.Coin * coin.CurrencyQuote, 2);
                    break;
                default:
                    break;
            }

            return new Result<ConversorCoin>(coin);
        }
    }
}
