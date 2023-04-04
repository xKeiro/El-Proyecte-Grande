using AutoMapper;
using backend.Dtos.Categories.Cuisine;
using backend.Maps;
using backend.Models.Categories;
using backend.Services;
using backend.Services.Categories;
using BackendTests.Utils;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace BackendTests.ServiceTests;

[TestFixture]
public class CuisineTests
{
    private Mock<ElProyecteGrandeContext> context;
    private IMapper mapper;
    private CuisineService cuisineService;
    private List<Cuisine> cuisines;
    private List<CuisinePublic> cuisinePublics;

    [SetUp]
    public void Setup()
    {
        context = new Mock<ElProyecteGrandeContext>(new DbContextOptions<ElProyecteGrandeContext>());
        var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(typeof(MappingProfile)));
        mapper = mappingConfig.CreateMapper();
        cuisineService = new CuisineService(context.Object, mapper);
        cuisines = new List<Cuisine>()
            {
                new Cuisine { Id = 1, Name = "French" },
                new Cuisine { Id = 2, Name = "American" },
                new Cuisine { Id = 3, Name = "Italian" }
            };
        cuisinePublics = new List<CuisinePublic>()
            {
                new CuisinePublic { Id = 1, Name = "French" },
                new CuisinePublic { Id = 2, Name = "American" },
                new CuisinePublic { Id = 3, Name = "Italian" }
            };
        //add cuisines to context
        _ = context.Setup(c => c.Cuisines).ReturnsDbSet(cuisines);
    }
    [Test]
    public async Task GetAll_CuisinesExist_ShouldReturnCuisines()
    {
        // Arrange
        // Act
        var result = await cuisineService.GetAll();
        // Assert
        Util.AreEqualByJson(result, cuisinePublics);
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<List<CuisinePublic>>());
    }
}
