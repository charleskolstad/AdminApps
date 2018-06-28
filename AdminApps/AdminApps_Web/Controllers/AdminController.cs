using AdminApps_Core;
using AdminApps_Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AdminApps_Web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            Provider provider = new Provider();
            UserInfo model = UserManager.GetUserByName("cpkolsta");//User.Identity.Name);
            return View(model);
        }

        #region partial views
        public ActionResult AllUsers()
        {
            return View();
        }

        public ActionResult UserProfile()
        {
            return View();
        }
        #endregion

        #region angular methods
        public JsonResult GetAllUsers()
        {
            List<UserInfo> allUsers = UserManager.GetAllUsers();
            return Json(allUsers, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllGroups()
        {
            List<UserGroups> groups = UserManager.GroupsGetAll();
            return Json(groups, JsonRequestBehavior.AllowGet);
        }

        public string SaveUser(UserInfo user)
        {
            string errorMessage = string.Empty;

            if (user.UserInfoID > 0)
                UserManager.UpdateUser(user, out errorMessage);
            else
                UserManager.InsertUser(user, out errorMessage);

            return errorMessage;
        }

        public string DeleteUser(string delUser)
        {
            if (UserManager.DeleteUser(delUser))
                return string.Empty;

            return "Error deleting user.";
        }

        public JsonResult GetUserByName()
        {
            UserInfo userInfo = UserManager.GetUserByName("cpkolsta");//User.Identity.Name);
            return Json(userInfo, JsonRequestBehavior.AllowGet);
        }

        public string UpdateProfile(UserInfo user)
        {
            string errorMessage = string.Empty;
            UserManager.UpdateUser(user, out errorMessage);

            return errorMessage;
        }

        public string SaveProfileImage(string newImage)
        {
            string errorMessage = string.Empty;
            UserInfo userInfo = UserManager.GetUserByName("cpkolsta");//User.Identity.Name);

            string fileName = "~/Assets/IMG/UploadIMG/" + Guid.NewGuid().ToString() + ".png";
            byte[] data = Convert.FromBase64String(newImage);
            var fileStream = new FileStream(Server.MapPath(fileName), FileMode.Create, FileAccess.ReadWrite);
            fileStream.Write(data, 0, data.Length);
            fileStream.Close();
            userInfo.ProfileImage = newImage;

            UserManager.UpdateUser(userInfo, out errorMessage);
            return errorMessage;
        }
        #endregion
    }
}