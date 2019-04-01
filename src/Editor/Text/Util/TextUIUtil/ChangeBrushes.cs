//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//  Licensed under the MIT License. See License.txt in the project root for license information.
//
namespace Microsoft.VisualStudio.Text.Utilities
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.Text.Document;
    using Microsoft.VisualStudio.Text.Tagging;

    internal static class ChangeBrushes
    {
        public static NormalizedSnapshotSpanCollection[] GetUnifiedChanges(ITextSnapshot snapshot, IEnumerable<IMappingTagSpan<ChangeTag>> tags)
        {
            List<Span>[] unnormalizedChanges = new List<Span>[4] {  null,
                                                                    new List<Span>(),
                                                                    new List<Span>(),
                                                                    new List<Span>()
                                                                 };
            foreach (IMappingTagSpan<ChangeTag> change in tags)
            {
                int type = (int)(change.Tag.ChangeTypes & (ChangeTypes.ChangedSinceOpened | ChangeTypes.ChangedSinceSaved));
                if (type != 0)
                    unnormalizedChanges[type].AddRange((NormalizedSpanCollection)(change.Span.GetSpans(snapshot)));
            }

            NormalizedSnapshotSpanCollection[] changes = new NormalizedSnapshotSpanCollection[4];
            for (int i = 1; (i <= 3); ++i)
                changes[i] = new NormalizedSnapshotSpanCollection(snapshot, unnormalizedChanges[i]);

            return changes;
        }
    }
}
