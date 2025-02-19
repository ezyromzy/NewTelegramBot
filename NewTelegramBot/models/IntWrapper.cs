﻿using SKitLs.Bots.Telegram.ArgedInteractions.Argumenting.Prototype;

namespace NewTelegramBot.models
{
    internal class IntWrapper
    {
        [BotActionArgument(0)]
        public int Value { get; set; }

        public IntWrapper()
        { }
        public IntWrapper(int value) => Value = value;
    }
}
