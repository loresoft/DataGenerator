using System;
using System.Collections.Generic;
using System.Linq;
using DataGenerator.Extensions;

namespace DataGenerator.Sources
{
    public class LoremIpsumSource : DataSourceContainName
    {
        private static readonly Random _random = new Random();
        private static readonly string[] _names = { "Description", "Message", "Subject", "Note", "Comment", "Body" };
        private static readonly Type[] _types = { typeof(string) };
        private static readonly List<string> _words = new List<string>
        {
            "consetetur", "sadipscing", "elitr", "sed", "diam", "nonumy", "eirmod",
            "tempor", "invidunt", "ut", "labore", "et", "dolore", "magna", "aliquyam", "erat", "sed", "diam", "voluptua",
            "at", "vero", "eos", "et", "accusam", "et", "justo", "duo", "dolores", "et", "ea", "rebum", "stet", "clita",
            "kasd", "gubergren", "no", "sea", "takimata", "sanctus", "est", "lorem", "ipsum", "dolor", "sit", "amet",
            "lorem", "ipsum", "dolor", "sit", "amet", "consetetur", "sadipscing", "elitr", "sed", "diam", "nonumy", "eirmod",
            "tempor", "invidunt", "ut", "labore", "et", "dolore", "magna", "aliquyam", "erat", "sed", "diam", "voluptua",
            "at", "vero", "eos", "et", "accusam", "et", "justo", "duo", "dolores", "et", "ea", "rebum", "stet", "clita",
            "kasd", "gubergren", "no", "sea", "takimata", "sanctus", "est", "lorem", "ipsum", "dolor", "sit", "amet",
            "lorem", "ipsum", "dolor", "sit", "amet", "consetetur", "sadipscing", "elitr", "sed", "diam", "nonumy", "eirmod",
            "tempor", "invidunt", "ut", "labore", "et", "dolore", "magna", "aliquyam", "erat", "sed", "diam", "voluptua",
            "at", "vero", "eos", "et", "accusam", "et", "justo", "duo", "dolores", "et", "ea", "rebum", "stet", "clita",
            "kasd", "gubergren", "no", "sea", "takimata", "sanctus", "est", "lorem", "ipsum", "dolor", "sit", "amet", "duis",
            "autem", "vel", "eum", "iriure", "dolor", "in", "hendrerit", "in", "vulputate", "velit", "esse", "molestie",
            "consequat", "vel", "illum", "dolore", "eu", "feugiat", "nulla", "facilisis", "at", "vero", "eros", "et",
            "accumsan", "et", "iusto", "odio", "dignissim", "qui", "blandit", "praesent", "luptatum", "zzril", "delenit",
            "augue", "duis", "dolore", "te", "feugait", "nulla", "facilisi", "lorem", "ipsum", "dolor", "sit", "amet",
            "consectetuer", "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod", "tincidunt", "ut", "laoreet",
            "dolore", "magna", "aliquam", "erat", "volutpat", "ut", "wisi", "enim", "ad", "minim", "veniam", "quis",
            "nostrud", "exerci", "tation", "ullamcorper", "suscipit", "lobortis", "nisl", "ut", "aliquip", "ex", "ea",
            "commodo", "consequat", "duis", "autem", "vel", "eum", "iriure", "dolor", "in", "hendrerit", "in", "vulputate",
            "velit", "esse", "molestie", "consequat", "vel", "illum", "dolore", "eu", "feugiat", "nulla", "facilisis", "at",
            "vero", "eros", "et", "accumsan", "et", "iusto", "odio", "dignissim", "qui", "blandit", "praesent", "luptatum",
            "zzril", "delenit", "augue", "duis", "dolore", "te", "feugait", "nulla", "facilisi", "nam", "liber", "tempor",
            "cum", "soluta", "nobis", "eleifend", "option", "congue", "nihil", "imperdiet", "doming", "id", "quod", "mazim",
            "placerat", "facer", "possim", "assum", "lorem", "ipsum", "dolor", "sit", "amet", "consectetuer", "adipiscing",
            "elit", "sed", "diam", "nonummy", "nibh", "euismod", "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam",
            "erat", "volutpat", "ut", "wisi", "enim", "ad", "minim", "veniam", "quis", "nostrud", "exerci", "tation",
            "ullamcorper", "suscipit", "lobortis", "nisl", "ut", "aliquip", "ex", "ea", "commodo", "consequat", "duis",
            "autem", "vel", "eum", "iriure", "dolor", "in", "hendrerit", "in", "vulputate", "velit", "esse", "molestie",
            "consequat", "vel", "illum", "dolore", "eu", "feugiat", "nulla", "facilisis", "at", "vero", "eos", "et", "accusam",
            "et", "justo", "duo", "dolores", "et", "ea", "rebum", "stet", "clita", "kasd", "gubergren", "no", "sea",
            "takimata", "sanctus", "est", "lorem", "ipsum", "dolor", "sit", "amet", "lorem", "ipsum", "dolor", "sit",
            "amet", "consetetur", "sadipscing", "elitr", "sed", "diam", "nonumy", "eirmod", "tempor", "invidunt", "ut",
            "labore", "et", "dolore", "magna", "aliquyam", "erat", "sed", "diam", "voluptua", "at", "vero", "eos", "et",
            "accusam", "et", "justo", "duo", "dolores", "et", "ea", "rebum", "stet", "clita", "kasd", "gubergren", "no",
            "sea", "takimata", "sanctus", "est", "lorem", "ipsum", "dolor", "sit", "amet", "lorem", "ipsum", "dolor", "sit",
            "amet", "consetetur", "sadipscing", "elitr", "at", "accusam", "aliquyam", "diam", "diam", "dolore", "dolores",
            "duo", "eirmod", "eos", "erat", "et", "nonumy", "sed", "tempor", "et", "et", "invidunt", "justo", "labore",
            "stet", "clita", "ea", "et", "gubergren", "kasd", "magna", "no", "rebum", "sanctus", "sea", "sed", "takimata",
            "ut", "vero", "voluptua", "est", "lorem", "ipsum", "dolor", "sit", "amet", "lorem", "ipsum", "dolor", "sit",
            "amet", "consetetur", "sadipscing", "elitr", "sed", "diam", "nonumy", "eirmod", "tempor", "invidunt", "ut",
            "labore", "et", "dolore", "magna", "aliquyam", "erat", "consetetur", "sadipscing", "elitr", "sed", "diam",
            "nonumy", "eirmod", "tempor", "invidunt", "ut", "labore", "et", "dolore", "magna", "aliquyam", "erat", "sed",
            "diam", "voluptua", "at", "vero", "eos", "et", "accusam", "et", "justo", "duo", "dolores", "et", "ea",
            "rebum", "stet", "clita", "kasd", "gubergren", "no", "sea", "takimata", "sanctus", "est", "lorem", "ipsum"
        };
        private static readonly List<WeightedValue<string>> _punctuation = new List<WeightedValue<string>>
        {
            new WeightedValue<string>(".", 19),
            new WeightedValue<string>("?", 5),
            new WeightedValue<string>("!", 1)
        };


