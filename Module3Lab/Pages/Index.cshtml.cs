using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Module3Lab.Pages
{
    public class IndexModel : PageModel
    {
        // These properties hold the data that Index.cshtml will display
        // after the user submits the form.
        public int HungerLevel { get; set; }
        public string HungerMessage { get; set; } = string.Empty;
        public string Recommendation { get; set; } = string.Empty;
        public string EncouragementMessage { get; set; } = string.Empty;
        public bool ShowResults { get; set; } = false;

        public void OnGet()
        {
            // This runs when the page first loads, before the user has
            // entered a hunger level. Nothing to do yet.
        }

        public void OnPost(int hungerLevel)
        {
            HungerLevel = hungerLevel;
            ShowResults = true;

            // We use two named thresholds instead of hardcoding
            // 8 and 5 directly in the if statement below. This makes the
            // conditions easier to read, and if you want to change what
            // counts as very hungry, you only have to change it in one place.
            const int veryHungryThreshold = 8;
            const int somewhatHungryThreshold = 5;

            // IF ELSE IF ELSE STATEMENT
            // C# checks each condition in order from top to bottom and
            // runs the first block that matches. Once one matches, it
            // skips the rest, even if a later condition would also be true.
            if (HungerLevel >= veryHungryThreshold)
            {
                // Runs when HungerLevel is 8, 9, or 10
                HungerMessage = "You're super hungry. Order both tacos and burritos.";
            }
            else if (HungerLevel >= somewhatHungryThreshold)
            {
                // Runs when HungerLevel is 5, 6, or 7
                // We already know it's less than 8 here, or the first
                // condition above would have matched instead.
                HungerMessage = "You're moderately hungry. Go for a plate of tacos.";
            }
            else
            {
                // Runs for anything left over, which is HungerLevel 1 through 4
                HungerMessage = "You're not that hungry. Opt for a small burrito.";
            }

            // TERNARY OPERATOR
            // This is a shorthand for a simple if else that only sets one
            // value. Read it as: if HungerLevel is 5 or more, Recommendation
            // becomes "Tacos". Otherwise it becomes "Burrito".
            Recommendation = (HungerLevel >= somewhatHungryThreshold) ? "Tacos" : "Burrito";

            // SWITCH STATEMENT
            // A switch compares HungerLevel against a list of specific
            // values. Grouping several case labels together, like the 7, 8,
            // and 9 lines below, means all of those values run the same
            // block of code. The break statement tells C# to stop checking
            // once it finds a match.
            switch (HungerLevel)
            {
                case 10:
                    EncouragementMessage = "You're a taco and burrito champion.";
                    break;

                case 9:
                case 8:
                case 7:
                    EncouragementMessage = "Taco plate time.";
                    break;

                case 6:
                case 5:
                case 4:
                    EncouragementMessage = "Small burrito it is.";
                    break;

                default:
                    // Catches everything not listed above, which is 1, 2, and 3
                    EncouragementMessage = "Maybe just grab a snack.";
                    break;
            }
        }
    }
}
