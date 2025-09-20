
using System;

namespace UserAccessCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inputs:
            string username = "testuser";
            string password = "longpasswordwith$ymbols";
            uint userId = 65537;

            // Outputs:
            bool userIsAdmin;
            bool usernameValid;
            bool passwordValid;

            // givet i opgaven:
            userIsAdmin = userId > 65536;
            usernameValid = username.Length >= 3;

            bool containsSpecialChar = password.Contains('$') || password.Contains('!') || password.Contains('@');
            bool lengthValid = userIsAdmin ? password.Length >= 20 : password.Length >= 16;
            passwordValid = containsSpecialChar && lengthValid;

            // Udskriver resultatet for at se om det virker
            Console.WriteLine($"Is user an admin? {userIsAdmin}");
            Console.WriteLine($"Is username valid? {usernameValid}");
            Console.WriteLine($"Is password valid? {passwordValid}");
        }
    }
}
