public static class PinValidator
{
    public static bool IsValidPin(string pin)
    {
        return pin.Length == 6 && pin.All(char.IsDigit);
    }
}