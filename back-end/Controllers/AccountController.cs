﻿using back_end.DataAccess;
using back_end.DTOs;
using back_end.Interfaces;
using back_end.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace back_end.Controllers
{
    public class AccountController : BaseApiController
    {
        private string loaitaikhoankhach = "ltkkhachhang";
        private IRepository repo;
        private readonly ITokenService tokenService;

        public AccountController(IRepository repo,ITokenService tokenService)
        {
            this.repo = repo;
            this.tokenService = tokenService;
        }


        [HttpPost("register")] // api/account/register
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            string makhachhang = repo.CreateMaKhachHang();
            Person person = new Person
            {
                PersonId = makhachhang,
                HoTen = registerDTO.hoten,
                Tuoi = registerDTO.tuoi,
                GioiTinh = registerDTO.gioitinh,
                Cccd = registerDTO.cccd,
                Sđt = registerDTO.sdt,
                DiaChi = registerDTO.diachi,    
                Email = registerDTO.email,
                KhachHang = new KhachHang { MaKhachHang = makhachhang }
            };

            TaiKhoan newTaiKhoan = new TaiKhoan
            {
                MaTaiKhoan = repo.CreateMaTaiKhoan(),
                Username = registerDTO.username,
                Password = registerDTO.password,
                Person = person,
                MaLoaiTaiKhoan = loaitaikhoankhach
            };

            //khi thêm tài khoản thì person cũng được thêm theo 
            if(repo.CreateAccount(newTaiKhoan) == false)
            {
                return BadRequest("Tài khoản đã tồn tại");
            }

            return new UserDTO {
                username = registerDTO.username,
                token = tokenService.CreateToken(newTaiKhoan)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            if(repo.CheckTaiKhoanExist(loginDTO) == false)
            {
                return Unauthorized("Tài khoản sai");
            }

            TaiKhoan taikhoan = repo.CheckTaiKhoanVaMatKhauExist(loginDTO);
            if (taikhoan == null)
            {
                return Unauthorized("Mật khẩu sai");
            }

            //khi đăng nhập thành công trả về username và 1 JWT token
            //JWT token này dùng để trả về thông tin người dùng
            return new UserDTO { username = loginDTO.username , token = tokenService.CreateToken(taikhoan)};
        }
    }
}
