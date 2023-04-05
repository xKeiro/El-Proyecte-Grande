using AutoMapper;
using backend.Dtos.Categories.Cuisine;
using backend.Maps;
using backend.Models.Categories;
using backend.Services;
using backend.Services.Categories;
using BackendTests.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using Moq.EntityFrameworkCore;

namespace BackendTests.ServiceTests;

[TestFixture]
public class CuisineTests
{
    private ElProyecteGrandeContext context;
    private IMapper mapper;
    private CuisineService cuisineService;
    private List<Cuisine> cuisines;
    private List<CuisinePublic> cuisinePublics;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<ElProyecteGrandeContext>()
            .UseInMemoryDatabase(databaseName: "CuisinesDb")
            .Options;
        //context = new Mock<ElProyecteGrandeContext>(new DbContextOptions<ElProyecteGrandeContext>());
        var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(typeof(MappingProfile)));
        mapper = mappingConfig.CreateMapper();
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
        context = new ElProyecteGrandeContext(options);
        context.ChangeTracker.Clear();
        context.Cuisines.AddRange(cuisines);
        context.SaveChanges();
        context.ChangeTracker.Clear();
        cuisineService = new CuisineService(context, mapper);
        //add cuisines to context
        //_ = context.Setup(c => c.Cuisines).ReturnsDbSet(cuisines);
    }
    [TearDown]
    public void TearDown()
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
    [Test]
    public async Task GetAll_CuisinesExist_ShouldReturnCuisines()
    {
        // Arrange
        // Act
        var result = await cuisineService.GetAll();
        // Assert
        Util.AreEqualByJson(result, cuisinePublics);
        Assert.That(result, Is.TypeOf<List<CuisinePublic>>());
    }
    [Test]
    public async Task Find_CuisineExists_ShouldReturnCuisine()
    {
        // Arrange
        // Act
        var result = await cuisineService.Find(1);
        // Assert
        Util.AreEqualByJson(result, cuisinePublics[0]);
        Assert.That(result, Is.TypeOf<CuisinePublic>());
    }
    [Test]
    public async Task Find_CuisineDoesNotExist_ShouldReturnNull()
    {
        // Arrange
        // Act
        var result = await cuisineService.Find(4);
        // Assert
        Assert.That(result, Is.Null);
    }
    [Test]
    public async Task Add_CuisineDoesNotExist_ShouldReturnWithCuisinePublic()
    {
        // Arrange
        var cuisineWithoutId = new CuisineWithoutId { Name = "Chinese" };
        // Act
        var result = await cuisineService.Add(cuisineWithoutId);
        // Assert
        Assert.That(result, Is.TypeOf<CuisinePublic>());
        Assert.That(result, Has.Property("Id"));
    }
    [Test]
    public async Task Update_CuisineExists_ShouldUpdateCuisine()
    {
        // Arrange
        var cuisineWithoutId = new CuisineWithoutId { Name = "Chinese" };
        var cuisinePublic = new CuisinePublic { Id = 2, Name = "Chinese" };
        // Act
        var result = await cuisineService.Update(2, cuisineWithoutId);
        // Assert
        Util.AreEqualByJson(result, cuisinePublic);
        Assert.That(result, Is.TypeOf<CuisinePublic>());
    }
    [Test]
    public async Task IsUnique_CuisineDoesNotExists_ShouldReturnTrue()
    {
        // Arrange
        var cuisineWithoutId = new CuisineWithoutId { Name = "Chinese" };
        // Act
        var result = await cuisineService.IsUnique(cuisineWithoutId);
        // Assert
        Assert.That(result, Is.True);
    }
    [Test]
    public async Task IsUnique_CuisineExists_ShouldReturnFalse()
    {
        // Arrange
        var cuisineWithoutId = new CuisineWithoutId { Name = "French" };
        // Act
        var result = await cuisineService.IsUnique(cuisineWithoutId);
        // Assert
        Assert.That(result, Is.False);
    }
}
