using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dto.Stock;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public StockController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = _context.Stocks.ToList()
            .Select(stock => stock.ToStockDto());

            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetOne([FromRoute] int id)
        {
            var stock = _context.Stocks.Find(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        [HttpPost] 
        public IActionResult Create([FromBody] CreateStockReqDto stockDto)
        {
            var stockModel = stockDto.ToCreateStockReqDto();

            _context.Stocks.Add(stockModel);

            _context.SaveChanges();

            return CreatedAtAction(nameof(GetOne), new {id = stockModel.Id}, stockModel.ToStockDto());

        }
        [HttpPatch("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateStockReqDto updateDto)
        {
            var stockModel = _context.Stocks.FirstOrDefault(stock => stock.Id == id);

            if (stockModel == null) {
                return NotFound();
            }

            stockModel.Symbol = updateDto.Symbol;
            stockModel.CompanyName = updateDto.CompanyName;
            stockModel.Purchase = updateDto.Purchase;
            stockModel.LastDiv = updateDto.LastDiv;
            stockModel.Industry = updateDto.Industry;
            stockModel.MarketCap = updateDto.MarketCap;

            _context.SaveChanges();

            return Ok(stockModel.ToStockDto());


        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id) 
        {
            var stock = _context.Stocks.FirstOrDefault(stock => stock.Id == id);
            if (stock == null) {
                return NotFound();
            }

            _context.Stocks.Remove(stock);

            return NoContent();

        }
    }
}