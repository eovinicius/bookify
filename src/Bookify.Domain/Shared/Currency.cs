namespace Bookify.Domain.Shared;

public record Currency
{
    public string Code { get; init; }
    internal static readonly Currency None = new Currency("");
    public static readonly Currency USD = new Currency("USD");
    public static readonly Currency EUR = new Currency("EUR");
    public static readonly Currency BRL = new Currency("BRL");
    public static readonly IReadOnlyCollection<Currency> All = [USD, EUR, BRL];

    private Currency(string code)
    {
        Code = code;
    }

    public static Currency FromCode(string code)
    {
        return All.FirstOrDefault(c => c.Code == code) ?? throw new ArgumentException("Invalid currency code");
    }
};
