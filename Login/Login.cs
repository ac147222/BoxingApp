public static class PasswordValidater
{
    // Checks if the password is at least 8 characters and contains at least one letter, one number, and one symbol.
    public static bool IsValidPassword(string password)
    {
        if (password.Length < 8)
        {
            return false;
        }

        bool hasLetter = false;
        bool hasNumber = false;
        bool hasSymbol = false;

        foreach (char c in password)
        {
            if (char.IsLetter(c))
            {
                hasLetter = true;
            }
            else if (char.IsDigit(c))
            {
                hasNumber = true;
            }
            else
            {
                
                hasSymbol = true;
            }
        }

        if (!hasLetter)
        {
            return false;
        }
        else if (!hasNumber)
        {
            return false;
        }
        else if (!hasSymbol)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}