using AutoMapper;
using Mango.Services.OrderAPI.DbContexts;
using Mango.Services.OrderAPI.Models;
using Mango.Services.OrderAPI.Models.DTOs;

namespace Mango.Services.OrderAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _dbConetxt;
        private IMapper _mapper;
        public OrderRepository(ApplicationDbContext dbConetxt,IMapper mapper)
        {
            _dbConetxt = dbConetxt;
            _mapper = mapper;
        }

        public async Task<bool> AddOrder(OrderHeader orderHeader)
        {
            _dbConetxt.Add(orderHeader);
            await _dbConetxt.SaveChangesAsync();
            return true;
        }

        public async Task<OrderHeaderDto> AddOrderHeader(OrderHeaderDto orderHeaderDto)
        {
            OrderHeader orderHeader = _mapper.Map<OrderHeader>(orderHeaderDto);
            _dbConetxt.Add(orderHeader);
            await _dbConetxt.SaveChangesAsync();
            return _mapper.Map<OrderHeaderDto>(orderHeader);

        }

        public async Task UpdateOrderPaymentStatus(int orderHeaderId, bool paid)
        {
            var orderHeaderFromDb = _dbConetxt.OrderHeaders.FirstOrDefault(x=>x.OrderHeaderId == orderHeaderId);
            if(orderHeaderFromDb != null)
            {
                orderHeaderFromDb.PaymentStatus = paid;
                await _dbConetxt.SaveChangesAsync();
            }
        }
    }
}
