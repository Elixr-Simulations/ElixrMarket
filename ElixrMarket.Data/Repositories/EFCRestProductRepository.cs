// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using ElixrMarket.Data;
// using ElixrMarket.Data.EFCore;
// using ElixrMarket.Data.Models;
// using ElixrMarket.Data.Models.Dtos;
// using Microsoft.Extensions.Logging;

// namespace ElixrMarket.Data.Repositories
// {
//     public class EFCRestProductRepository : IRestProductRepository
//     {
//         private readonly ElixrDataContext _context;
//         private readonly ILogger<EFCRestProductRepository> _logger;


//         public async Task<ApiResult<IEnumerable<TProductDto>>> GetProducts<TProductDto>() where TProductDto : StoreFrontProductDto {
//             throw new NotImplementedException();
//         }
//         public async Task<ApiResult<Product>> GetProduct<TProductDto>() where TProductDto : StoreFrontProductDto {
//             throw new NotImplementedException();
//         }
//         public async Task<ApiResult<Product>> AddProduct(BasicProductDto product) {
//             throw new NotImplementedException();
//         }
//         public async Task<ApiResult<Product>> UpdateProduct(BasicProductDto product) {
//             throw new NotImplementedException();
//         }
//         public async Task<ApiResult<Product>> DeleteProduct(int id) {
//             throw new NotImplementedException();
//         }
//     }
// }