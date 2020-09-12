using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Brka.Bank.Lib.WebApi;
using FluentAssertions;
using Xunit;

namespace Brka.Bank.Contas.Unit.Test
{
    public class BusinessExceptionTest
    {
        [Fact]
        public void Test_BusinessException_Without_Custom_Properties()
        {
            // Arrange
            Exception ex = new BusinessException("Message", new Exception("Inner exception."));
            string exceptionToString = ex.ToString();
            
            // Act
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, ex);
                ms.Seek(0, 0);
                ex = (BusinessException)bf.Deserialize(ms);
            }

            // Assert
            exceptionToString.Should().Be(ex.ToString());
        }
    }
}