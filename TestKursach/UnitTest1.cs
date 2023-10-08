
using kursach;
using kursach.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace TestKursach
{
    [TestFixture]
    public class AuthorizationTests
    {
        [Test]
        public void LoginCommand_ValidCredentials_SuccessfulLogin()
        {
            // Arrange
            var authorization = new Authorization();
            var passwordBox = new PasswordBox();
            var loginBtn = new Window();
            passwordBox.Password = "aaaaa";
            var expectedWindowType = typeof(Main); // Assuming successful login opens the 'Main' window

            // Act
            authorization.LoginCommand.Execute(new object[] { passwordBox, loginBtn });

            // Assert
            Assert.AreEqual(expectedWindowType, loginBtn.GetType());
        }

        [Test]
        public void LoginCommand_InvalidCredentials_ShowErrorMessage()
        {
            // Arrange
            var authorization = new Authorization();
            var passwordBox = new PasswordBox();
            var loginBtn = new Window();
            passwordBox.Password = "wrongPassword";
            var expectedErrorMessage = "Пользователь не найден. Некорректный ввод данных";

            // Act
            authorization.LoginCommand.Execute(new object[] { passwordBox, loginBtn });

            // Assert
            //Assert.AreEqual(MessageBox.Show(expectedErrorMessage));
        }
    }
}

