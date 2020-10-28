using Converter.Common.Representation;
using Microsoft.AspNetCore.Mvc;

namespace Converter.Common.Services
{
    public interface IConverterService
    {
        Result<ConversorCoin> ConvertCoin(ConversorCoin coin);
    }
}
