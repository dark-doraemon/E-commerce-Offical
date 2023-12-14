using back_end.DTOs;
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
        string CreateMaKhachHang();
        bool AddKhachHang(string makhachhang);

        //LoaiTaiKhoan


        //MauSacSanPham


        //NhanVien
        string CreateMaNhanVien();
        bool AddNhanVien(string manhanvien, string mavaitro);

        //Person    
        IEnumerable<Person> getUsers { get; }
        Task<Person> getUserByIdAsync(string id);

        //TaiKhoan
        string CreateMaTaiKhoan();
        bool CreateAccount(TaiKhoan newTaiKhoan);
        bool CheckTaiKhoanExist(LoginDTO login);
        TaiKhoan CheckTaiKhoanVaMatKhauExist(LoginDTO login);
        //ThacMacKhieuNai



        //TinhTrangSanPham


        //VaiTroNhanVien


        //Voucher


    }
}
