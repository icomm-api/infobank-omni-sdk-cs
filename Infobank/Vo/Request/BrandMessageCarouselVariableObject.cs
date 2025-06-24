using Newtonsoft.Json;

namespace Infobank.Vo.Request
{
    public class BrandMessageCarouselVariableObject
    {
        [JsonProperty("message_variable")]
        public Dictionary<string, object>? MessageVariable { get; set; }

        [JsonProperty("button_variable")]
        public Dictionary<string, object>? ButtonVariable { get; set; }

        [JsonProperty("coupon_variable")]
        public Dictionary<string, object>? CouponVariable { get; set; }

        [JsonProperty("image_variable")]
        public List<BrandMessageImageVariableObject>? ImageVariable { get; set; }

        [JsonProperty("commerce_variable")]
        public Dictionary<string, object>? CommerceVariable { get; set; }

        public static BrandMessageCarouselVariableObjectBuilder Builder()
        {
            return new BrandMessageCarouselVariableObjectBuilder();
        }

        public class BrandMessageCarouselVariableObjectBuilder
        {
            private readonly BrandMessageCarouselVariableObject _request;

            public BrandMessageCarouselVariableObjectBuilder()
            {
                _request = new BrandMessageCarouselVariableObject();
            }
            
            public BrandMessageCarouselVariableObjectBuilder WithMessageVariable(Dictionary<string, object> messageVariable)
            {
                _request.MessageVariable = messageVariable;
                return this;
            }

            public BrandMessageCarouselVariableObjectBuilder WithButtonVariable(Dictionary<string, object> buttonVariable)
            {
                _request.ButtonVariable = buttonVariable;
                return this;
            }

            public BrandMessageCarouselVariableObjectBuilder WithCouponVariable(Dictionary<string, object> couponVariable)
            {
                _request.CouponVariable = couponVariable;
                return this;
            }

            public BrandMessageCarouselVariableObjectBuilder WithImageVariable(List<BrandMessageImageVariableObject> imageVariable)
            {
                _request.ImageVariable = imageVariable;
                return this;
            }

            public BrandMessageCarouselVariableObjectBuilder WithCommerceVariable(Dictionary<string, object> commerceVariable)
            {
                _request.CommerceVariable = commerceVariable;
                return this;
            }


            public BrandMessageCarouselVariableObject Build()
            {
                return _request;
            }
        }
    }
}