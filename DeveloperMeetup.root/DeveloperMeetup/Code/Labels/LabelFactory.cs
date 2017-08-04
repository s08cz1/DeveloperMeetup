using DeveloperMeetup.Code.Labels.Enums;
using DeveloperMeetup.Code.Labels.Interfaces;
using DeveloperMeetup.Code.Labels.Types;

namespace DeveloperMeetup.Code.Labels
{
    /// <summary>
    /// Produces relevant label generator
    /// </summary>
    public class LabelFactory
    {
        public static ILabel GetLabelGenerator(LabelType type)
        {
            switch (type)
            {
                case LabelType.Alfabetic:
                    return new Alfabetic();
                case LabelType.RomanNumeral:
                    return new RomanNumeral();
                default:
                    return new Numeric();
            }
        }
    }
}
