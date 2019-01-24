using Christ3D.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Christ3D.Domain.Models
{
    public class Student : Entity
    {
        protected Student() { }
        public Student(Guid id, string name, string email, string phone, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            BirthDate = birthDate;
            Address = new Address();
        }

        //public Guid Id { get; private set; }//模型的唯一标识
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public DateTime BirthDate { get; private set; }
        /// <summary>
        /// 地址外键
        /// </summary>
        public Address Address { get; private set; }
    }
}
