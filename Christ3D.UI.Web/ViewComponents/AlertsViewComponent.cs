﻿using Christ3D.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Christ3D.UI.Web.ViewComponents
{
    public class AlertsViewComponent : ViewComponent
    {
        // 缓存注入，为了收录信息（错误方法，以后会用通知，通过领域事件来替换）
        // private IMemoryCache _cache;
        // 领域通知处理程序
        private readonly DomainNotificationHandler _notifications;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="studentRepository"></param>
        /// <param name="uow"></param>
        /// <param name="bus"></param>
        /// <param name="cache"></param>
        //public AlertsViewComponent(IMemoryCache cache)
        //{
        //    _cache = cache;
        //}
        // 构造函数注入
        public AlertsViewComponent(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }
        /// <summary>
        /// Alerts 视图组件
        /// 可以异步，也可以同步，注意方法名称，同步的时候是Invoke
        /// 我写异步是为了为以后做准备
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // 获取到缓存中的错误信息
            //var errorData = _cache.Get("ErrorData");
            //var notificacoes = await Task.Run(() => (List<string>)ViewBag.ErrorData);
            var notificacoes = await Task.Run(() => _notifications.GetNotifications());
            //遍历错误信息，赋值给 ViewData.ModelState
            notificacoes?.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Value));
            return View();
        }
    }
}
