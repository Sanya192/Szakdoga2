using Microsoft.EntityFrameworkCore;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Szakdoga.API.Controllers;
using Szakdoga.BusinessLayer.Utils;
using Szakdoga.Common.Dto;
using Szakdoga.Common.Mappers;
using Szakdoga.DataLayer.Model;

namespace Szakdoga.API.Tests.Controllers
{
    public class SyllabusControllerTests : ControllerTestsBase<Syllabus, SyllabusDto, string>
    {
        [OneTimeSetUp]
        public void OneTimeChildSetup()
        {
            Controller = new SyllabusController(MockedContext, MockedMapper);
        }

        [TestCaseSource(nameof(_syllabusData))]
        public void WhenGetCalledThenAllRecordsReturned(List<Syllabus> testData)
        {
            //Given
            SetUpMockedContextSubject(testData);
            //When
            var result = Controller.Get().ToList();

            //Then
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(testData[i].Id, result[i].Id);
            };
        }

        [TestCaseSource(nameof(_syllabusData))]
        public void WhenGetCalledWithIDThenOnlyRequiredRecordReturned(List<Syllabus> testData)
        {
            //Given
            SetUpMockedContextSubject(testData);
            MockedContext.StudentFinisheds.Returns(x => SetUpMockedSetGeneral(new List<StudentFinished>()));


            //When && Then
            foreach (var item in testData)
            {
                var result = Controller.Get(item.Id);
                Assert.AreEqual(item.Id, result.Id);
                SetUpMockedContextSubject(testData);
            }

        }

        private static readonly object[] _syllabusData = new object[]{ new List<Syllabus>{
            new Syllabus()
                {
                    Id = "SX",
                    Subjects= new List<Subject>(),
                }
            ,new Syllabus()
                {
                    Id = "SXL",
                    Subjects= new List<Subject>(),
                },new Syllabus()
                {
                    Id="SS",
                    Subjects= new List<Subject>(),
                },
            }};


        private DbSet<Syllabus> SetUpMockedContextSubject(List<Syllabus> testData)
        {
            DbSet<Syllabus> mockSetSubject = SetUpMockedSetGeneral(testData);

            MockedContext.Syllabi.Returns(mockSetSubject);


            MockedMapper.MapToDto(Arg.Any<Syllabus>()).Returns(args => new SyllabusDto { Id = ((Syllabus)args[0]).Id });
            return mockSetSubject;
        }

    }
}
