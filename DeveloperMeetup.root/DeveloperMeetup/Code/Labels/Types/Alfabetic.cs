using DeveloperMeetup.Code.Labels.Interfaces;

namespace DeveloperMeetup.Code.Labels.Types
{
    public class Alfabetic : ILabel
    {
        public string GetLabel(int position)
        {
            return ((char)('A' + (char)((position - 1) % 26))).ToString();
        }
    }
}
