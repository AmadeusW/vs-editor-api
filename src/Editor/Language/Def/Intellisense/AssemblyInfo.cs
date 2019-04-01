//********************************************************************************
// Copyright (c) Microsoft Corporation Inc. All rights reserved
//********************************************************************************
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Versioning;
using System.Security.Permissions;
using Microsoft.VisualStudio.Language.Intellisense;

//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//

[assembly: ComponentGuarantees(ComponentGuaranteesOptions.Stable)]

[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
#pragma warning disable 618
[assembly: SecurityPermission(SecurityAction.RequestMinimum, Flags = SecurityPermissionFlag.Execution)]
#pragma warning restore 618
[assembly: ReliabilityContract(Consistency.MayCorruptProcess, Cer.MayFail)]
[assembly: TypeForwardedTo(typeof(IInteractiveQuickInfoContent))]
