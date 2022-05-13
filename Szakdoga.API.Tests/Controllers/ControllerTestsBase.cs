using Microsoft.EntityFrameworkCore;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Szakdoga.API.Controllers;
using Szakdoga.Common.Mappers;
using Szakdoga.DataLayer.DAL;

namespace Szakdoga.API.Tests.Controllers
{
    [TestFixture]
    [Category("UnitTests")]
    public abstract class ControllerTestsBase<Tmodel, TDto, TKey> where Tmodel : class
    {
        protected SzakdogaControllerBase<Tmodel, TDto, TKey> Controller { get; set; }
        protected ISzakdogaContext MockedContext { get; set; }
        protected IMapper<Tmodel, TDto> MockedMapper { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            MockedContext = Substitute.For<ISzakdogaContext>();
            MockedMapper = Substitute.For<IMapper<Tmodel, TDto>>();

        }

        protected DbSet<T> SetUpMockedSetGeneral<T>(List<T> testData) where T : class
        {
            var data = testData.AsQueryable();
            DbSet<T> mockSetSubject = Substitute.For<DbSet<T>, IQueryable<T>>();
            ((IQueryable<T>)mockSetSubject).Provider.Returns(data.Provider);
            ((IQueryable<T>)mockSetSubject).Expression.Returns(data.Expression);
            ((IQueryable<T>)mockSetSubject).ElementType.Returns(data.ElementType);
            ((IQueryable<T>)mockSetSubject).GetEnumerator().Returns(data.GetEnumerator());
            return mockSetSubject;
        }

    }
}