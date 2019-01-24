using AutoMapper;
using AutoMapper.QueryableExtensions;
using Christ3D.Application.Interfaces;
using Christ3D.Application.ViewModels;
using Christ3D.Domain.Commands;
using Christ3D.Domain.Core.Bus;
using Christ3D.Domain.Interfaces;
using Christ3D.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Christ3D.Application.Services
{
    public class StudentAppService : IStudentAppService
    {
        //注意这里是要IoC依赖注入的，还没有实现
        private readonly IStudentRepository _studentRepository;
        //用来进行DTO
        private readonly IMapper _mapper;
        //中介者 总线
        private readonly IMediatorHandler _bus;

        public StudentAppService(
            IStudentRepository StudentRepository,
            IMapper mapper,
            IMediatorHandler bus
            )
        {
            _studentRepository = StudentRepository;
            _mapper = mapper;
            _bus = bus;
        }

        public IEnumerable<StudentViewModel> GetAll()
        {

            //第一种写法 Map
            return _mapper.Map<IEnumerable<StudentViewModel>>(_studentRepository.GetAll());

            //第二种写法 ProjectTo
            //return (_StudentRepository.GetAll()).ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider);
        }

        public StudentViewModel GetById(Guid id)
        {
            return _mapper.Map<StudentViewModel>(_studentRepository.GetById(id));
        }

        public void Register(StudentViewModel StudentViewModel)
        {
            //判断是否为空等等 还没有实现

            //_StudentRepository.Add(_mapper.Map<Student>(StudentViewModel));
            //_StudentRepository.SaveChanges();

            var registerCommand = _mapper.Map<RegisterStudentCommand>(StudentViewModel);
            _bus.SendCommand(registerCommand);

        }

        public void Update(StudentViewModel StudentViewModel)
        {
            _studentRepository.Update(_mapper.Map<Student>(StudentViewModel));
            _studentRepository.SaveChanges();
        }

        public void Remove(Guid id)
        {
            _studentRepository.Remove(id);
            _studentRepository.SaveChanges();

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
