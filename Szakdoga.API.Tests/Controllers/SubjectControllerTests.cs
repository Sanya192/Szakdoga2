using Microsoft.EntityFrameworkCore;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szakdoga.API.Controllers;
using Szakdoga.BusinessLayer.Utils;
using Szakdoga.Common.Dto;
using Szakdoga.Common.Mappers;
using Szakdoga.DataLayer.Model;

namespace Szakdoga.API.Tests.Controllers
{
    public class SubjectControllerTests : ControllerTestsBase<Subject, SubjectDto, string>
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Controller = new SubjectController(MockedContext, MockedMapper);
        }

        [TestCaseSource(nameof(_subjectData))]
        public void WhenGetCalledThenAllRecordsReturned(List<Subject> testData)
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

        [TestCaseSource(nameof(_subjectData))]
        public void WhenGetCalledWithIDThenOnlyRequiredRecordReturned(List<Subject> testData)
        {
            //Given
            SetUpMockedContextSubject(testData);
            MockedContext.StudentFinisheds.Returns(x=>SetUpMockedSetGeneral(new List<StudentFinished>()));

            //When && Then
            foreach (var item in testData)
            {
                var result = Controller.Get(item.Id);
                Assert.AreEqual(item.Id, result.Id);
                SetUpMockedContextSubject(testData);
            }

        }

        [TestCaseSource(nameof(_subjectData))]
        public void WhenPutSubjectToContextCalledWithNewItemThenAddCalled(List<Subject> testData)
        {
            //Given
            var mapper = new SubjectMapper();
            var mockedSet = SetUpMockedContextSubject(new List<Subject>());
            mockedSet.Update(Arg.Any<Subject>()).Returns(x => null);
            var testDataDto = testData.Select(x => mapper.MapToDto(x)).ToList();

            //When
            foreach (var item in testDataDto)
            {
                SubjectController.PutSubjectToContext(item, MockedContext);
            }
            //Then
            mockedSet.Received(testDataDto.Count).Add(Arg.Any<Subject>());
        }

        private static object[] _subjectData = new object[]{ new List<Subject>{
            new Subject()
                {
                    Id = "SX",
                    Language = Constants.DefaultLanguage.ToString(),
                }
            ,new Subject()
                {
                    Id = "SXL",
                    Language = Constants.DefaultLanguage.ToString(),

                },new Subject()
                {
                    Id="SS",
                    Language = Constants.DefaultLanguage.ToString(),

                },
            }};


        private DbSet<Subject> SetUpMockedContextSubject(List<Subject> testData)
        {
            DbSet<Subject> mockSetSubject = SetUpMockedSetGeneral(testData);

            MockedContext.Subjects.Returns(mockSetSubject);


            MockedMapper.MapToDto(Arg.Any<Subject>()).Returns(args => new SubjectDto { Id = ((Subject)args[0]).Id });
            return mockSetSubject;
        }

    }
}
