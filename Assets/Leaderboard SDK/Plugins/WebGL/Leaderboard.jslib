mergeInto(LibraryManager.library, {
    OpenLeaderboard: function (gameIdPtr) {
        var gameId = UTF8ToString(gameIdPtr);
        window.open("https://yourwebsite.com/leaderboard?game=" + gameId, "_blank");
    }
});