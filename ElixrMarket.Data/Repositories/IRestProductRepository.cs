// using System.Collections.Generic;
// using System.Threading.Tasks;
// using ElixrMarket.Data;
// using ElixrMarket.Data.Models;
// using ElixrMarket.Data.Models.Dtos;

// namespace ElixrMarket.Data.Repositories
// {
//     public interface IRestProductRepository
//     {
//         Task<ApiResult<IEnumerable<TProductDto>>> GetProducts<TProductDto>() where TProductDto : StoreFrontProductDto;
//         Task<ApiResult<Product>> GetProduct<TProductDto>() where TProductDto : StoreFrontProductDto;
//         Task<ApiResult<Product>> AddProduct(BasicProductDto product);
//         Task<ApiResult<Product>> UpdateProduct(BasicProductDto product);
//         Task<ApiResult<Product>> DeleteProduct(int id);
//     }
// }