using ListViewFilter.RibbonDefinitions;
using ListViewFilter.WebParts.SPListViewFilter;

namespace ListViewFilter
{
    public static class Ribbon
    {
        public static ContextualGroup[] GetContextualGroups(SPListViewFilter webPart)
        {
            return new[]
            {
                ContextualGroups.LibraryContextualGroup,
                ContextualGroups.ListContextualGroup,
                ContextualGroups.TasksContextualGroup,
                ContextualGroups.CalendarContextualGroup,
                ContextualGroups.TimeLineContextualGroup
            };
        }
    }
}