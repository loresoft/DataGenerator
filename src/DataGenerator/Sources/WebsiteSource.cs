using System;

namespace DataGenerator.Sources
{

    /// <summary>
    /// Website data source
    /// </summary>
    /// <seealso cref="DataGenerator.Sources.DataSourceMatchName" />
    public class WebsiteSource : DataSourceMatchName
    {
        private static readonly string[] _names = { "WebSite", "Url" };
        private static readonly Type[] _types = { typeof(string) };

        private static readonly string[] _domains = {
            "google.com", "facebook.com", "youtube.com", "yahoo.com",
            "live.com", "blogspot.com", "wikipedia.org", "twitter.com",
            "msn.com", "amazon.com", "linkedin.com.", "bing.com",
            "wordpress.com", "microsoft.com", "ebay.com", "paypal.com",
            "flickr.com", "craigslist.org", "imdb.com", "apple.com",
            "go.com", "ask.com", "cnn.com", "aol.com", "tumblr.com",
            "godaddy.com", "adobe.com", "about.com", "livejournal.com",
            "espn.go.com",
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="WebsiteSource"/> class.
        /// </summary>
        public WebsiteSource() : base(_types, _names)
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
            string domain = _domains[RandomGenerator.Current.Next(0, _domains.Length)];
            return $"http://www.{domain}";
        }

    }
}