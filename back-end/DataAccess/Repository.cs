using back_end.DTOs;
using back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace back_end.DataAccess
{
    public class Repository : RepositotyBaseFunction, IRepository
    {
        private EcommerceContext context;
        public Repository(EcommerceContext context)
        {
            this.context = context;
        }
        //Brand
        public IEnumerable<Brand> GetBrands => context.Brands;

        //LoaiSanPham Category
        public IEnumerable<LoaiSanPham> GetLoaiSanPhams => context.LoaiSanPhams;


        //SanPham
        public IEnumerable<SanPham> GetProducts => context.SanPhams;

        public async Task<SanPham> GetProductByIdAsync(string id)
        {
            return await context.SanPhams.FindAsync(id);
        }

        public async Task<SanPham> UpdateProductAsync(SanPham product)
        {
            if(context.SanPhams.Where(sp => sp.MaSanPham == product.MaSanPham).Any() == false)
            {
                return null;
            }

            context.SanPhams.Update(product);
            await context.SaveChangesAsync();
            return product;
        }


        //Cart



        //Comment


        //DatHang


        //DatHangSanPham


        //HoaDon


        //KhachHang
        public string CreateMaKhachHang()
        {
            List<string> makhachhangs = context.KhachHangs.Select(kh =>kh.MaKhachHang).ToList();
            string lastID = "KH" + base.funcGetLastIndex(makhachhangs, 2);
            return lastID;  
        }

        public bool AddKhachHang(string makhachhang)
        {
            if (context.KhachHangs.Where(kh => kh.MaKhachHang == makhachhang).Any())
            {
                return false;
            }

            List<string> makhachhangs = new List<string>();
            string lastID = "KH" + base.funcGetLastIndex(makhachhangs, 2);
            context.KhachHangs.Add(new KhachHang
            {
                MaKhachHang = makhachhang,
            });
            context.SaveChanges();
            return true;
        }



        //LoaiTaiKhoan


        //MauSacSanPham


        //NhanVien
        public string CreateMaNhanVien()
        {
            List<string> manhanviens = context.NhanViens.Select(nv =>nv.MaNhanVien ).ToList();
            string lastID = "NV" + base.funcGetLastIndex(manhanviens, 2);
            return lastID;
        }

        public bool AddNhanVien(string manhanvien, string mavaitro)
        {
            return true;
        }


        //Person

        public IEnumerable<Person> GetUsers => context.People;

        public async Task<Person> getUserByIdAsync(string id)
        {
            return await context.People.FindAsync(id);
        }




        //TaiKhoan
        public string CreateMaTaiKhoan()
        {
            List<string> mataikhoan = context.TaiKhoans.Select(tk =>tk.MaTaiKhoan).ToList();
            string lastID = "TK" + base.funcGetLastIndex(mataikhoan, 2);
            return lastID;
        }

        public bool CreateAccount(TaiKhoan newTaiKhoan)
        {
            //kiểm tra user name có tồn tại không
            if(context.TaiKhoans.Where(tk =>newTaiKhoan.Username.ToLower() == tk.Username.ToLower()).Any())
            {
                return false;
            }

            context.TaiKhoans.Add(newTaiKhoan);
            context.SaveChanges();
            return true;

        }

        public bool CheckTaiKhoanExist(LoginDTO login)
        {
            //đầu tiên kiểm tra tài khoản có tồn tại không
            var user = context.TaiKhoans.FirstOrDefault(tk => tk.Username == login.username);
            if(user == null)
            {
                return false;
            }
            return true;

        }

        public TaiKhoan CheckTaiKhoanVaMatKhauExist(LoginDTO login)
        {
            var taikhoan = context.TaiKhoans.FirstOrDefault(tk => tk.Username == login.username
            && tk.Password == login.password);

            if(taikhoan == null )
            {
                return null;
            }
            return taikhoan;

        }

        //ThacMacKhieuNai
        public string CreateMaKhieuNai()
        {
            List<string> makhieunai = context.ThacMacKhieuNais.Select(kn => kn.MaKhieuNai).ToList();
            string lastID = "TMKN" + base.funcGetLastIndex(makhieunai, 4);
            return lastID;
        }

        public async Task<IEnumerable<ThacMacKhieuNai>> GetKhieuNaiAsync()
        {
            return await context.ThacMacKhieuNais.ToListAsync();
        }

        public async Task<bool> PostKhieuNaiAsync(ThacMacKhieuNai thongtin)
        {
            await context.ThacMacKhieuNais.AddAsync(thongtin);
            return await context.SaveChangesAsync() >= 1 ? true : false;
        }

        public async Task<bool> DeleteThacMacKhieuNaiAsync(string id)
        {
            ThacMacKhieuNai thacmackieunai = await context.ThacMacKhieuNais.FindAsync(id);
            if (thacmackieunai == null)
            {
                return false;
            }

            context.ThacMacKhieuNais.Remove(thacmackieunai);
            return await context.SaveChangesAsync() > 0 ? true : false;
        }



        //TinhTrangSanPham


        //VaiTroNhanVien


        //Voucher


    }
}
