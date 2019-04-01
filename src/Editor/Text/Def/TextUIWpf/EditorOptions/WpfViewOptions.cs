﻿//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//  Licensed under the MIT License. See License.txt in the project root for license information.
//
using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using Microsoft.VisualStudio.Utilities;

namespace Microsoft.VisualStudio.Text.Editor.OptionsExtensionMethods
{
    /// <summary>
    ///  Provides extension methods for options related to an <see cref="IWpfTextView"/>.
    /// </summary>
    public static class WpfViewOptionExtensions
    {
        #region Extension methods

        /// <summary>
        /// Determines whether the option to highlight the current line is enabled.
        /// </summary>
        /// <param name="options">The <see cref="IEditorOptions"/>.</param>
        /// <returns><c>true</c> if the highlight option was enabled, otherwise <c>false</c>.</returns>
        public static bool IsHighlightCurrentLineEnabled(this IEditorOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            return options.GetOptionValue<bool>(DefaultTextViewOptions.EnableHighlightCurrentLineId);
        }

        /// <summary>
        /// Determines whether the option to draw a gradient selection is enabled.
        /// </summary>
        /// <param name="options">The <see cref="IEditorOptions"/>.</param>
        /// <returns><c>true</c> if the draw selection gradient option was enabled, otherwise <c>false</c>.</returns>
        public static bool IsSimpleGraphicsEnabled(this IEditorOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            return options.GetOptionValue<bool>(DefaultTextViewOptions.EnableSimpleGraphicsId);
        }

        /// <summary>
        ///  Determines whether to allow mouse wheel zooming
        /// </summary>
        /// <param name="options">The set of editor options.</param>
        /// <returns><c>true</c> if the mouse wheel zooming is enabled, otherwise <c>false</c>.</returns>
        /// <remarks>Disabling the mouse wheel zooming does NOT turn off Zooming (it disables zooming using mouse wheel)</remarks>
        public static bool IsMouseWheelZoomEnabled(this IEditorOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            return options.GetOptionValue<bool>(DefaultTextViewOptions.EnableMouseWheelZoomId);
        }

        /// <summary>
        /// Specifies the appearance category.
        /// </summary>
        /// <param name="options">The <see cref="IEditorOptions"/>.</param>
        /// <returns>The appearance category, which determines where to look up font properties and colors.</returns>
        public static string AppearanceCategory(this IEditorOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            return options.GetOptionValue<string>(DefaultTextViewOptions.AppearanceCategory);
        }

        /// <summary>
        /// Specifies the persisted zoomlevel.
        /// </summary>
        /// <param name="options">The <see cref="IEditorOptions"/>.</param>
        /// <returns>The zoomlevel, which scales the view up or down.</returns>
        public static double ZoomLevel(this IEditorOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            return options.GetOptionValue<double>(DefaultTextViewOptions.ZoomLevelId);
        }
        #endregion
    }
}

namespace Microsoft.VisualStudio.Text.Editor
{
    /// <summary>
    /// Represents common <see cref="IWpfTextView"/> options.
    /// </summary>
    public static class DefaultWpfViewOptions
    {

        /// <summary>
        /// Determines what modifier key to use for go to definition by mouse click + modifier keypress.
        /// </summary>
        public const string ClickGoToDefModifierKeyName = "TextView/ClickGoToDefModifierKey";
        public static readonly EditorOptionKey<ModifierKeys> ClickGoToDefModifierKeyId = new EditorOptionKey<ModifierKeys>(ClickGoToDefModifierKeyName);
    }

    /// <summary>
    /// Determines what modifier key to use for go to definition by mouse click + modifier keypress.
    /// </summary>
    [Export(typeof(EditorOptionDefinition))]
    [Name(DefaultWpfViewOptions.ClickGoToDefModifierKeyName)]
    public sealed class ClickGotoDefModifierKeyOption : WpfViewOptionDefinition<ModifierKeys>
    {
        /// <summary>
        /// Gets the default value.
        /// </summary>
        public override ModifierKeys Default => ModifierKeys.Control;

        /// <summary>
        /// Gets the key for the option.
        /// </summary>
        public override EditorOptionKey<ModifierKeys> Key => DefaultWpfViewOptions.ClickGoToDefModifierKeyId;
    }
}
