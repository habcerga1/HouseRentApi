namespace HouseRentApi.Models.Users;

public class UserRoleContainer
{
    private UserRoleType _userRoleType;

    public UserRoleContainer(string userRoleType)
    {
        Enum.TryParse(userRoleType, true, out _userRoleType);
    }

    public bool CheckRole()
    {
        switch (_userRoleType)
        {
            case UserRoleType.Admin: return true;
            case UserRoleType.Agency: return true;
            case UserRoleType.Owner: return true;
            case UserRoleType.User: return true;
        }
        return false;
    }
}