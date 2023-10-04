namespace LojaGames.Security
{
    public class Settings
    {
        
         private static string secret = "f376961ead290ce49389d1b9efff65f51fcb89be7c2e8c44bec7e421cd910331";

         public static string Secret { get => secret; set => secret = value; }
        
    }
}
