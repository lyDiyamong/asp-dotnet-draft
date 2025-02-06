using api.Data;
using api.Dto.Stock;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;

        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();

            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stock = await GetOneAsync(id);
            if (stock == null)
            {
                return null;
            }
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stocks.ToListAsync();
        }

        public async Task<Stock?> GetOneAsync(int id)
        {
            return await _context.Stocks.FirstOrDefaultAsync(stock => stock.Id == id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockReqDto stockReqDto)
        {
            var stockModel = await GetOneAsync(id);
            if (stockModel == null)
            {
                return null;
            }
            ;
            stockModel.Symbol = stockReqDto.Symbol;
            stockModel.CompanyName = stockReqDto.CompanyName;
            stockModel.Purchase = stockReqDto.Purchase;
            stockModel.LastDiv = stockReqDto.LastDiv;
            stockModel.Industry = stockReqDto.Industry;
            stockModel.MarketCap = stockReqDto.MarketCap;

            await _context.SaveChangesAsync();

            return stockModel;
        }
    }
}
