// Copyright (c) Microsoft Corporation
// All rights reserved

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.Text;

namespace Microsoft.VisualStudio.Language.Intellisense
{
    /// <summary>
    /// Represents a list of suggested actions that are all applicable to a span of text in a <see cref="ITextBuffer" />.
    /// Global suggested actions are not applicable to any particular span of text.
    /// </summary>
    [CLSCompliant(false)]
    public class SuggestedActionSet
    {
        /// <summary>
        /// A list of suggested actions.
        /// </summary>
        public IEnumerable<ISuggestedAction> Actions { get; private set; }

        /// <summary>
        /// Gets the applicability span for this list of suggested actions.
        /// </summary>
        /// <remarks>
        /// The applicability span is the span of text in the <see cref="ITextBuffer" /> to which this
        /// a list of suggested actions pertains, if any.
        /// </remarks>
        public Span? ApplicableToSpan { get; private set; }

        /// <summary>
        /// Gets the <see cref="SuggestedActionSetPriority"/> value of this list of suggested actions.
        /// </summary>
        public SuggestedActionSetPriority Priority { get; private set; }

        /// <summary>
        /// Gets the title for this list of suggested actions.
        /// </summary>
        public object Title { get; private set; }

        /// <summary>
        /// The name of the <see cref="ISuggestedActionCategory"/> which this set of actions belongs to.
        /// </summary>
        /// <remarks>
        /// It is recommended to use the category names from <see cref="PredefinedSuggestedActionCategoryNames"/>.
        /// If no category is provided, a set is assumed to be <see cref="PredefinedSuggestedActionCategoryNames.Any"/>
        /// </remarks>
        public string CategoryName { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="SuggestedActionSet"/> for given list
        /// of suggested actions and optionally an applicable span of text.
        /// </summary>
        /// <param name="actions">A list of suggested actions.</param>
        /// <param name="priority">The <see cref="SuggestedActionSetPriority"/> value of this list of suggested actions</param>
        /// <param name="applicableToSpan">The applicability span for this list of suggested actions.</param>
        [Obsolete("Use fully specified constructor instead")]
        public SuggestedActionSet(IEnumerable<ISuggestedAction> actions,
                                  SuggestedActionSetPriority priority = SuggestedActionSetPriority.None,
                                  Span? applicableToSpan = null) : this(actions, title: null, priority: priority, applicableToSpan: applicableToSpan)
        { }

        /// <summary>
        /// Creates a new instance of the <see cref="SuggestedActionSet"/> for given list
        /// of suggested actions with a header and optionally an applicable span of text.
        /// </summary>
        /// <param name="actions">A list of suggested actions.</param>
        /// <param name="title">The title for this list of suggested actions.</param>
        /// <param name="priority">The <see cref="SuggestedActionSetPriority"/> value of this list of suggested actions</param>
        /// <param name="applicableToSpan">The applicability span for this list of suggested actions.</param>
        [Obsolete("Use fully specified constructor instead")]
        public SuggestedActionSet(IEnumerable<ISuggestedAction> actions, object title,
                                  SuggestedActionSetPriority priority = SuggestedActionSetPriority.None,
                                  Span? applicableToSpan = null) : this(null, actions, title, priority, applicableToSpan)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="SuggestedActionSet"/> for given list
        /// of suggested actions with a header and optionally an applicable span of text.
        /// </summary>
        /// <param name="categoryName">
        /// The name of the <see cref="ISuggestedActionCategory"/> to which all of these actions belong.
        /// </param>
        /// <param name="actions">A list of suggested actions.</param>
        /// <param name="title">The title for this list of suggested actions.</param>
        /// <param name="priority">The <see cref="SuggestedActionSetPriority"/> value of this list of suggested actions</param>
        /// <param name="applicableToSpan">The applicability span for this list of suggested actions.</param>
        public SuggestedActionSet(
            string categoryName,
            IEnumerable<ISuggestedAction> actions,
            object title = null,
            SuggestedActionSetPriority priority = SuggestedActionSetPriority.None,
            Span? applicableToSpan = null)
        {
            if (actions == null)
            {
                throw new ArgumentNullException(nameof(actions));
            }

            this.CategoryName = categoryName ?? PredefinedSuggestedActionCategoryNames.Any;
            this.Actions = actions.ToArray();
            this.Priority = priority;
            this.ApplicableToSpan = applicableToSpan;
            this.Title = title;
        }
    }
}
