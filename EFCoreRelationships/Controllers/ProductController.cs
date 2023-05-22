using EFCoreRelationships.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        private readonly int productId;

        public ProductController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get(int categoryId)
        {
            var products = await appDbContext.Products.Where(c =>c.CategoryId == categoryId).ToListAsync();
            return products;
        }


        [HttpGet("{productId:int}")]
        public async Task<ActionResult<Size>> GetProductSize(int productId)
        {
            var Size = await appDbContext.Sizes.FirstOrDefaultAsync(p => p.ProductId == productId);
            return Size;
        }
        
        /*
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get(int categoryId)
        {
            var products = await appDbContext.Products
                .Where(x => x.CategoryId == categoryId)
                .Include(x => x.Size)
                .Include(x => x.Colors).ToListAsync();
            return products;
        }
        */
    }
}
