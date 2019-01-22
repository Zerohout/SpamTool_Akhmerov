using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpamTool_Akhmerov.lib.Service;
using System;

namespace UnitTestProject1.Service
{
    [TestClass]
    public class PasswordServiceTests
    {
        [TestMethod]
        [Description("Тестирвоание процессе кодирования строки")]
        [Priority(1)]
        public void Encode_123_234_Test()
        {
            //AAA
            // Arange, Act, Assert

            //Arange
            var str = "123";
            var expected_encrypted_str = "234";
            var key = 1;

            //Act
            var actual_encrypted_str = PasswordService.Encode(str, key);

            //Assert
            Assert.IsNotNull(actual_encrypted_str);
            Assert.IsInstanceOfType(actual_encrypted_str, typeof(string));
            //Assert.ThrowsException<>()
            Assert.AreEqual(expected_encrypted_str, actual_encrypted_str, "Ошибка кодирования строки");
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Encode_Throw_ArgumentNullException_Test()
        {
            PasswordService.Encode(null, 1);
        }

        [TestMethod]
        public void Decode_234_123_Test()
        {
            var str = "234";
            var expected_decrypted_str = "123";
            var key = 1;

            var actual_decrypted_str = PasswordService.Decode(str, key);

            Assert.AreEqual(expected_decrypted_str, actual_decrypted_str);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Decode_Throw_ArgumentNullException_Test()
        {
            PasswordService.Decode(null, 1);
        }
    }
}
