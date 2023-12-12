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
        //Brand
        public IEnumerable<Brand> getBrands => context.Brands;

        //LoaiSanPham Category
        public IEnumerable<LoaiSanPham> getLoaiSanPhams => context.LoaiSanPhams;


        //SanPham
        public IEnumerable<SanPham> getProducts => context.SanPhams;

        //Cart



        //Comment


        //DatHang


        //DatHangSanPham


        //HoaDon


        //KhachHang



        //LoaiTaiKhoan


        //MauSacSanPham


        //NhanVien


        //Person





        //TaiKhoan


        //ThacMacKhieuNai


        //TinhTrangSanPham


        //VaiTroNhanVien


        //Voucher
    }
}
