using back_end.Models;

namespace back_end.DataAccess
{
    public interface IRepository
    {
        public IEnumerable<SanPham> getSanPham { get; }
    }
}
