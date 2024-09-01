namespace CS.Common.Enums
{
    public static class TypeEnumExtension
    {
        public static string GetFileNamePdf(this TypeEnum typeEnum)
        {
            switch (typeEnum)
            {
                case TypeEnum.Register:
                    return "Ghi";
                case TypeEnum.Return:
                    return "Tra";
                case TypeEnum.CardFee:
                    return "Mat";
                case TypeEnum.Recharged:
                    return "Nap";
                case TypeEnum.Lost:
                    return "Mat";
                default:
                    return "";
            }
        }

        public static string GetTitlePdf(this TypeEnum typeEnum)
        {
            switch (typeEnum)
            {
                case TypeEnum.Register:
                    return "PHÁT HÀNH THẺ MỚI";
                case TypeEnum.Return:
                    return "HOÀN TRẢ";
                case TypeEnum.CardFee:
                    return "MẤT THẺ";
                case TypeEnum.Recharged:
                    return "TẠM ỨNG";
                default:
                    return "";
            }
        }
    }
}