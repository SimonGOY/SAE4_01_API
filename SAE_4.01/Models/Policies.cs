using Microsoft.AspNetCore.Authorization;

public class Policies
{
    public const string Type0 = "0";
    public static AuthorizationPolicy Type0Policy()
    {
        return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Type0).Build();
    }

    public const string Type1 = "1";
    public static AuthorizationPolicy Type1Policy()
    {
        return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Type1).Build();
    }

    public const string Type2 = "2";
    public static AuthorizationPolicy Type2Policy()
    {
        return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Type2).Build();
    }
}