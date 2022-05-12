using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szakdoga.Common.Dto;
using Szakdoga.Common.Mappers;
using Szakdoga.DataLayer.Model;

namespace Szakdoga.Common.Tests.Mappers
{
    [TestFixture]
    [Category("UnitTests")]
    public class StudentMapperTests
    {
        private StudentMapper _mapper;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _mapper = new StudentMapper();
        }

        [TestCaseSource(nameof(studentModels))]
        public void WhenMapToDtoCalledThenCorrectDataReturned(Student model)
        {
            //Given

            //When
            var result = _mapper.MapToDto(model);

            //Then
            Assert.AreEqual(model.Id, result.Id);
            Assert.AreEqual(model.Name, result.Name);
            Assert.AreEqual(model.StudentFinisheds.First().StudentId, result.Id);
            Assert.AreEqual(model.StudentFinisheds.First().SubjectId, result.FinishedCourses.First().Key);
            Assert.AreEqual(model.StudentFinisheds.First().Grade, result.FinishedCourses.First().Value);
            Assert.AreEqual(model.Syllabi.First().Id, result.Syllabi.First());


        }
        [TestCaseSource(nameof(studentDtos))]
        public void WhenMapToModelCalledThenCorrectDataReturned(StudentDto dto)
        {
            //Given

            //When
            var result = _mapper.MapToModel(dto);

            //Then
            Assert.AreEqual(dto.Id, result.Id);
            Assert.AreEqual(dto.Name, result.Name);
            Assert.AreEqual(dto.Id, result.StudentFinisheds.First().StudentId);
            Assert.AreEqual(dto.FinishedCourses.First().Key, result.StudentFinisheds.First().SubjectId);
            Assert.AreEqual(dto.FinishedCourses.First().Value, result.StudentFinisheds.First().Grade);
            Assert.AreEqual(dto.Syllabi.First(),result.Syllabi.First().Id);


        }

        private static object[] studentModels = new object[]
        {
            new Student()
            {
                Id= 1,
                Name="Sanyi",
                StudentFinisheds= new List<StudentFinished>
                {
                    new StudentFinished()
                    {
                        StudentId= 1,
                        SubjectId="Subject",
                        Grade=5
                    }
                },
                Syllabi=new List<Syllabus>()
                {
                    new Syllabus() { Id="Syllabi"}
                }

            },

        };
        private static object[] studentDtos = new object[]
        {
            new StudentDto()
            {
                Id= 1,
                Name="Sanyi",
                FinishedCourses= new Dictionary<string, int?>()
                {
                    { "Subject",5}
                },
                Syllabi= new List<string>()
                {
                    "Syllabi"
                }
            }
        };
    }
}
