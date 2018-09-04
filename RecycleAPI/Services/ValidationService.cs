using Microsoft.EntityFrameworkCore.Internal;

namespace RecycleAPI.Services
{
    public class ValidationService
    {

        private static readonly string[] _states =
        {
            "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA",
            "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD",
            "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ",
            "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC",
            "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY",
            "DC", "AS", "GU", "MP", "PR", "UM", "VI"
        };

        public static bool IsValidState(string state)
        {
            if (string.IsNullOrEmpty(state))
                return false;

            return _states.IndexOf(state) > -1;
        }
    }
}
