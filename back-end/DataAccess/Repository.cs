using back_end.Models;

namespace back_end.DataAccess
{
    public class Repository : IRepository
    {
        private EcommerceContext context;
        public Repository(EcommerceContext context)
        {
            this.context = context;
        }

        public IEnumerable<SanPham> getSanPham =>context.SanPhams;
    }
}
