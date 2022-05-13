using NUnit.Framework;
using System;
using Szakdoga.BusinessLayer.Utils;
using Szakdoga.Common.Dto;
using Szakdoga.Common.Mappers;
using Szakdoga.DataLayer.Model;

namespace Szakdoga.Common.Tests.Mappers
{
    [TestFixture]
    [Category("UnitTests")]
    public class SubjectMapperTests
    {
        private SubjectMapper _mapper;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _mapper = new SubjectMapper();
        }

        [TestCaseSource(nameof(_subjectModels))]
        public void WhenMapToDtoCalledThenCorrectDataReturned(Subject model)
        {
            //Given

            //When
            var result = _mapper.MapToDto(model);

            //Then
            Assert.AreEqual(model.Id, result.Id);
            Assert.AreEqual(model.Name, result.Name);
            Assert.AreEqual(model.Language, result.Language.ToString());
            Assert.AreEqual(model.Kredit, result.Kredit);
            Assert.AreEqual(model.RecommendedSemester, result.RecommendedSemester);

        }
        [TestCaseSource(nameof(_subjectDtos))]
        public void WhenMapToModelCalledThenCorrectDataReturned(SubjectDto dto)
        {
            //Given

            //When
            var result = _mapper.MapToModel(dto);

            //Then
            Assert.AreEqual(dto.Id, result.Id);
            Assert.AreEqual(dto.Name, result.Name);
            Assert.AreEqual(dto.Language.ToString(), result.Language);
            Assert.AreEqual(dto.Kredit, result.Kredit);
            Assert.AreEqual(dto.RecommendedSemester, result.RecommendedSemester);

        }

        [TestCaseSource(nameof(_subjectDtos))]
        public void WhenMapToModelCalledThenCorrectReferenceReturned(SubjectDto dto)
        {

            //Given
            Subject model = new();

            //When
            var result = _mapper.MapToModel(dto, model);

            //Then
            Assert.AreEqual(dto.Id, result.Id);
            Assert.AreEqual(dto.Name, result.Name);
            Assert.AreEqual(dto.Language.ToString(), result.Language);
            Assert.AreEqual(dto.Kredit, result.Kredit);
            Assert.AreEqual(dto.RecommendedSemester, result.RecommendedSemester);
            Assert.True(Object.ReferenceEquals(model, result));
        }

        private static readonly object[] _subjectModels = new object[]
        {
            new Subject()
            {
                Id= "ID1",
                Name="Name",
                Language=Constants.DefaultLanguage.ToString(),
                Kredit="1",
                RecommendedSemester="1",
            },

        };
        private static readonly object[] _subjectDtos = new object[]
        {
            new SubjectDto()
            {
                Id= "ID1",
                Name="Name",
                Language=Constants.DefaultLanguage,
                Kredit="1",
                RecommendedSemester="1",
            },

        };
    }
}
