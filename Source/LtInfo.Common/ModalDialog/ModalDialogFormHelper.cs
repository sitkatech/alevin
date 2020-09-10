﻿/*-----------------------------------------------------------------------
<copyright file="ModalDialogFormHelper.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
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
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using LtInfo.Common.BootstrapWrappers;

namespace LtInfo.Common.ModalDialog
{
    public static class ModalDialogFormHelper
    {
        public const string SaveButtonID = "ltinfo-modal-dialog-save-button-id";
        public const string HiddenSaveButtonID = "hidden-save-button";
        public const int DefaultDialogWidth = 800;

        public enum DisabledState
        {
            Disabled,
            NotDisabled
        }

        /// <summary>
        ///  Creates a link that will open a jQuery UI dialog form.
        /// </summary>
        /// <param name="linkText">The inner text of the anchor element</param>
        /// <param name="dialogContentUrl">The url that will return the content to be loaded into the dialog window</param>
        /// <param name="dialogTitle">The title to be displayed in the dialog window</param>
        /// <param name="dialogWidth">width in pixels of dialog</param>
        /// <param name="saveButtonText">Text for the save button</param>
        /// <param name="cancelButtonText">Text for the cancel button</param>
        /// <param name="extraCssClasses">Any extra css classes for the button</param>
        /// <param name="onJavascriptReadyFunction">Optional javascript function to run when dialog is loaded</param>
        /// <param name="postData">Optional; if provided, will switch the dialog load to a POST from a GET</param>
        /// <returns></returns>
        public static HtmlString ModalDialogFormLink(string linkText,
            string dialogContentUrl,
            string dialogTitle,
            int? dialogWidth,
            string saveButtonText,
            string cancelButtonText,
            List<string> extraCssClasses,
            string onJavascriptReadyFunction,
            string postData)
        {
            return ModalDialogFormLink(null,
                linkText,
                dialogContentUrl,
                dialogTitle,
                dialogWidth,
                SaveButtonID,
                saveButtonText,
                cancelButtonText,
                extraCssClasses,
                onJavascriptReadyFunction,
                postData,
                null,
                null,
                false,
                DisabledState.NotDisabled);
        }

        /// <summary>
        ///  Creates a link that will open a jQuery UI dialog form.
        /// </summary>
        /// <param name="linkText">The inner text of the anchor element</param>
        /// <param name="dialogContentUrl">The url that will return the content to be loaded into the dialog window</param>
        /// <param name="dialogTitle">The title to be displayed in the dialog window</param>
        /// <param name="dialogWidth">width in pixels of dialog</param>
        /// <param name="saveButtonText">Text for the save button</param>
        /// <param name="cancelButtonText">Text for the cancel button</param>
        /// <param name="extraCssClasses">Any extra css classes for the button</param>
        /// <param name="onJavascriptReadyFunction">Optional javascript function to run when dialog is loaded</param>
        /// <param name="postData">Optional; if provided, will switch the dialog load to a POST from a GET</param>
        /// <param name="skipAjax"></param>
        /// <returns></returns>
        public static HtmlString ModalDialogFormLink(string linkText,
            string dialogContentUrl,
            string dialogTitle,
            int? dialogWidth,
            string saveButtonText,
            string cancelButtonText,
            List<string> extraCssClasses,
            string onJavascriptReadyFunction,
            string postData,
            bool skipAjax)
        {
            return ModalDialogFormLink(null,
                linkText,
                dialogContentUrl,
                dialogTitle,
                dialogWidth,
                SaveButtonID,
                saveButtonText,
                cancelButtonText,
                extraCssClasses,
                onJavascriptReadyFunction,
                postData,
                null,
                null,
                skipAjax,
                DisabledState.NotDisabled);
        }

        /// <summary>
        ///  Creates a link that will open a jQuery UI dialog form.
        /// </summary>
        /// <param name="linkText">The inner text of the anchor element</param>
        /// <param name="dialogContentUrl">The url that will return the content to be loaded into the dialog window</param>
        /// <param name="dialogTitle">The title to be displayed in the dialog window</param>
        /// <param name="dialogWidth">width in pixels of dialog</param>
        /// <param name="saveButtonText">Text for the save button</param>
        /// <param name="cancelButtonText">Text for the cancel button</param>
        /// <param name="extraCssClasses">Any extra css classes for the button</param>
        /// <param name="onJavascriptReadyFunction">Optional javascript function to run when dialog is loaded</param>
        /// <param name="postData">Optional; if provided, will switch the dialog load to a POST from a GET</param>
        /// <param name="disabledState">Optional; if provided, will switch the dialog load to a POST from a GET</param>
        /// <param name="hoverText">Optional; if provided, will switch the dialog load to a POST from a GET</param>
        /// <returns></returns>
        public static HtmlString ModalDialogFormLink(string linkText,
            string dialogContentUrl,
            string dialogTitle,
            int? dialogWidth,
            string saveButtonText,
            string cancelButtonText,
            List<string> extraCssClasses,
            string onJavascriptReadyFunction,
            string postData,
            DisabledState disabledState,
            string hoverText
            )
        {
            return ModalDialogFormLink(null,
                linkText,
                dialogContentUrl,
                dialogTitle,
                dialogWidth,
                SaveButtonID,
                saveButtonText,
                cancelButtonText,
                extraCssClasses,
                onJavascriptReadyFunction,
                postData,
                null,
                hoverText,
                false,
                disabledState);
        }

        /// <summary>
        ///  Creates a link that will open a jQuery UI dialog form.
        /// </summary>
        /// <param name="linkID">Optional LinkID to be able to access it later on the page</param>
        /// <param name="linkText">The inner text of the anchor element</param>
        /// <param name="dialogContentUrl">The url that will return the content to be loaded into the dialog window</param>
        /// <param name="dialogTitle">The title to be displayed in the dialog window</param>
        /// <param name="dialogWidth">width in pixels of dialog</param>
        /// <param name="cancelButtonText">Text for the cancel button</param>
        /// <param name="extraCssClasses">Any extra css classes for the button</param>
        /// <returns></returns>
        public static HtmlString ModalDialogFormLinkHiddenSave(
            string linkID,
            string linkText,
            string dialogContentUrl,
            string dialogTitle,
            int? dialogWidth,
            string cancelButtonText,
            List<string> extraCssClasses)
        {
            return ModalDialogFormLink(linkID,
                linkText,
                dialogContentUrl,
                dialogTitle,
                dialogWidth,
                HiddenSaveButtonID,
                null,
                cancelButtonText,
                extraCssClasses,
                null,
                null,
                null,
                null,
                false,
                DisabledState.NotDisabled);
        }

        /// <summary>
        ///     Creates a link that will open a jQuery UI dialog form.
        ///     Adds additional parameters controlling button IDs if needed.
        /// </summary>
        /// <param name="linkID">Optional LinkID to be able to access it later on the page</param>
        /// <param name="linkText">The inner text of the anchor element</param>
        /// <param name="dialogContentUrl">The url that will return the content to be loaded into the dialog window</param>
        /// <param name="dialogTitle">The title to be displayed in the dialog window</param>
        /// <param name="dialogWidth">width in pixels of dialog</param>
        /// <param name="saveButtonID">ID for the save button for later reference by jQuery, etc. Take care to make unique!</param>
        /// <param name="saveButtonText">Text for the save button</param>
        /// <param name="cancelButtonText">Text for the cancel button</param>
        /// <param name="extraCssClasses">Any extra css classes for the button</param>
        /// <param name="onJavascriptReadyFunction">Optional javascript function to run when dialog is loaded</param>
        /// <param name="postData">Optional; if provided, will switch the dialog load to a POST from a GET</param>
        /// <param name="optionalDialogFormID"></param>
        /// <returns></returns>
        public static HtmlString ModalDialogFormLink(string linkID,
            string linkText,
            string dialogContentUrl,
            string dialogTitle,
            int? dialogWidth,
            string saveButtonID,
            string saveButtonText,
            string cancelButtonText,
            List<string> extraCssClasses,
            string onJavascriptReadyFunction,
            string postData,
            string optionalDialogFormID)
        {
            return ModalDialogFormLink(linkID, linkText, dialogContentUrl, dialogTitle, dialogWidth, saveButtonID,
                saveButtonText, cancelButtonText, extraCssClasses, onJavascriptReadyFunction, postData,
                optionalDialogFormID, null, false, DisabledState.NotDisabled);
        }


        public static HtmlString ModalDialogFormLink(string linkID,
            string linkText,
            string dialogContentUrl,
            string dialogTitle,
            int? dialogWidth,
            string saveButtonID,
            string saveButtonText,
            string cancelButtonText,
            List<string> extraCssClasses,
            string onJavascriptReadyFunction,
            string postData,
            string optionalDialogFormID,
            string hoverText,
            DisabledState disabledState)
        {
            return ModalDialogFormLink(linkID, linkText, dialogContentUrl, dialogTitle, dialogWidth, saveButtonID,
                saveButtonText, cancelButtonText, extraCssClasses, onJavascriptReadyFunction, postData,
                optionalDialogFormID, hoverText, false, disabledState);
        }


        /// <summary>
            ///     Creates a link that will open a jQuery UI dialog form.
            ///     Adds additional parameters controlling button IDs if needed.
            /// </summary>
            /// <param name="linkID">Optional LinkID to be able to access it later on the page</param>
            /// <param name="linkText">The inner text of the anchor element</param>
            /// <param name="dialogContentUrl">The url that will return the content to be loaded into the dialog window</param>
            /// <param name="dialogTitle">The title to be displayed in the dialog window</param>
            /// <param name="dialogWidth">width in pixels of dialog</param>
            /// <param name="saveButtonID">ID for the save button for later reference by jQuery, etc. Take care to make unique!</param>
            /// <param name="saveButtonText">Text for the save button</param>
            /// <param name="cancelButtonText">Text for the cancel button</param>
            /// <param name="extraCssClasses">Any extra css classes for the button</param>
            /// <param name="onJavascriptReadyFunction">Optional javascript function to run when dialog is loaded</param>
            /// <param name="postData">Optional; if provided, will switch the dialog load to a POST from a GET</param>
            /// <param name="optionalDialogFormID"></param>
            /// <param name="hoverText"></param>
            /// <param name="skipAjax"></param>
            /// <param name="disabledState"></param>
            /// <returns></returns>
            public static HtmlString ModalDialogFormLink(string linkID,
            string linkText,
            string dialogContentUrl,
            string dialogTitle,
            int? dialogWidth,
            string saveButtonID,
            string saveButtonText,
            string cancelButtonText,
            List<string> extraCssClasses,
            string onJavascriptReadyFunction,
            string postData,
            string optionalDialogFormID,
            string hoverText,
            bool skipAjax,
            DisabledState disabledState)
        {
            var builder = new TagBuilder("a");
            builder.InnerHtml += linkText;
            if (!string.IsNullOrWhiteSpace(linkID))
            {
                builder.Attributes.Add("id", linkID);
            }
            
            if (disabledState == DisabledState.NotDisabled)
            {
                builder.Attributes.Add("href", dialogContentUrl);
            }
            else
            {
                builder.Attributes.Add("href", "javascript:void(0);");
                builder.Attributes.Add("style", "cursor: not-allowed;opacity: .5; ");
            }

            builder.Attributes.Add("data-dismiss", "modal");
            builder.Attributes.Add("data-dialog-title", dialogTitle);
            builder.Attributes.Add("data-dialog-width", dialogWidth.ToString());

            if (!string.IsNullOrWhiteSpace(saveButtonID))
            {
                builder.Attributes.Add("data-save-button-id", saveButtonID);
            }
            builder.Attributes.Add("data-save-button-text", saveButtonText);
            builder.Attributes.Add("data-cancel-button-text", cancelButtonText);


            if (!string.IsNullOrWhiteSpace(optionalDialogFormID))
            {
                builder.Attributes.Add("data-optional-dialog-form-id", optionalDialogFormID);
            }

            builder.Attributes.Add("data-skip-ajax", skipAjax.ToString());

            var javascripReadyFunctionAsParameter = !string.IsNullOrWhiteSpace(onJavascriptReadyFunction) ? $"function() {{{onJavascriptReadyFunction}();}}" : "null";
            var postDataAsParameter = !string.IsNullOrWhiteSpace(postData) ? postData : "null";
            var onclickFunction = $"return modalDialogLink(this, {javascripReadyFunctionAsParameter}, {postDataAsParameter});";
            
            if (disabledState == DisabledState.NotDisabled)
            {
                builder.Attributes.Add("onclick", onclickFunction);
            }

            if (extraCssClasses != null)
            {
                foreach (var extraCssClass in extraCssClasses)
                {
                    builder.AddCssClass(extraCssClass);
                }
            }

            if (!string.IsNullOrWhiteSpace(hoverText))
            {
                builder.Attributes.Add("title", hoverText);
            }

            return new HtmlString(builder.ToString());
        }

        public static HtmlString ModalDialogFormLink(string linkText, string dialogUrl, string dialogTitle, List<string> extraCssClasses, bool hasPermission)
        {
            return hasPermission ? ModalDialogFormLink(linkText, dialogUrl, dialogTitle, DefaultDialogWidth, "Save", "Cancel", extraCssClasses, null, null) : new HtmlString(string.Empty);
        }

        public static HtmlString MakeConfirmDialogLink(string linkText, string dialogUrl, string dialogTitle, List<string> extraCssClasses, bool hasPermission)
        {
            return hasPermission ? ModalDialogFormLink(linkText, dialogUrl, dialogTitle, DefaultDialogWidth, "Confirm", "Cancel", extraCssClasses, null, null) : new HtmlString(string.Empty);
        }

        public static HtmlString MakeConfirmDialogLink(string linkText, string dialogUrl, string dialogTitle, string saveButtonText, List<string> extraCssClasses, bool hasPermission)
        {
            return hasPermission ? ModalDialogFormLink(linkText, dialogUrl, dialogTitle, DefaultDialogWidth, saveButtonText, "Cancel", extraCssClasses, null, null) : new HtmlString(string.Empty);
        }

        public static HtmlString ModalDialogFormLink(string linkText, string dialogUrl, string dialogTitle, int dialogWidth, bool hasPermission, string dialogFormID)
        {
            return hasPermission
                ? ModalDialogFormLink(null, linkText, dialogUrl, dialogTitle, dialogWidth, SaveButtonID, "Save", "Cancel", new List<string>(), null, null, dialogFormID, null, false, DisabledState.NotDisabled)
                : new HtmlString(string.Empty);
        }

        public static HtmlString MakeDeleteLink(string linkText, string deleteDialogUrl, List<string> extraCssClasses, bool userHasDeletePermission)
        {
            return userHasDeletePermission ? ModalDialogFormLink(linkText, deleteDialogUrl, "Confirm Delete", 500, "Delete", "Cancel", extraCssClasses, null, null) : new HtmlString(string.Empty);
        }

        public static HtmlString MakeEditIconLink(string dialogUrl, string dialogTitle, bool hasPermission)
        {
            return MakeEditIconLink(dialogUrl, dialogTitle, DefaultDialogWidth, hasPermission, null);
        }
        /// <summary>
        /// Magnifying glass
        /// </summary>
        public static HtmlString MakeInfoIconLink(string dialogUrl, string dialogTitle, bool hasPermission)
        {
            return MakeInfoIconLink(dialogUrl, dialogTitle, DefaultDialogWidth, hasPermission);
        }

        public static HtmlString MakeDeleteIconLink(string dialogUrl, string dialogTitle, bool hasPermission)
        {
            return MakeDeleteIconLink(dialogUrl, dialogTitle, DefaultDialogWidth, hasPermission);
        }

        public static HtmlString MakeDeleteIconLink(string dialogUrl, string dialogTitle, int width, bool hasPermission)
        {
            return hasPermission ? ModalDialogFormLink(null, BootstrapHtmlHelpers.MakeGlyphIconWithScreenReaderOnlyText("glyphicon-trash blue", dialogTitle).ToString(), dialogUrl, dialogTitle, width, SaveButtonID, "Delete", "Cancel", new List<string>(), null, null, null) : new HtmlString(string.Empty);
        }

        public static HtmlString MakeEditIconLink(string dialogUrl, string dialogTitle, bool hasPermission, string optionalDialogFormID)
        {
            return MakeEditIconLink(dialogUrl, dialogTitle, DefaultDialogWidth, hasPermission, optionalDialogFormID);
        }

        public static HtmlString MakeEditIconLink(string dialogUrl, string dialogTitle, int dialogWidth, bool hasPermission)
        {
            return MakeEditIconLink(dialogUrl, dialogTitle, dialogWidth, hasPermission, null);
        }

        public static HtmlString MakeEditIconLink(string dialogUrl, string dialogTitle, int width, bool hasPermission, string optionalDialogFormID)
        {
            return hasPermission ? ModalDialogFormLink(null, BootstrapHtmlHelpers.MakeGlyphIconWithScreenReaderOnlyText("glyphicon-edit blue", dialogTitle).ToString(), dialogUrl, dialogTitle, width, SaveButtonID, "Save", "Cancel", new List<string>(), null, null, optionalDialogFormID) : new HtmlString(string.Empty);
        }

        /// <summary>
        ///  Magnifying glass
        /// </summary>
        public static HtmlString MakeInfoIconLink(string dialogUrl, string dialogTitle, int width, bool hasPermission)
        {
              return hasPermission ? ModalDialogFormLink(null, BootstrapHtmlHelpers.MakeGlyphIconWithScreenReaderOnlyText("glyphicon-search gi-1x blue", dialogTitle).ToString(), dialogUrl, dialogTitle, width, HiddenSaveButtonID, "NotARealSaveButton", "Close", new List<string>(), null, null, null) : new HtmlString(string.Empty);
        }

        public static HtmlString MakeNewIconButton(string dialogUrl, string dialogTitle, bool hasPermission)
        {
            return hasPermission ? ModalDialogFormLink($"{BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-plus")} {dialogTitle}", dialogUrl, dialogTitle, DefaultDialogWidth, "Save", "Cancel", new List<string> { "btn", "btn-firma" }, null, null) : new HtmlString(string.Empty);
        }

        public static HtmlString MakeNewIconButton(string dialogUrl, string dialogTitle, int width, bool hasPermission)
        {
            return hasPermission ? ModalDialogFormLink($"{BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-plus")} {dialogTitle}", dialogUrl, dialogTitle, width, "Save", "Cancel", new List<string> { "btn", "btn-firma" }, null, null) : new HtmlString(string.Empty);
        }

        public static HtmlString MakeDeleteIconButton(string dialogUrl, string dialogTitle, bool hasPermission)
        {
            return hasPermission ? ModalDialogFormLink($"{BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-trash")} {dialogTitle}", dialogUrl, dialogTitle, DefaultDialogWidth, "Delete", "Cancel", new List<string> { "btn", "btn-firma" }, null, null) : new HtmlString(string.Empty);
        }

        public static HtmlString MakeNewIconButton(string dialogUrl, string linkText, string dialogTitle, bool hasPermission)
        {
            return hasPermission ? ModalDialogFormLink($"{BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-plus")} {linkText}", dialogUrl, dialogTitle, DefaultDialogWidth, "Save", "Cancel", new List<string> { "btn", "btn-firma" }, null, null) : new HtmlString(string.Empty);
        }

        public static HtmlString MakeEditIconButton(string dialogUrl, string linkText, string dialogTitle, bool hasPermission)
        {
            return hasPermission ? ModalDialogFormLink($"{BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-edit")} {linkText}", dialogUrl, dialogTitle, DefaultDialogWidth, "Save", "Cancel", new List<string> { "btn", "btn-firma" }, null, null) : new HtmlString(string.Empty);
        }

    }
}
