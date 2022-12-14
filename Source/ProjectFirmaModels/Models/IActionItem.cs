using System;

namespace ProjectFirmaModels.Models
{
    public interface IActionItem 
    {
        int ActionItemStateID { get; set; }
        //string ActionItemText { get; set; }
        int AssignedToPersonID { get; set; }
        DateTime AssignedOnDate { get; set; }
        DateTime DueByDate { get; set; }
        DateTime? CompletedOnDate { get; set; }
        //int? ProjectProjectStatusID { get; set; }

    }
}