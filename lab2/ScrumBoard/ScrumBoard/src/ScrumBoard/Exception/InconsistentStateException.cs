// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace ScrumBoard.ScrumBoard.Exception;

public class InconsistentStateException : System.Exception
{
    public InconsistentStateException()
    {
    }

    public InconsistentStateException(string message)
        : base(message)
    {
    }

    public InconsistentStateException(string message, System.Exception inner)
        : base(message, inner)
    {
    }
}
