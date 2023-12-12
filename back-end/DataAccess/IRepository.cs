using back_end.Models;

namespace back_end.DataAccess
{
    public interface IRepository
    {

        //Brand
        IEnumerable<Brand> getBrands {  get; }


        //LoaiSanPham Category
        IEnumerable<LoaiSanPham> getLoaiSanPhams { get; }


        //SanPham
        IEnumerable<SanPham> getProducts { get; }



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
