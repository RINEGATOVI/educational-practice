using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Автосалон;

namespace UnitTestProjectCarShowroom
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckAuth_EmptyEmail_ThrowsException()
        {
            AuthForm authForm = new AuthForm();
            var exception = Assert.ThrowsException<Exception>(() => authForm.CheckAuth("", "password123"));
            Assert.AreEqual("Не все поля заполнены", exception.Message);
        }

        [TestMethod]
        public void CheckAuth_EmptyPassword_ThrowsException()
        {
            AuthForm authForm = new AuthForm();
            var exception = Assert.ThrowsException<Exception>(() => authForm.CheckAuth("user@example.com", ""));
            Assert.AreEqual("Не все поля заполнены", exception.Message);
        }

        [TestMethod]
        public void CheckAuth_UserDoesNotExist_ThrowsException()
        {
            AuthForm authForm = new AuthForm();
            // Arrange
            string email = "nonexistent@example.com";
            string password = "password123";

            var exception = Assert.ThrowsException<Exception>(() => authForm.CheckAuth(email, password));
            Assert.AreEqual("Пользователя с таким логином не существует", exception.Message);
        }

        [TestMethod]
        public void CheckAuth_InvalidPassword_ThrowsException()
        {
            AuthForm authForm = new AuthForm();
            // Arrange
            string email = "john@example.com";
            string password = "wrongpassword";

            var exception = Assert.ThrowsException<Exception>(() => authForm.CheckAuth(email, password));
            Assert.AreEqual("Пароль неверный", exception.Message);
        }

        [TestMethod]
        public void CheckAuth_ValidCredentials_ReturnsRoleID()
        {
            AuthForm authForm = new AuthForm();
            // Arrange
            string email = "john@example.com";
            string password = "1234";
            int expectedRoleID = 1;

            int actualRoleID = authForm.CheckAuth(email, password);
            Assert.AreEqual(expectedRoleID, actualRoleID);
        }

        [TestMethod]
        public void CheckAuth_EmailWithSpaces_ThrowsException()
        {
            AuthForm authForm = new AuthForm();
            var exception = Assert.ThrowsException<Exception>(() => authForm.CheckAuth("   ", "password123"));
            Assert.AreEqual("Не все поля заполнены", exception.Message);
        }

        [TestMethod]
        public void CheckAuth_PasswordWithSpaces_ThrowsException()
        {
            AuthForm authForm = new AuthForm();
            var exception = Assert.ThrowsException<Exception>(() => authForm.CheckAuth("user@example.com", "   "));
            Assert.AreEqual("Не все поля заполнены", exception.Message);
        }

        [TestMethod]
        public void CheckAuth_InvalidEmailFormat_ThrowsException()
        {
            AuthForm authForm = new AuthForm();
            var exception = Assert.ThrowsException<Exception>(() => authForm.CheckAuth("invalidemail", "password123"));
            Assert.AreEqual("Не все поля заполнены", exception.Message); // Уточнить сообщение
        }

        [TestMethod]
        public void CheckAuth_EmailDifferentCase_SuccessfulLogin()
        {
            AuthForm authForm = new AuthForm();
            // Arrange
            string email = "JOHN@example.com"; // Разный регистр
            string password = "1234"; // Правильный пароль
            int expectedRoleID = 1;

            // Act
            int actualRoleID = authForm.CheckAuth(email, password);

            // Assert
            Assert.AreEqual(expectedRoleID, actualRoleID);
        }
        [TestMethod]
        public void CheckAuth_EmailWithSpace_SuccessfulLogin()
        {
            AuthForm authForm = new AuthForm();
            // Arrange
            string email = " john@example.com "; // Разный регистр
            string password = "1234"; // Правильный пароль
            int expectedRoleID = 1;

            // Act
            int actualRoleID = authForm.CheckAuth(email, password);

            // Assert
            Assert.AreEqual(expectedRoleID, actualRoleID);
        }
    }
}
