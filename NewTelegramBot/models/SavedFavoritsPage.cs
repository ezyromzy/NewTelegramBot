using SKitLs.Bots.Telegram.AdvancedMessages.Model.Menus;
using SKitLs.Bots.Telegram.AdvancedMessages.Prototype;
using SKitLs.Bots.Telegram.ArgedInteractions.Argumenting;
using SKitLs.Bots.Telegram.ArgedInteractions.Interactions.Model;
using SKitLs.Bots.Telegram.Core.Model.UpdatesCasting;
using SKitLs.Bots.Telegram.PageNavs;
using SKitLs.Bots.Telegram.PageNavs.Prototype;
using NewTelegramBot.Users;

namespace NewTelegramBot.models
{
    internal class SavedFavoritsPage : IPageMenu
    {
        public BotArgedCallback<GeoCoderInfo> OpenCallBack { get; private set; }

        public SavedFavoritsPage(BotArgedCallback<GeoCoderInfo> openCallback) =>
            OpenCallBack = openCallback;

        public IMesMenu Build(IBotPage? previous, IBotPage owner, ISignedUpdate update)
        {
            IMenuManager menuManager = update.Owner.ResolveService<IMenuManager>();

            var res = new PairedInlineMenu()
            {
                Serializer = update.Owner.ResolveService<IArgsSerilalizerService>()
            };

            if (update.Sender is BotUser user)
                foreach (var favorite in user.Favs)
                    res.Add(favorite.Name, OpenCallBack, favorite);

            if (previous != null)
                res.Add("Назад", menuManager.BackCallback, singleLine: true);

            return res;
        }
    }
}
