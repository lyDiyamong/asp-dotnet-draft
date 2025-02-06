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
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,
                Comments = stockModel.Comments.Select(comment => comment.ToCommentDto()).ToList(),


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
        // public static Stock ToUpdateStockReqDto(this UpdateStockReqDto stockDto)
        // {
        //     return new Stock
        //     {
        //         Symbol = stockDto.Symbol,
        //         CompanyName = stockDto.CompanyName,
        //         Purchase = stockDto.Purchase,
        //         LastDiv = stockDto.LastDiv,
        //         Industry = stockDto.Industry,
        //         MarketCap = stockDto.MarketCap
        //     };
        // }
    }
}