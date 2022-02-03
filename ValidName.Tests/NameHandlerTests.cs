using Xunit;
using System;

namespace ValidName.Tests
{
    public class NameHandlerTests
    {
		[Theory]
		[InlineData("H. Wells")]
		[InlineData("H. G. Wells")]
		[InlineData("Herbert G. Wells")]
		[InlineData("Herbert George Wells")]
		public void Validate_ReceiveValidInput_ShouldResturnTrue(string str)
		{
			// Arrange and Act
			var expected = true;
			var actual = NameHandler.Validate(str);

			// Assert
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("Herbert")]
		[InlineData("Herbert W. G. Wells")]
		[InlineData("h. Wells")]
		[InlineData("herbert G. Wells")]
		[InlineData("H Wells")]
		[InlineData("Herb. Wells")]
		[InlineData("H. George Wells")]
		[InlineData("Herbert George W.")]
		public void Validate_ReceiveInvalidInput_ShouldReturnFalse(string str)
		{
			// Arrange and Act
			var expected = false;
			var actual = NameHandler.Validate(str);

			// Assert
			Assert.Equal(expected, actual);
		}
	}
}
