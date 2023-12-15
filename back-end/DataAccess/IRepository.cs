using back_end.DTOs;
using back_end.Models;

namespace back_end.DataAccess
{
    public interface IRepository
    {

        //Brand
        IEnumerable<Brand> GetBrands { get; }


        //LoaiSanPham Category
        IEnumerable<LoaiSanPham> GetLoaiSanPhams { get; }


        //SanPham
        IEnumerable<SanPham> GetProducts { get; }

        Task<SanPham> GetProductByIdAsync(string id);


        Task<SanPham> UpdateProductAsync(SanPham product);



        //Cart



        //Comment


        //DatHang


        //DatHangSanPham


        //HoaDon


        //KhachHang
        string CreateMaKhachHang();
        bool AddKhachHang(string makhachhang);

        //LoaiTaiKhoan


        //MauSacSanPham


        //NhanVien
        string CreateMaNhanVien();
        bool AddNhanVien(string manhanvien, string mavaitro);

        //Person    
        IEnumerable<Person> GetUsers { get; }
        Task<Person> getUserByIdAsync(string id);

        //TaiKhoan
        string CreateMaTaiKhoan();
        bool CreateAccount(TaiKhoan newTaiKhoan);
        bool CheckTaiKhoanExist(LoginDTO login);
        TaiKhoan CheckTaiKhoanVaMatKhauExist(LoginDTO login);


        //ThacMacKhieuNai
        string CreateMaKhieuNai();
        Task<IEnumerable<ThacMacKhieuNai>> GetKhieuNaiAsync();

        Task<bool> PostKhieuNaiAsync(ThacMacKhieuNai thongtin);

        Task<bool> DeleteThacMacKhieuNaiAsync(string id);


        //TinhTrangSanPham


        //VaiTroNhanVien


        //Voucher


    }
}
