using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Stock;
using api.Models;

namespace api.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModels)
        {
            return new StockDto
            {
                Id = stockModels.Id,
                Symbol = stockModels.Symbol,
                CompanyName = stockModels.CompanyName,
                Purchase = stockModels.Purchase,
                LastDiv = stockModels.LastDiv,
                Industry = stockModels.Industry,
                MarketCap = stockModels.MarketCap


            };
        }
        public static Stock ToCreateStockReqDto(this CreateStockReqDto stockDto)
        {
            return new Stock
            {
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                Purchase = stockDto.Purchase,
                LastDiv = stockDto.LastDiv,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap
            };
        }
    }
}