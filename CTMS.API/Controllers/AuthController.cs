using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using CTMS.Entity;
using CTMS.Service.DAL;
using CTMS.Entity.Enum;
using CTMS.API.Models.Requests;
using CTMS.API.Models.Responses;

using CTMS.Utils;
using CTMS.API.Models;

namespace CTMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        public SysUserDAL SysUserDAL { get; set; }

        public static LoginUserModel LoginUser;

        [AllowAnonymous]
        [HttpPost]
        [Route("appLogin")]
        public ActionResult AppLogin(UserLoginModel model)
        //public ActionResult AppLogin(string username,string password)
        {
            if(model.UserName == null || model.Password == null)
            {
                return Json(new { Code = 301, Msg = "post未获取到参数" });
            }
            var user = SysUserDAL.GetByOne(q => q.UserName == model.UserName && q.Password == model.Password);
            if (user != null)
            {
                user.Token = TokenProccessor.MakeToken();

                LoginUserModel loginUser = new LoginUserModel {
                    Token = user.Token,
                    Id = user.Id,
                    UserName = user.UserName,
                    RealName = user.RealName,
                    Email = user.Email,
                    OpenId = user.OpenId,
                    QQ = user.QQ,
                    MobilePhone = user.MobilePhone,
                    UserType = user.UserType,
                    RoleIds= new List<int> { 1,2,3,4},
                    RoleName = "系统管理员",
                    FirstDepId = "1001",
                    FirstDepName = "管理中心",
                    DepName = "财政部",
                    Name = "李四"

                };

                ResultData<LoginUserModel> rst = new ResultData<LoginUserModel>{
                    Code = 200,
                    Msg = "success",
                    Result = loginUser
                };

                //更新登录用户Token
                SysUserDAL.Update(user);
                LoginUser = loginUser;
                return Json(rst);
            }
            else
            {
                return Json(new { Code = 401, Msg = "用户不存在或密码错误" });
            }
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("appLogout")]
        public async Task<IActionResult> AppLogout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
        [HttpGet]
        [Route("checkToke")]
        public ActionResult CheckToken(string token)
        {
            ResultData<bool> rst = new ResultData<bool>
            {
                Code = 200,
                Msg = "success",
                Result = token == LoginUser.Token
            };

            return Json(rst);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("login")]
        public ActionResult Login(string username, string password)
        {
            LoginUserModel model = new LoginUserModel();
            model.Id = 1;
            model.RealName = username;
            //model. = new List<int>() { 1, 2, 3 };
            //model.r = "系统管理员";
            model.Token = "DIOAFJL1231JKFAJFDAJ89023";
            //model.firstDepId = "1001";
            //model.firstDepName = "综合管理中心";
            //model.depName = "总经办";

            ResultData<LoginUserModel> rst = new ResultData<LoginUserModel>();
            rst.Code = 200;
            rst.Msg = "success";
            rst.Result = model;
            return Json(rst);
        }
    }
}
