﻿////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation. All rights reserved
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;

namespace Microsoft.VisualStudio.Language.Intellisense
{
    /// <summary>
    /// Defines the names of the space reservation managers used by the default IntelliSense presenters.
    /// </summary>
    public static class IntellisenseSpaceReservationManagerNames
    {
        /// <summary>
        /// The space reservation manager name for statement completion.
        /// </summary>
        public const string CompletionSpaceReservationManagerName = "completion";

        /// <summary>
        /// The space reservation manager name for signature help.
        /// </summary>
        public const string SignatureHelpSpaceReservationManagerName = "signaturehelp";

        /// <summary>
        /// The space reservation manager name for Quick Info.
        /// </summary>
        public const string QuickInfoSpaceReservationManagerName = "quickinfo";

        /// <summary>
        /// The space reservation manager name for smart tags.
        /// </summary>
        [Obsolete("SmartTag API is no longer supported. To find out more about the replacement API, Light Bulb, refer to http://go.microsoft.com/fwlink/?LinkId=394601.")]
        public const string SmartTagSpaceReservationManagerName = "smarttag";
    }
}