        public LoremIpsumSource() : this(100)
        {
        }

        public LoremIpsumSource(int wordCount) : base(_types, _names)
        {
            WordCount = wordCount;
        }


        public int WordCount { get; set; }


        public override object NextValue(IGenerateContext generateContext)
        {
            // get random words
            var words = new List<string> { "lorem", "ipsum", "dolor", "sit", "amet" };
            words.AddRange(_words.Random(WordCount - 5));

            // break into sentences
            var sentences = CreateSentences(words);

            // break into paragraphs
            var paragraphs = CreateParagraphs(sentences);

            var text = string.Join(Environment.NewLine + Environment.NewLine, paragraphs);
            return text;
        }


        private List<string> CreateSentences(IList<string> words)
        {
            var skip = 0;
            var sentences = new List<string>();

            while (skip < words.Count)
            {
                int remaining = words.Count - skip;

                // use all remaining if less than 20
                int take = remaining <= 20 ? remaining : _random.Next(8, 20);

                // if remaining after this is less than 3, use all
                if (words.Count - (skip + take) < 3)
                    take = remaining;

                var sentence = FormatSentence(words.Skip(skip).Take(take));

                sentences.Add(sentence);

                skip += take;
            }

            return sentences;
        }

        private List<string> CreateParagraphs(IList<string> sentences)
        {
            var skip = 0;
            var paragraphs = new List<string>();

            while (skip < sentences.Count)
            {
                int remaining = sentences.Count - skip;

                // use all remaining if less than 10
                int take = remaining <= 10 ? remaining : _random.Next(5, 10);

                // if remaining after this is less than 3, use all
                if (sentences.Count - (skip + take) < 3)
                    take = remaining;

                var sentence = FormatParagraph(sentences.Skip(skip).Take(take));

                paragraphs.Add(sentence);

                skip += take;
            }

            return paragraphs;
        }


        private string FormatSentence(IEnumerable<string> words)
        {
            string s = string.Join(" ", words);
            string p = _punctuation.Random(v => v.Weight).Value;
            return s.Substring(0, 1).ToUpperInvariant() + s.Substring(1) + p;
        }

        private string FormatParagraph(IEnumerable<string> sentences)
        {
            return string.Join("  ", sentences);
        }

    }
}