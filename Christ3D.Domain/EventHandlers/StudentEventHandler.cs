﻿using Christ3D.Domain.Events.Student;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Christ3D.Domain.EventHandlers
{
    /// <summary>
    /// Student事件处理程序
    /// 继承INotificationHandler<T>，可以同时处理多个不同的事件模型
    /// </summary>
    public class StudentEventHandler :
        INotificationHandler<StudentRegisteredEvent>,
        INotificationHandler<StudentUpdatedEvent>,
        INotificationHandler<StudentRemovedEvent>
    {
        // 学习被注册成功后的事件处理方法
        public Task Handle(StudentRegisteredEvent message, CancellationToken cancellationToken)
        {
            // 恭喜您，注册成功，欢迎加入我们。

            return Task.CompletedTask;
        }

        // 学生被修改成功后的事件处理方法
        public Task Handle(StudentUpdatedEvent message, CancellationToken cancellationToken)
        {
            // 恭喜您，更新成功，请牢记修改后的信息。

            return Task.CompletedTask;
        }

        // 学习被删除后的事件处理方法
        public Task Handle(StudentRemovedEvent message, CancellationToken cancellationToken)
        {
            // 您已经删除成功啦，记得以后常来看看。

            return Task.CompletedTask;
        }
    }
}
