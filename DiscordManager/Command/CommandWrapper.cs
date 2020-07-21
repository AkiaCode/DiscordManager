﻿using System.Linq;
using System.Reflection;
using Discord;

namespace DiscordManager.Command
{
    internal class CommandWrapper
    {
        public CommandWrapper(CommandName commandName, Usage usage, RequirePermission? permission, RequireBotPermission? botPermission, MethodInfo info)
        {
            _commandName = commandName.Names;
            Usage = usage;
            Permission = permission?.Permission ?? Permission.User;
            BotPermission = botPermission?.Permissions;
            MethodInfo = info;
        }

        private readonly string[] _commandName;
        public readonly Permission Permission;
        public readonly GuildPermission[]? BotPermission;
        public readonly MethodInfo MethodInfo;
        public readonly Usage Usage;
        
        public bool Contains(string name)
        {
            return _commandName.Contains(name);
        }
        
        /// <summary>
        ///     Check Permission
        /// </summary>
        /// <returns>return Missing Permissions But if Empty doesn't have Missing Permissions</returns>
        public GuildPermission[]? CheckPermissions(IGuildUser currentUser)
        {
            var currentPermission = currentUser.GuildPermissions;
            if (currentPermission.Administrator)
                return null;
            var missingPerms = BotPermission.Where(permission => !currentPermission.Has(permission)).ToArray();
            return missingPerms.Length == 0 ? null : missingPerms;
        }
    }
}