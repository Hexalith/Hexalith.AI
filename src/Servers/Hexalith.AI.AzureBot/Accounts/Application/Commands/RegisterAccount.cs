// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-25-2023
// ***********************************************************************
// <copyright file="RegisterAccount.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.AI.AzureBot.Accounts.Application.Commands;

using System.ComponentModel;
using System.Text.Json.Serialization;

using Hexalith.Domain.Events;

/// <summary>
/// Class AccountRegistered.
/// Implements the <see cref="BaseEvent" />.
/// </summary>
/// <seealso cref="BaseEvent" />
[Description("Register account")]
public class RegisterAccount : AccountCommand
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterAccount"/> class.
    /// </summary>
    /// <param name="domain">The domain.</param>
    /// <param name="name">The name.</param>
    /// <param name="administrators">The administrators.</param>
    [JsonConstructor]
    public RegisterAccount(string name)
        : base(name)
    {
    }
}