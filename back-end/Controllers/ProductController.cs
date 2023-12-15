using back_end.DataAccess;
using back_end.DTOs;
using back_end.Models;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private IRepository repo;
        public ProductController(IRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IEnumerable<SanPham> getProducts()
        {
            return repo.GetProducts;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SanPham>> GetProductById(string id)
        {
            var product = await repo.GetProductByIdAsync(id);
            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut("updateproduct/{masanpham}")] // api/products/updateproduct/{}
        public async Task<ActionResult<SanPham>> UpdateProduct(ProductDTO productDTO,string masanpham)
        {
            SanPham sanPham = new SanPham
            {
                MaSanPham = masanpham,
                TenSanPham = productDTO.tensanpham,
                GiaSanPham = productDTO.giasanpham,
                MoTaSanPham = productDTO.motasanpham,
                SoLuong = productDTO.soluong,
                HinhAnhSanPham = productDTO.hinhandsanpham,
                MaTinhTrang = productDTO.matinhtrang,
                MaBrand = productDTO.mabrand,
                MaLoaiSanPham = productDTO.maloaisanpham
            };

            var check = await repo.UpdateProductAsync(sanPham);
            if(check == null)
            {
                return BadRequest("Ops somthing went wrong !!!");
            }

            return Ok(sanPham);

        }
    }
}
