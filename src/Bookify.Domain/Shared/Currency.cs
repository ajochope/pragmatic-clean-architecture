namespace Bookify.Domain.Shared
{
    public record Currency
    {
        internal static readonly Currency None = new Currency(string.Empty);
        public static readonly Currency Usd = new Currency("USD");
        public static readonly Currency Eur = new Currency("EUR");
        private Currency(string code) => Code = code;
        public string Code { get; init; }
        public static Currency FromCode(string code)
        {
            return All.FirstOrDefault(x => x.Code == code) ?? throw new ApplicationException($"Currency with code {code} not found");
        }
        public static readonly IReadOnlyCollection<Currency> All = new List<Currency>
        {
            Usd,
            Eur
        };
    }
}