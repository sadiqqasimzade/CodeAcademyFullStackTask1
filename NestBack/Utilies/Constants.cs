namespace NestBack.Utilies
{
    public class Constants
    {
        public static string ProductImgPath = "";
        public static int ProductNameMaxLength = 20;
        public static int ProductImgMaxSizeInKb = 1024;

        public static string CategoryImgPath = "";
        public static int CategoryNameMaxLength = 20;
        public static int CategoryImgMaxSizeInKb= 1024;

        public static string SliderImgPath = "";
        public static int SliderNameMaxLength= 20;
        public static int SliderImgMaxSizeInKb = 1024;

        public enum UserRoles
        {
            Admin,
            Member,
            Moderator
        }
    }
}
