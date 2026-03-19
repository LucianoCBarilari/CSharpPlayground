using CSharpPlayground.Slices.TestingDojo.Level05Stateful;
using Xunit;

namespace CSharpPlayground.Tests;

public class CartServiceShould
{
    [Fact]
    public void CartServices_ShouldSucced_AddingItem() 
    {

        CartService cartService = new CartService();

        cartService.AddItem("prod01", 1, 10);

        Assert.Single(cartService.Lines);

        var prod = cartService.Lines.First();

        Assert.Equal("prod01", prod.Sku);
        Assert.Equal(1, prod.Quantity);
        Assert.Equal(10, prod.UnitPrice);
    }
    [Theory]
    [MemberData(nameof(InvalidAddItemCases))]
    public void AddItem_WhenInputIsInvalid_ThrowsExpectedException(
      string sku,
      int quantity,
      decimal unitPrice,
      Type exceptionType)
    {
        var cartService = new CartService();

        var action = () => cartService.AddItem(sku, quantity, unitPrice);

        Assert.Throws(exceptionType, action);
    }
    [Fact]
    public void AddItem_WhenSkuAlreadyExists_IncrementsQuantity()
    {
        var cartService = new CartService();

        cartService.AddItem("prod01", 1, 10m);
        cartService.AddItem("prod01", 1, 10m);

        var prod = Assert.Single(cartService.Lines);

        Assert.Equal("prod01", prod.Sku);
        Assert.Equal(2, prod.Quantity);
        Assert.Equal(10m, prod.UnitPrice);
    }
    [Fact]
    public void RemoveItem_WhenCartHasTwoItems_KeepsOnlyRemainingItem()
    {
        var cartService = new CartService();

        cartService.AddItem("prod01", 1, 10m);
        cartService.AddItem("prod02", 1, 10m);

        cartService.RemoveItem("prod02");
        var prod = Assert.Single(cartService.Lines);

        Assert.Equal("prod01", prod.Sku);
        Assert.Equal(1, prod.Quantity);
        Assert.Equal(10m, prod.UnitPrice);
    }
    [Theory]
    [InlineData(-0.1,typeof(ArgumentOutOfRangeException))]
    [InlineData(0.95, typeof(ArgumentOutOfRangeException))]
    public void ApplyPercentDiscount_WhenInputExceedsLimits_ThrowsException(decimal discount,Type expectedException) 
    {
        CartService cartService = new();

        Assert.Throws(expectedException, () => cartService.ApplyPercentDiscount(discount));
    }
    [Fact]
    public void GetSubtotal_ShouldSucced()
    {
        CartService cartService = new();

        cartService.AddItem("prod00", 1, 10);
        cartService.AddItem("prod01", 2, 45);
        cartService.AddItem("prod03", 1, 20);
        
        Assert.Equal(120, cartService.GetSubtotal());
    }

    public static TheoryData<string, int, decimal, Type> InvalidAddItemCases => new()
      {
          { "", 1, 10m, typeof(ArgumentException) },
          { "prod01", -1, 10m, typeof(ArgumentOutOfRangeException) },
          { "prod01", 1, -10m, typeof(ArgumentOutOfRangeException) }
      }; 
}
