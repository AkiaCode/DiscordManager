﻿using DiscordManager.Command;

namespace DiscordManager.TestApp
{
    public class Test : CommandModule
    {
        [CommandName("Test"), RequirePermission(Permission.Admin)]
        public void TestMethod(string[] args)
        {
            ReplyAsync("Test");
        }
    }
}