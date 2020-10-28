using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Converter.Common.Representation
{
    public class ConversorCoin
    {
        [Required]
        public double Coin { get; set; }

        [Required]
        public double CurrencyQuote { get; set; }

        [Required]
        public string Type { get; set; }

        public double ConvertResult { get; set; }

    }
}
