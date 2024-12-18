using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Controllers;
using MyMvcApp.Models;
using Xunit;

namespace MyMvcApp.MyMvcApp.Tests
{
    public class UserControllerTests
    {
        [Fact]
        public void Index_ReturnsViewResult_WithListOfUsers()
        {
            // Arrange
            var controller = new UserController();

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<User>>(viewResult.ViewData.Model);
            Assert.Equal(UserController.userlist, model);
        }

        [Fact]
        public void Details_ReturnsNotFound_WhenIdIsNull()
        {
            // Arrange
            var controller = new UserController();

            // Act
            var result = controller.Details(0);
            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Details_ReturnsNotFound_WhenUserNotFound()
        {
            // Arrange
            var controller = new UserController();

            // Act
            var result = controller.Details(999);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Details_ReturnsViewResult_WithUser()
        {
            // Arrange
            var controller = new UserController();
            var user = new User { Id = 1, Name = "Test User" };
            UserController.userlist.Add(user);

            // Act
            var result = controller.Details(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<User>(viewResult.ViewData.Model);
            Assert.Equal(user, model);

            // Cleanup
            UserController.userlist.Remove(user);
        }

        [Fact]
        public void Remove_ReturnsNotFound_WhenUserNotFound()
        {
            // Arrange
            var controller = new UserController();

            // Act
            var result = controller.Delete(999);
            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Remove_RedirectsToIndex_WhenUserRemoved()
        {
            // Arrange
            var controller = new UserController();
            var user = new User { Id = 1, Name = "Test User" };
            UserController.userlist.Add(user);

            // Act
            var result = controller.Delete(1);
            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            Assert.DoesNotContain(user, UserController.userlist);
        }
    }
}
