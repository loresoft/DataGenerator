using System;

namespace DataGenerator.Sources
{
    public class CompanySource : DataSourceMatchName
    {
        private static readonly Random _random = new Random();
        private static readonly string[] _names = new[] { "Company", "CompanyName" };
        private static readonly Type[] _types = { typeof(string) };
        private static readonly string[] _companies =
        {
            "Wal-Mart Stores", "Exxon Mobil", "Chevron", "Phillips ", "Berkshire Hathaway", "Apple",
            "General Motors", "General Electric", "Valero Energy", "Ford Motor", "AT&T", "Fannie Mae",
            "CVS Caremark", "McKesson", "Hewlett-Packard", "Verizon Communications", "UnitedHealth Group",
            "J.P. Morgan Chase & Co.", "Cardinal Health", "International Business Machines", "Bank of America Corp.",
            "Costco Wholesale", "Kroger", "Express Scripts Holding", "Wells Fargo", "Citigroup",
            "Archer Daniels Midland", "Procter & Gamble", "Prudential Financial", "Boeing", "Freddie Mac",
            "AmerisourceBergen", "Marathon Petroleum", "Home Depot", "Microsoft", "Target", "Walgreen",
            "American International Group", "INTL FCStone", "MetLife", "Johnson & Johnson", "Caterpillar",
            "PepsiCo", "State Farm Insurance Cos.", "ConocoPhillips", "Comcast", "WellPoint", "Pfizer",
            "Amazon.com", "United Technologies", "Dell", "Dow Chemical", "United Parcel Service", "Intel",
            "Google", "Lowe's", "Coca-Cola", "Merck", "Lockheed Martin", "Cisco Systems", "Best Buy",
            "Safeway", "FedEx", "Enterprise Products Partners", "Sysco", "Walt Disney", "Johnson Controls",
            "Goldman Sachs Group", "CHS", "Abbott Laboratories", "Sears Holdings", "DuPont", "Humana",
            "World Fuel Services", "Hess", "Ingram Micro", "Plains All American Pipeline", "Honeywell International",
            "United Continental Holdings", "Oracle", "Liberty Mutual Insurance Group", "HCA Holdings", "Delta Air Lines",
            "Aetna", "Deere", "Supervalu", "Sprint Nextel", "Mondelēz International", "New York Life Insurance",
            "American Express", "News Corp.", "Allstate", "Tyson Foods", "Massachusetts Mutual Life Insurance",
            "Tesoro", "Morgan Stanley", "TIAA-CREF", "General Dynamics", "Philip Morris International", "Nationwide"
        };


        public CompanySource() : base(_types, _names)
        {
        }

        public override object NextValue(IGenerateContext generateContext)
        {
            return _companies[_random.Next(0, _companies.Length)];
        }
    }
}