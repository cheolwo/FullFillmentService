using System.ComponentModel;

namespace IdentityCommon.Models.ForApplicationUser
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }

            return value.ToString();
        }
        public static string ToRoleString(this DomainRole role)
        {
            var memberInfo = typeof(DomainRole).GetMember(role.ToString());
            var descriptionAttribute = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;
            return descriptionAttribute?.Description;
        }
    }

    public enum DomainRole
    {
        [Description("조합장")]
        Chairman,

        [Description("창고장")]
        WarehouseManager,

        [Description("사용자")]
        User,

        [Description("관리자")]
        Admin,

        [Description("주문자")]
        Orderer
    }
}
