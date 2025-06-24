
namespace Infobank.Vo.Request
{
    public enum KakaoBizMsgCheckField
    {
        KAKAO_BIZ_MSG_BUTTON_TYPE,
        ALIM_TALK_MSG_TYPE,
        FRIEND_TALK_MSG_TYPE,
        BRAND_MESSAGE_MSG_TYPE,
        QUICK_REPLY_TYPE
    }


    public static class KakaoBizMsgFieldCheck
    {
        private static readonly Dictionary<KakaoBizMsgCheckField, Func<string, bool>> Validators = new()
        {
            { KakaoBizMsgCheckField.KAKAO_BIZ_MSG_BUTTON_TYPE, value => new List<string> { "WL", "AL", "BK", "MD", "DS", "BC", "BT", "AC", "BF" }.Contains(value) },
            { KakaoBizMsgCheckField.ALIM_TALK_MSG_TYPE, value => new List<string> { "AT", "AL" }.Contains(value) },
            { KakaoBizMsgCheckField.FRIEND_TALK_MSG_TYPE, value => new List<string> { "FT", "FI","FW", "FL", "FC", "FM","FA", "FP"  }.Contains(value) },
            { KakaoBizMsgCheckField.BRAND_MESSAGE_MSG_TYPE, value => new List<string> { "FT", "FI","FW", "FL", "FC", "FM","FA", "FP"  }.Contains(value) },
            { KakaoBizMsgCheckField.QUICK_REPLY_TYPE, value => new List<string> { "WL", "AL","BK","BC","BK","BT","BF" }.Contains(value) }
        };

        public static bool IsValid(this KakaoBizMsgCheckField check, string value)
        {
            if (Validators.ContainsKey(check))
            {
                return Validators[check](value);
            }
            return false;
        }

    }
}