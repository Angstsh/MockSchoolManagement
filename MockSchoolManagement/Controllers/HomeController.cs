using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MockSchoolManagement.DataRepositorys;
using MockSchoolManagement.Models;

namespace MockSchoolManagement.Controllers
{
    public class HomeController:Controller
    {
        private readonly IStudentRepository _studentRepository;
        //使用构造函数注入的方式注入IStudentRepository
        public HomeController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        //ViewData使用方法
        public ViewResult Details()
        {
            Student model = _studentRepository.GetStudent(1);
            //使用ViewData将PageTitle和Student模型传递给View
            ViewData["PageTitle"] = "Student Details";
            ViewData["Student"] = model ;

            return View();
        }
        //ViewBag使用方法
        public ViewResult Detailsp()
        {
            Student model = _studentRepository.GetStudent(1);
            //使用ViewBag将PageTitle和Student模型传递给View
            ViewData["PageTitle"] = "学生详情";
            ViewData["Student"] = model;

            return View();
        }
        //强类型视图
        public ViewResult Detailsq()
        {
            Student model = _studentRepository.GetStudent(1);
            ViewData["PageTitle"] = "学生详情Q";

            return View(model);
        }
    }
}
