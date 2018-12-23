using System.Collections.Generic;

namespace MognetPlugin.Enum
{
    public class SuccessLevelEnum
    {
        public static readonly SuccessLevelEnum Clear = new SuccessLevelEnum(1, "Clear");
        public static readonly SuccessLevelEnum RanAway = new SuccessLevelEnum(2, "Ran Away");
        public static readonly SuccessLevelEnum Wipe = new SuccessLevelEnum(3, "Wipe");

        public int Code { get; }
        public string Name { get; }

        private SuccessLevelEnum(int code, string name)
        {
            this.Code = code;
            this.Name = name;
        }

        public static IEnumerable<SuccessLevelEnum> Values
        {
            get
            {
                yield return Clear;
                yield return RanAway;
                yield return Wipe;
            }
        }

        public static SuccessLevelEnum GetByCode(int code)
        {
            foreach (SuccessLevelEnum s in SuccessLevelEnum.Values)
            {
                if (s.Code == code)
                {
                    return s;
                }
            }

            return null;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public override bool Equals(object obj)
        {
            var item = obj as SuccessLevelEnum;

            if (item == null)
            {
                return false;
            }

            return this.Code.Equals(item.Code);
        }

        public override int GetHashCode()
        {
            return this.Code.GetHashCode();
        }
    }
}