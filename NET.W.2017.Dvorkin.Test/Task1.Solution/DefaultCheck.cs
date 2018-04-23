using System;
using System.Linq;

namespace Task1
{
    public class DefaultCheck : ICheck
    {
        public Tuple<bool, string> Check(string password)
        {
            // check if length more than 7 chars 
            if (password.Length <= 7)
                return Tuple.Create(false, $"{password} length too short");

            // check if length more than 10 chars for admins
            if (password.Length >= 15)
                return Tuple.Create(false, $"{password} length too long");

            // check if password contains at least one alphabetical character 
            if (!password.Any(char.IsLetter))
                return Tuple.Create(false, $"{password} hasn't alphanumerical chars");

            // check if password contains at least one digit character 
            if (!password.Any(char.IsNumber))
                return Tuple.Create(false, $"{password} hasn't digits");

            return Tuple.Create(true, "Password is Ok. User was created");
        }
    }
}