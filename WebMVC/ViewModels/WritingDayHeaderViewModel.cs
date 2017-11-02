namespace WebMVC.ViewModels
{
    public class WritingDayHeaderViewModel
    {
        public int Id { get; set; }
        public int DayNumber { get; set; }
        public string HiddenQuote { get; set; }
        public int ExperienceReward { get; set; }
        public int RequiredWords { get; set; }
        public int WrittenWords { get; set; }
    }
}