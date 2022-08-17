namespace ProjectRoseOfSharon.Business
{
    /// <summary>
    /// Bevat de minimum en maximum waarde voor een bepaald configuratieveld. 
    /// </summary>
    public struct ConfigItem
    {
        public int LowerBound;
        public int Upperbound;
        public int Default;
        public ConfigItem(int lower, int defaultValue, int upper)
        {
            LowerBound = lower;
            Upperbound = upper;
            Default = defaultValue;
        }
    }
}