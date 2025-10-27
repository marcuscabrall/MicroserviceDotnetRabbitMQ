using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesAndInventorySystem.InventoryAPI.Data.ValueObjects;
using SalesAndInventorySystem.InventoryAPI.Model;
using SalesAndInventorySystem.InventoryAPI.Model.Context;
using SalesAndInventorySystem.InventoryAPI.Model.Enums;

namespace SalesAndInventorySystem.InventoryAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly PostgresContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(PostgresContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO?> FindById(long id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            return _mapper.Map<ProductVO?>(product);
        }

        public async Task<ProductVO> Create(ProductVO vo)
        {
            var product = _mapper.Map<Product>(vo);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO?> Update(ProductVO vo)
        {
            var entity = await _context.Products
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(p => p.Id == vo.Id);

            if (entity is null) return null;

            if (entity.Status == StatusType.Unavailable) return null;

            _mapper.Map(vo, entity);

            _context.Entry(entity).Property(p => p.CreatedAt).IsModified = false;

            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(entity);
        }

        public async Task<bool> Delete(long id)
        {
            var product = await _context.Products
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product is null) return false;

            if (product.Status != StatusType.Unavailable)
            {
                product.Status = StatusType.Unavailable;
                await _context.SaveChangesAsync();
            }

            return true;
        }
    }
}
