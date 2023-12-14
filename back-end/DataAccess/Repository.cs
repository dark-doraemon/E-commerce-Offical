using back_end.DTOs;
using back_end.Models;

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

        public IEnumerable<Person> getUsers => context.People;

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


        //TinhTrangSanPham


        //VaiTroNhanVien


        //Voucher


    }
}
