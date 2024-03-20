using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitTestAPI.Controller;
using UnitTestAPI.Models;
using UnitTestAPI.Service;

namespace _030324_ApiTest
{
    [TestClass]
    public class CategoryControllerTests
    {
        private CategoryController _controller;
        private Mock<ICategoryService> _mockService;

        public CategoryControllerTests()
        {
            _mockService = new Mock<ICategoryService>();
            _controller = new CategoryController(_mockService.Object);
        }

        [TestMethod]
        public async Task Category_GetAll()
        {
            // Arrange
            _mockService.Setup(service => service.GetCategory())
                        .ReturnsAsync(new List<Category>());

            // Act
            var result = await _controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result is OkObjectResult);
        }

        [TestMethod]
        public async Task Category_GetCategoryById()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var category = new Category { CategoryId = categoryId, CategoryName = "Test Category", Description = "Test Description" };
            _mockService.Setup(service => service.GetCategory())
             .ReturnsAsync(new List<Category>());


            // Act
            var result = await _controller.Get(categoryId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result is OkObjectResult);
        }

        [TestMethod]
        public async Task Category_Save()
        {
            // Arrange
            var category = new Category { CategoryId = Guid.NewGuid(), CategoryName = "Test Category", Description = "Test Description" };
            _mockService.Setup(service => service.Save(category)).ReturnsAsync(true);

            // Act
            var result = await _controller.Post(category);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result is CreatedResult);
        }

        [TestMethod]
        public async Task Category_Update()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var category = new Category { CategoryId = categoryId, CategoryName = "Test Category", Description = "Test Description" };
            _mockService.Setup(service => service.Update(categoryId, category)).ReturnsAsync(true);

            // Act
            var result = await _controller.Put(categoryId, category);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result is OkResult);
        }

        [TestMethod]
        public async Task Category_Delete()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            _mockService.Setup(service => service.Delete(categoryId)).ReturnsAsync(true);

            // Act
            var result = await _controller.Delete(categoryId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result is OkResult);
        }

        // Add more test methods for different scenarios as needed

    }
}
