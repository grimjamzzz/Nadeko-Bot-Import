﻿using NadekoBot.Core.Services.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;

namespace NadekoBot.Modules.CustomReactions
{
    public static class CustomReactionsExtensions
    {
        public static int ClearFromGuild(this DbSet<CustomReaction> crs, ulong guildId)
        {
            return crs.Delete(x => x.GuildId == guildId);
        }

        public static IEnumerable<CustomReaction> ForId(this DbSet<CustomReaction> crs, ulong id)
        {
            return crs
                .AsNoTracking()
                .AsQueryable()
                .Where(x => x.GuildId == id)
                .ToArray();
        }

        public static CustomReaction GetByGuildIdAndInput(this DbSet<CustomReaction> crs, ulong? guildId, string input)
        {
            return crs.FirstOrDefault(x => x.GuildId == guildId && x.Trigger.ToUpper() == input);
        }
    }
}
