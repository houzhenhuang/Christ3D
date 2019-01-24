using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Christ3D.Application.Interfaces;
using Christ3D.Application.ViewModels;
using Christ3D.Domain.Commands;
using Christ3D.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Christ3D.UI.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentAppService _studentAppService;
        private readonly DomainNotificationHandler _notifications;
        public StudentController(IStudentAppService studentAppService, INotificationHandler<DomainNotification> notifications)
        {
            _studentAppService = studentAppService;
            _notifications = (DomainNotificationHandler)notifications;
        }

        public IActionResult Index()
        {
            return View(_studentAppService.GetAll());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentViewModel studentViewModel)
        {
            try
            {
                // 视图模型验证
                if (!ModelState.IsValid)
                    return View(studentViewModel);
                ////添加命令验证，采用构造函数方法实例
                //RegisterStudentCommand registerStudentCommand = 
                //    new RegisterStudentCommand(studentViewModel.Name, studentViewModel.Email, studentViewModel.BirthDate, studentViewModel.Phone);
                ////如果命令无效，证明有错误
                //if (!registerStudentCommand.IsValid())
                //{
                //    List<string> errorInfo = new List<string>();
                //    //获取到错误，请思考这个Result从哪里来的 
                //    foreach (var error in registerStudentCommand.ValidationResult.Errors)
                //    {
                //        errorInfo.Add(error.ErrorMessage);
                //    }
                //    //对错误进行记录，还需要抛给前台
                //    ViewBag.ErrorData = errorInfo;
                //    return View(studentViewModel);
                //}

                // 执行添加方法
                _studentAppService.Register(studentViewModel);
                //是否存在通知消息
                if (!_notifications.HasNotifications())
                    ViewBag.Sucesso = "Student Registered!";

                return View(studentViewModel);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }
    }
}