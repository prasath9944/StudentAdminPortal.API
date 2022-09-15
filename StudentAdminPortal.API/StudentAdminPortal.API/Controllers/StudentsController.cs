using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAdminPortal.API.Controllers
{
    [ApiController]
    public class StudentsController : Controller
    {
        public StudentsController(IStudentRepository studentRepository,IMapper mapper)
        {
            StudentRepository = studentRepository;
            Mapper = mapper;
        }

        public IStudentRepository StudentRepository { get; }
        public IMapper Mapper { get; }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllStudentsAsync()
        {

            var students = await (StudentRepository.GetStudentsAsync());
            return Ok(Mapper.Map<List<Student>>(students));


            //Without Using Automapper
            //var domainModelStudents = new List<Student>();
            //foreach( var stud in students)
            //{
            //    domainModelStudents.Add(new Student()
            //    {
            //        Id = stud.Id,
            //        FirstName = stud.FirstName,
            //        LastName=stud.LastName,
            //        DateOfBirth=stud.DateOfBirth,
            //        Email=stud.Email,
            //        Mobile=stud.Mobile,
            //        ProfileImageUrl=stud.ProfileImageUrl,
            //        GenderId = stud.GenderId,
            //        Address = new Address()
            //        {
            //            Id=stud.Address.Id,
            //            PhysicalAddress=stud.Address.PhysicalAddress,
            //            PostalAddress=stud.Address.PostalAddress
            //        },
            //        Gender=new Gender()
            //        {
            //            Id=stud.Gender.Id,
            //            Description=stud.Gender.Description
            //        }

            //    });
            //}
            //return Ok(domainModelStudents);



        }
    }
}
