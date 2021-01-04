using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MockSchoolManagement.DataRepositorys;

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
        //返回学生的名字
        public string Index()
        {
            return _studentRepository.GetStudent(1).Name;
        }
    }
}
