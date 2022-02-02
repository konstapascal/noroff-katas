using System;
using Xunit;

namespace RgbaValidator.Tests
{
	public class RgbaHandlerTests
	{
		[Theory]
		[InlineData("rgb(0,0,0)")]
		[InlineData("rgb(255,255,255")]
		[InlineData("rgba(0,0,0,0)")]
		[InlineData("rgba(255,255,255,1)")]
		[InlineData("rgba(0,0,0,0.123456789)")]
		[InlineData("rgba(0,0,0,.8)")]
		[InlineData("rgba( 0 , 127, 255, 0.1)")]
		[InlineData("rgb(0%,50%,100%)")]
		public void ValidateString_ReceiveValidInput_ShouldReturnTrue(string str)
		{
			// Arrange and Act
			var expected = true;
			var actual = RgbaHandler.ValidateString(str);

			// Assert
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("rgb(0,,0)")]
		[InlineData("rgb (0,0,0)")]
		[InlineData("rgb(0,0,0,0)")]
		[InlineData("rgba(255,255,255,1)")]
		[InlineData("rgba(0,0,0)")]
		[InlineData("rgb(-1,0,0)")]
		[InlineData("rgb(255,256,255)")]
		[InlineData("rgb(100%,100%,101%)")]
		public void ValidateString_ReceiveInvalidInput_ShouldReturnFalse(string str)
		{
			// Arrange and Act
			var expected = false;
			var actual = RgbaHandler.ValidateString(str);

			// Assert
			Assert.Equal(expected, actual);
		}
	}
}
