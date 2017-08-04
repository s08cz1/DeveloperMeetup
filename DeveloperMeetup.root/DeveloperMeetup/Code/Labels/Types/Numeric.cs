using DeveloperMeetup.Code.Labels.Interfaces;

namespace DeveloperMeetup.Code.Labels.Types
{
    public class Numeric : ILabel
    {
        public string GetLabel(int position)
        {
            return position.ToString();
        }
    }
}
