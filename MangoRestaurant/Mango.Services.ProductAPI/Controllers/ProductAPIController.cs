using Mango.Services.ProductAPI.Models.DTOs;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/products")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        protected ResponceDto _responce;
        private IProductRepository _productRepository;
        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._responce = new ResponceDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
                _responce.Result = productDtos;
            }
            catch (Exception ex)
            {

                _responce.IsSuccess = false;
                _responce.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _responce;
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<object> Get(int productId)
        {
            try
            {
                ProductDto productDtos = await _productRepository.GetProductById(productId);
                _responce.Result = productDtos;
            }
            catch (Exception ex)
            {

                _responce.IsSuccess = false;
                _responce.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _responce;
        }

        [HttpPost]
        public async Task<object> Create([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
                _responce.Result = model;
            }
            catch (Exception ex)
            {

                _responce.IsSuccess = false;
                _responce.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _responce;
        }

        [HttpPut]
        public async Task<object> Update([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
                _responce.Result = model;
            }
            catch (Exception ex)
            {

                _responce.IsSuccess = false;
                _responce.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _responce;
        }

        [HttpDelete]
        [Route("{productId}")]
        public async Task<object> Delete(int productId)
        {
            try
            {
                bool isSuccess = await _productRepository.DeleteProduct(productId);
                _responce.Result = isSuccess;
            }
            catch (Exception ex)
            {

                _responce.IsSuccess = false;
                _responce.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _responce;
        }
    }
}
