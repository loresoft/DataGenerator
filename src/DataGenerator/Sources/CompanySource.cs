using System;

namespace DataGenerator.Sources
{
    /// <summary>
    /// Company data source generator
    /// </summary>
    /// <seealso cref="DataGenerator.Sources.DataSourceMatchName" />
    public class CompanySource : DataSourceMatchName
    {
        private static readonly string[] _names = { "Company", "CompanyName" };
        private static readonly Type[] _types = { typeof(string) };
        private static readonly string[] _companies =
        {
            "Wal-Mart Stores, Inc.", "Exxon Mobil Corporation", "ChevronTexaco Corporation", "General Electric Company", "Bank of America Corporation", "ConocoPhillips", "AT&T Corp", "Ford Motor Company", "J.P. Morgan Chase & Co",
            "Hewlett-Packard Company", "Berkshire Hathaway", "Citigroup Inc", "Verizon Communications", "McKesson Corporation", "General Motors Corporation", "American International Group", "Cardinal Health, Inc",
            "CVS Caremark", "Wells Fargo & Company", "International Business Machines Corporation", "United Health Group Inc", "Procter & Gamble Co", "The Kroger Co", "AmerisourceBergen Corporation", "Costco Wholesale Corp.",
            "Valero Energy Corp", "Archer-Daniels-Midland Company", "The Boeing Company", "Home Depot, Inc.", "Target Corporation", "WellPoint Health Networks", "Walgreen Company", "Johnson & Johnson", "State Farm Insurance",
            "Medco Health Solutions Inc", "Microsoft Corporation", "United Technologies Corporation", "Dell, Inc", "Goldman Sachs Group", "Pfizer Inc.", "Marathon Oil Corp.", "Lowe's Companies, Inc.", "United Parcel Service of America, Inc",
            "Lockheed Martin Corporation", "Best Buy Co., Inc.", "The Dow Chemical Company", "Supervalu Inc", "Sears Holdings Corporation", "International Assets Holding", "PepsiCo, Inc.", "MetLife, Inc.", "Safeway Inc.",
            "Kraft Foods", "Freddie Mac", "SYSCO Corporation", "Apple Computer, Inc", "The Walt Disney Company", "Cisco Systems, Inc.", "Comcast Corporation", "FedEx Corporation", "Northrop Grumman Corporation", "Intel Corporation",
            "Aetna Inc.", "New York Life Insurance Company", "Prudential Financial, Inc", "Caterpillar Inc.", "Sprint", "The Allstate Corporation", "General Dynamics Corporation", "Morgan Stanley", "Liberty Mutual",
            "The Coca-Cola Company", "Humana Inc.", "Honeywell International", "Abbott Laboratories", "News Corp", "HCA Inc.", "Sunoco Inc", "Amerada Hess Corporation", "Ingram Micro", "Fannie Mae", "Time Warner Inc.",
            "Johnson Controls, Inc.", "Delta Air Lines Inc", "Merck & Co Inc", "DuPont", "Tyson Foods Inc", "American Express Company", "Rite Aid Corporation", "TIAA-CREF", "CHS Inc", "Enterprise GP Holdings", "MassMutual Financial Group",
            "Philip Morris International", "Raytheon Company", "Express Scripts", "Hartford Financial Services Group", "Travelers Cos", "Publix Super Markets", "Amazon.com Inc.", "Staples, Inc.", "Google", "Macy's",
            "International Paper Company", "Oracle Corporation", "3M Company", "Deere & Company", "McDonald's Corporation", "Tech Data Corporation", "Motorola Inc", "Fluor Corporation", "Eli Lilly and Co", "Coca-Cola Enterprises",
            "Bristol-Myers Squibb Co.", "The Northwestern Mutual Life Insurance Company", "The Directv Group Inc", "Emerson Electric Co", "Nationwide Mutual Insurance Co", "TJX Companies, Inc.", "American Airlines - AMR",
            "U.S. Bancorp", "GMAC", "The PNC Financial Services Group", "Nike Inc.", "Murphy Oil Corp", "Kimberly-Clark Corp", "Alcoa", "Plains All American Pipeline, L. P.", "CIGNA Corporation", "AFLAC Incorporated",
            "Time Warner Cable", "United Services Automobile Association", "J.C. Penney Company, Inc.", "Exelon Corporation", "Kohl's Corporation", "Whirlpool Corporation", "Altria Group Inc", "Computer Sciences Corporation",
            "Tesoro Petroleum Corp", "UAL Corporation(United Airlines)", "Goodyear Tire & Rubber", "Avnet, Inc.", "Manpower Inc.", "Capital One Financial Corp", "Southern Company", "Health Net, Inc.", "FPL Group Inc",
            "L-3 Communications Hldgs.", "Constellation Energy Group", "Occidental Petroleum Corp", "Colgate-Palmolive", "Xerox Corporation", "Dominion Resources", "Freeport-McMoRan Copper & Gold", "General Mills, Inc.",
            "The AES Corporation", "Arrow Electronics, Inc.", "Halliburton Company", "Amgen Inc", "Medtronic, Inc.", "Progressive Corp.", "Gap, Inc.", "Smithfield Foods, Inc.", "Union Pacific Corp", "Loews Corporation",
            "EMC Corporation", "Burlington Northern Santa Fe Corporation", "Coventry Health Care, Inc", "Illinois Tool Works Inc.", "Viacom International Inc", "Toys R Us, Inc.", "American Electric Power", "PG&E Corporation",
            "Pepsi Bottling", "Consolidated Edison, Inc.", "Chubb Corporation", "CBS", "ConAgra Foods, Inc.", "FirstEnergy", "Sara Lee Corp", "Duke Energy Corporation", "National Oilwell Varco", "Continental Airlines, Inc",
            "Kellogg", "Baxter International Inc.", "Public Service Enterprise Group Incorporated", "Edison International", "Qwest Communications", "Aramark Corporation", "PPG Industries, Inc.", "Community Health Systems",
            "Office Depot, Inc.", "KBR", "Eaton Corporation", "Dollar General Corp", "Waste Management, Inc.", "Monsanto Company", "Omnicom Group Inc.", "Jabil Circuit", "DISH Network", "TRW Automotive Holdings Corp.",
            "Navistar International Corp", "Jacobs Engineering Group", "Sun Microsystems Inc.", "World Fuel Services Corp.", "Nucor Corporation", "Danaher Corporation", "Dean Foods Company", "ONEOK Inc", "Liberty Global",
            "United States Steel", "AutoNation, Inc.", "Marriott International Inc.", "ITT Industries, Inc.", "SAIC", "Yum! Brands, Inc.", "BB&T Corporation", "Cummins Inc", "Entergy Corporation", "Textron Inc.",
            "Marsh & McLennan Co's", "US Airways Inc", "Texas Instruments", "SunTrust Banks Inc", "Qualcomm Inc", "Land O'Lakes", "Liberty Media Corp", "Avon Products, Inc.", "Southwest Airlines Co.", "Parker Hannifin Corp",
            "Mosaic", "BJ's Wholesale Club, Inc.", "H.J. Heinz Company", "Fisher Scientific International Inc", "UnumProvident", "Genuine Parts", "Guardian Life of America", "Peter Kiewit Sons'", "Progress Energy",
            "R.R. Donnelley & Sons Company", "Starbucks Corporation", "Lear Corporation", "Baker Hughes", "Xcel Energy Inc", "Penske Automotive Group", "Energy Future Holdings", "Great Atlantic & Pacific Tea", "Fifth Third Bancorp",
            "State Street Corporation", "First Data Corp", "Pepco Holdings, Inc.", "URS", "Tenet Healthcare Corp.", "Regions Financial Corp.", "GameStop", "Lincoln National Corporation", "Genworth Financial", "XTO Energy",
            "CSX Corporation", "Anadarko Petroleum Corporation", "Devon Energy Corporation", "Praxair Inc", "NRG Energy", "Harrah's Entertainment Inc", "Automated Data Processing", "Principal Financial Group", "eBay",
            "Assurant Inc", "Limited Brands", "Nordstrom, Inc.", "Apache Corporation", "Reynolds American Inc", "Air Products and Chemicals Inc.", "Bank of New York Co.", "CenterPoint Energy Inc", "Williams Companies, Inc.",
            "Smith International, Inc.", "Republic Services", "Boston Scientific Corp.", "Sempra Energy", "Ashland", "PACCAR Inc", "Owens & Minor, Inc.", "Whole Foods Market, Inc.", "DTE Energy Company", "Discover Financial Services",
            "Norfolk Southern Corporation", "Ameriprise Financial", "Crown Holdings Inc.", "Icahn Enterprises", "Masco Corporation", "Cablevision Systems Corp.", "Huntsman", "Synnex", "Newmont Mining Corporation",
            "Chesapeake Energy", "Eastman Kodak Company", "Aon Corporation", "Campbell Soup Company", "PPL Corporation", "C.H. Robinson Worldwide", "Integrys Energy Group", "Quest Diagnostics Incorporated", "Western Digital",
            "Family Dollar Stores, Inc.", "Winn-Dixie Stores, Inc.", "Ball Corporation", "Estee Lauder Co.", "Shaw Group", "VF Corporation", "Darden Restaurants, Inc.", "Becton, Dickinson and Company", "OfficeMax Inc",
            "Bed Bath & Beyond Inc.", "Kinder Morgan Management LLC", "Ross Stores Inc", "Pilgrim's Pride Corp", "Hertz Global Holdings", "Sherwin-Williams Company", "Ameren Corporation", "Reinsurance Group of America",
            "Owens-Illinois, Inc.", "CarMax", "Gilead Sciences", "Precision Castparts", "Visa", "Commercial Metals Company", "WellCare Health Plans", "AutoZone, Inc.", "Western Refining", "Dole Food Company Inc",
            "Charter Communications", "Stryker Corporation", "Goodrich Corporation", "Visteon Corporation", "NiSource", "AGCO Corporation", "Calpine Corporation", "Henry Schein Inc", "Hormel Foods Corporation", "Affiliated Computer Services, Inc",
            "Thrivent Investment Management", "Yahoo", "American Family Insurance", "Sonic Automotive, Inc", "Peabody Energy", "Omnicare, Incorporated", "Dillard's Inc", "WW Grainger, Inc", "CMS Energy Corporation",
            "Fortune Brands Inc", "AECOM Technology", "Symantec", "SLM Corp", "DaVita", "KeyCorp", "MeadWestvaco Corp", "The Interpublic Group of Companies Inc", "Virgin Media", "MGM Mirage Inc", "The First American Corporation",
            "Avery Dennison Corporation", "The McGraw-Hill Companies", "Enbridge Energy Partners", "Ecolab Inc.", "Fidelity National Financial Inc", "Dover Corporation", "Global Partners", "UGI Corporation", "Gannett Co., Inc.",
            "Harris", "Barnes & Noble Inc", "Newell Rubbermaid Inc.", "Smurfit-Stone Container", "Pitney Bowes Inc", "CC Media Holdings", "EMCOR Group, Inc.", "Dr Pepper Snapple Group", "Weyerhaeuser Company", "SunGard Data Systems",
            "CH2M Hill", "Pantry", "Domtar", "The Clorox Company", "Northeast Utilities", "Oshkosh", "Mattel Inc", "Energy Transfer Equity", "Advance Auto Parts Inc", "Advanced Micro Devices, Inc.", "Corning Incorporated",
            "Mohawk Industries Inc", "PetSmart", "Reliance Steel & Aluminum", "Hershey Foods Corporation", "YRC Worldwide", "Dollar Tree", "Dana Holding", "Cameron International", "Nash Finch Company", "Pacific Life Insurance Co",
            "Terex Corporation", "Universal Health Services", "Amerigroup", "Sanmina-SCI Corporation", "Jarden", "Tutor Perini", "Mutual of Omaha", "Avis Budget Group", "Autoliv", "MasterCard", "Mylan", "Western Union",
            "Celanese", "Eastman Chemical Company", "Telephone & Data Systems", "Polo Ralph Lauren", "Auto-Owners Insurance", "Core-Mark Holding", "Western & Southern Financial Group", "Applied Materials, Inc", "Anixter International",
            "CenturyTel", "Atmos Energy", "Universal American", "Ryder System, Inc.", "SPX Corporation", "Foot Locker", "O'Reilly Automotive", "Harley-Davidson Inc", "Holly", "Owens Corning", "Micron Technology Inc",
            "EOG Resources", "Black & Decker Corp", "Big Lots Stores Inc", "Spectra Energy", "Starwood Hotels & Resorts", "United Stationers Inc.", "TravelCenters of America", "BlackRock", "Laboratory Corp. of America",
            "Health Management Associates", "NYSE Euronext", "St. Jude Medical", "Tenneco Automotive Inc.", "El Paso Corporation", "WESCO International, Inc.", "Consol Energy", "ArvinMeritor Inc", "NCR Corporation",
            "Unisys Corporation", "Lubrizol", "Alliant Techsystems", "Washington Post", "Las Vegas Sands", "Group 1 Automotive, Inc.", "Genzyme", "Allergan", "Broadcom", "Agilent Technologies Inc", "Rockwell Collins",
            "W.R. Berkley Corporation", "PepsiAmericas", "The Charles Schwab Corporation", "Dick's Sporting Goods", "FMC Technologies", "NII Holdings", "General Cable", "Graybar Electric Company, Inc.", "Biogen Idec",
            "AbitibiBowater", "Flowserve", "Airgas", "Conseco Inc", "Rockwell Automation", "Kindred Healthcare, Inc.", "American Financial Group", "Kelly Services", "Spectrum Group International", "RadioShack Corporation",
            "CA", "Con-way", "Erie Insurance", "Casey's General Stores", "Centene", "Sealed Air Corporation", "Frontier Oil", "SCANA Corporation", "Live Nation Entertainment", "Fiserv", "Host Hotels & Resorts", "H&R Block, Inc.",
            "Electronic Arts", "Franklin Resources", "Wisconsin Energy Corp", "Northern Trust Corp.", "MDU Resources Group", "CB Richard Ellis Group", "Blockbuster"
        };


        /// <summary>
        /// Initializes a new instance of the <see cref="CompanySource"/> class.
        /// </summary>
        public CompanySource() : base(_types, _names)
        {
        }

        /// <summary>
        /// Get a value from the data source.
        /// </summary>
        /// <param name="generateContext">The generate context.</param>
        /// <returns>
        /// A new value from the data source.
        /// </returns>
        public override object NextValue(IGenerateContext generateContext)
        {
            var i = RandomGenerator.Current.Next(0, _companies.Length);
            return _companies[i];
        }
    }
}