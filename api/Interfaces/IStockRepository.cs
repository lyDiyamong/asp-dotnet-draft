using api.Dto.Stock;
using api.Models;

namespace api.Interfaces
{
    public interface IStockRepository
    {
        public Task<List<Stock>> GetAllAsync();
        public Task<Stock?> GetOneAsync(int id);

        public Task<Stock> CreateAsync(Stock stockModel);

        public Task<Stock?> UpdateAsync(int id, UpdateStockReqDto stockReqDto);

        public Task<Stock?> DeleteAsync(int id);
    }
}
