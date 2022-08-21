namespace AppServices.Human.Helpers;

public static class HumanHelper
{
    public static DateTime GetNextBirthday(DateTime birthday)
    {
        DateTime nextBirthday = birthday.AddYears(DateTime.Today.Year - birthday.Year);
        nextBirthday = nextBirthday.AddYears(DateTime.Today > nextBirthday ? 1 : 0);

        return nextBirthday;
    }
}