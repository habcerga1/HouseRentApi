namespace HouseRentApi.Sevices;

public static class CustomRoles
{
    public const string Admin = "Admin";
    public const string User = "User";
    public const string Owner = "Owner";
    public const string Agency = "Agency";

    public const string AutorizedUsers = $"{Admin},{User},{Owner},{Agency}";
}