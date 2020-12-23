namespace OpenPokeLib.Experience
{
    public interface ILevelExperience
    {
        public int n { get; set; } //Level
        public int CalculateExperienceRequired();
    }
}