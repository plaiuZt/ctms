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

        public AuthController(SysUserDAL sysUserDAL)
        {
            this.SysUserDAL = sysUserDAL;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("appLogin")]
        public ActionResult AppLogin(UserLoginModel model)
        {
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
                    UserType = user.UserType
                };

                ResultData<LoginUserModel> rst = new ResultData<LoginUserModel>{
                    Code = 200,
                    Msg = "success",
                    Data = loginUser
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
                Data = token == LoginUser.Token
            };

            return Json(rst);
        }
    }
}
