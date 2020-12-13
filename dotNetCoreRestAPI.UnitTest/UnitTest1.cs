using AutoMapper;
using dotNetCoreRestAPI.Controllers;
using dotNetCoreRestAPI.Data;
using dotNetCoreRestAPI.DTOs;
using dotNetCoreRestAPI.Profiles;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace dotNetCoreRestAPI.UnitTest
{
    //[TestFixture]
    //public class dotNetCoreRestAPIUnitTest
    //{
    //    private Mock<ICommandsRepo> _db;
    //    [Test]
    //    public void TestMethod1()
    //    {
    //        _db = new Mock<ICommandsRepo>();
    //        var mockMapper = new MapperConfiguration(cfg =>
    //        {
    //            cfg.AddProfile(new CommandsProfile());
    //        });
    //        var mapper = mockMapper.CreateMapper();
    //        var test = new CommandsController(_db.Object, mapper);
    //        Assert.AreEqual(test.GetAllCommands, DbRepo.
    //    }
    //}
    [TestFixture]
    public class dotNetCoreRestAPIUnitTest
    {
        private CommandsController _sut;
        private Mock<ICommandsRepo> _commandRepo = new Mock<ICommandsRepo>();
        private Mock<IMapper> _iMapper = new Mock<IMapper>();
        //private Mapper _mapper;
        public dotNetCoreRestAPIUnitTest()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CommandsProfile());
            });
            var _mapper = mockMapper.CreateMapper();
            _sut = new CommandsController(_commandRepo.Object, _iMapper.Object);
        }
        [Test]
        public void TestGetAll()
        {
            var test = _sut.GetAllCommands();
            var test1 = _iMapper.Setup(x => x.Map<IEnumerable<CommandReadDTO>>(test));
            //var test2 = _commandRepo.Setup(x => x.GetAllCommands());
            //Assert.AreEqual(test1, test2);
        }

    }
}
