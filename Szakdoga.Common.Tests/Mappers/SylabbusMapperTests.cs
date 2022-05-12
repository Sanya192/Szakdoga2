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
    public class SylabbusMapperTests
    {
        private SyllabusMapper _mapper;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _mapper = new SyllabusMapper();
        }

        [TestCaseSource(nameof(syllabusModels))]
        public void WhenMapToDtoCalledThenCorrectDataReturned(Syllabus model)
        {
            //Given

            //When
            var result = _mapper.MapToDto(model);

            //Then
            Assert.AreEqual(model.Id, result.Id);
            Assert.AreEqual(model.Name, result.Name);
            Assert.AreEqual(model.Length, result.Length);
            Assert.AreEqual(model.MustChoseCredit, result.MustChoseCredit);
            Assert.AreEqual(model.ChosableCredit, result.ChosableCredit);
            Assert.AreEqual(model.StartingSpecSemester, result.StartingSpecSemester);
            Assert.AreEqual(model.Parent, result.Parent);

        }
        [TestCaseSource(nameof(syllabusDtos))]
        public void WhenMapToModelCalledThenCorrectDataReturned(SyllabusDto dto)
        {
            //Given

            //When
            var result = _mapper.MapToModel(dto);

            //Then
            Assert.AreEqual(dto.Id, result.Id);
            Assert.AreEqual(dto.Name, result.Name);
            Assert.AreEqual(dto.Length, result.Length);
            Assert.AreEqual(dto.MustChoseCredit, result.MustChoseCredit);
            Assert.AreEqual(dto.ChosableCredit, result.ChosableCredit);
            Assert.AreEqual(dto.StartingSpecSemester, result.StartingSpecSemester);
            Assert.AreEqual(dto.Parent, result.Parent);

        }

        private static object[] syllabusModels = new object[]
        {
            new Syllabus()
            {
                Id= "ID1",
                Name="Name",
                Length="3",
                MustChoseCredit="1",
                ChosableCredit="1",
                StartingSpecSemester="1",
                Parent="1",
            },

        };
        private static object[] syllabusDtos = new object[]
        {
            new SyllabusDto()
            {
                Id= "ID1",
                Name="Name",
                Length="3",
                MustChoseCredit="1",
                ChosableCredit="1",
                StartingSpecSemester="1",
                Parent="1",
            },

        };
    }
}
