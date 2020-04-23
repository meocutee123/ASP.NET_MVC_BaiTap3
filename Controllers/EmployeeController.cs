using BaiTap3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
namespace BaiTap3.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(EmployeeInformation empM)
        {
            string path = Server.MapPath("/Images/");
            string fileName = Path.GetFileName(empM.imgFile.FileName);
            string fullPath = Path.Combine(path, fileName);
            empM.imgFile.SaveAs(fullPath);

            string fSave = ("~/Images/emp.txt");
            string[] emInfo =
                 {empM.empID, empM.empName, empM.empDateOfBirth.ToShortDateString(),
                empM.empEmail,empM.empPassword,empM.empDivision, empM.empImg};

            //Lưu các thông ti vào tập tin emp.txt
            //System.IO.File.WriteAllLines(fSave, emInfo);
            //Ghi nhận các thông tin đăng ký để hiện thị trên View Confirm
            ViewBag.empID = emInfo[0];
            ViewBag.empName = emInfo[1];
            ViewBag.empDateOfBirth = emInfo[2].ToString();
            ViewBag.empEmail = emInfo[3];
            ViewBag.empPassword = emInfo[4];
            ViewBag.empDivision = emInfo[5];
            ViewBag.empAvatar = "/Images/" + emInfo[6];
            //using (EmployeeEntities1 empDB = new EmployeeEntities1())
            //{
            //    empDB.EmployeeInformations.Add(empM);
            //    empDB.SaveChanges();
            //}
            //ModelState.Clear();

            return View("Confirm");
        }

        public ActionResult Confirm()
        {
            return View();
        }
    }
}