using Christ3D.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Christ3D.Domain.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        //一些Student独有的接口
        Student GetByEmail(string email);
    }
}
