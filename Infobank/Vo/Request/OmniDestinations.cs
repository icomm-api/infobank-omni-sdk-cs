using Newtonsoft.Json;

namespace Infobank.Vo.Request
{

    public class OmniDestinations
    {
        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("replaceWord",NullValueHandling = NullValueHandling.Ignore) ]
        public Dictionary<string, string>? ReplaceWords { get; set; }

        private OmniDestinations()
        {
            To = "";
        }

        public static OmniDestinationsBuilder Builder()
        {
            return new OmniDestinationsBuilder();
        }


        public class OmniDestinationsBuilder
        {
            private readonly OmniDestinations _destinations;

            public OmniDestinationsBuilder()
            {
                this._destinations = new OmniDestinations();
            }

            public OmniDestinationsBuilder(OmniDestinations destinations)
            {
                this._destinations = destinations;
                
            }

            public OmniDestinationsBuilder WithTo(string to)
            {
                _destinations.To = to;
                return this;
            }

            public OmniDestinationsBuilder WithReplaceWords(Dictionary<string, string> replaceWords)
            {
                _destinations.ReplaceWords = replaceWords;
                return this;
            }

            public OmniDestinations Build()
            {
                return _destinations;
            }

        }

    }

}