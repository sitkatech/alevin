﻿/*-----------------------------------------------------------------------
<copyright file="ConfirmDialogFormViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System;

namespace ProjectFirma.Web.Views.Shared
{
    public class ConfirmDialogFormViewData
    {
        public readonly string ConfirmMessage;
        public readonly bool CanProceed;

        public ConfirmDialogFormViewData(string confirmMessage) : this(confirmMessage, true)
        {
        }

        public ConfirmDialogFormViewData(string confirmMessage, bool canProceed)
        {
            ConfirmMessage = confirmMessage;
            CanProceed = canProceed;
        }

        public static string GetStandardCannotDeleteMessage(string objectName)
        {
            return $"You can't delete this {objectName} because it has associations to other items.";
        }

        public static string GetStandardCannotDeleteMessage(string objectName, string linkToObjectSummaryPage)
        {
            return $"You can't delete this {objectName} because it has associations to other items. <span>Click {linkToObjectSummaryPage} to view it.</span>";
        }

        public static string GetStandardCannotDeletePersonMessage(string objectName, string linkToObjectSummaryPage)
        {
            return $"<p>You can't delete this {objectName} because it is associated with important items in the system.<p>" +
                   $"<p>If the {objectName} no longer needs access to this system, you can inactivate their account from their {linkToObjectSummaryPage}.";
        }
    }
}
