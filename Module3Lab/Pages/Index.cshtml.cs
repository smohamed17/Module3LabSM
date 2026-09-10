using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Module3Lab.Pages
{
    public class IndexModel : PageModel
    {
        // These properties aka variables hold the data that Index.cshtml will display
        // after the user submits the form. Getting will get the value
        // and set is setting the value. 
        public int HungerLevel { get; set; }
        public string HungerMessage { get; set; } = string.Empty;
        public string Recommendation { get; set; } = string.Empty;
        public string EncouragementMessage { get; set; } = string.Empty;
        public bool ShowResults { get; set; } = false;

        public void OnGet()
        {
            //this will run during the first process of using the webpage. 
            // using the void OnGet to publicly figure out which belongs to which. 
            // ex: like string belongs to HungerMessage or Recommendation. 
        }

        public void OnPost(int hungerLevel)
        {
            HungerLevel = hungerLevel;
            ShowResults = true;

            // using the value example of the theshold and results. 
            const int veryHungryThreshold = 9;
            const int somewhatHungryThreshold = 6;

           // using the if-elseif-else statement to figure out the hunger level 
           // and applying the proper message. 
            if (HungerLevel >= veryHungryThreshold)
            {
        
                HungerMessage = "You're super hungry. Order both tacos and burritos.";
            }
            else if (HungerLevel >= somewhatHungryThreshold)
            {
                // Runs when HungerLevel is submitted
                // We already know it's less than 10 here, or the first
                // condition above would have to match each other.
                HungerMessage = "You're moderately hungry. Go for a plate of tacos.";
            }
            else
            {
                // Runs for anything left over, which is HungerLevel 1 through 4
                HungerMessage = "You're not that hungry. Opt for a small burrito.";
            }

            // we are using Tenary Messaging to convey the recommendation. 
            Recommendation = (HungerLevel >= somewhatHungryThreshold) ? "Tacos" : "Burrito";

            // Using switch statements to figure things out. 
            // A switch compares HungerLevel against a list of specific
            // values. 
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
