using System;
using System.Reflection;
using Xunit;
using Base.App;

namespace Base.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Sample Input
            string gameName1 = "Cricket";
            int maxPlayers1 = 11;
            string gameName2 = "Football";
            int maxPlayers2 = 11;
            int timeLimit = 90;

            // Create instances of Game and GameWithTimeLimit using reflection
            Type gameType = typeof(Game);
            Type gameWithTimeLimitType = typeof(GameWithTimeLimit);
            object game1 = Activator.CreateInstance(gameType)!;
            object game2 = Activator.CreateInstance(gameWithTimeLimitType)!;

            // Check for the existence of properties before using them
            PropertyInfo? game1NameProperty = gameType.GetProperty("Name");
            PropertyInfo? game1MaxPlayersProperty = gameType.GetProperty("MaxNumPlayers");
            PropertyInfo? game2NameProperty = gameWithTimeLimitType.GetProperty("Name");
            PropertyInfo? game2MaxPlayersProperty = gameWithTimeLimitType.GetProperty("MaxNumPlayers");
            PropertyInfo? game2TimeLimitProperty = gameWithTimeLimitType.GetProperty("TimeLimit");

            if (game1NameProperty == null || game1MaxPlayersProperty == null ||
                game2NameProperty == null || game2MaxPlayersProperty == null ||
                game2TimeLimitProperty == null)
            {
                Assert.Fail("One or more properties not found");
            }

            // Set the properties of Game and GameWithTimeLimit using reflection
            game1NameProperty.SetValue(game1, gameName1);
            game1MaxPlayersProperty.SetValue(game1, maxPlayers1);
            game2NameProperty.SetValue(game2, gameName2);
            game2MaxPlayersProperty.SetValue(game2, maxPlayers2);
            game2TimeLimitProperty.SetValue(game2, timeLimit);

            // Get the properties of Game and GameWithTimeLimit using reflection
            string game1Name = (string)game1NameProperty.GetValue(game1)!;
            int game1MaxPlayers = (int)game1MaxPlayersProperty.GetValue(game1)!;
            string game2Name = (string)game2NameProperty.GetValue(game2)!;
            int game2MaxPlayers = (int)game2MaxPlayersProperty.GetValue(game2)!;
            int game2TimeLimit = (int)game2TimeLimitProperty.GetValue(game2)!;

            // Assert the values
            Assert.Equal($"Maximum number of players for {gameName1} is {maxPlayers1}", $"Maximum number of players for {game1Name} is {game1MaxPlayers}");
            Assert.Equal($"Maximum number of players for {gameName2} is {maxPlayers2}", $"Maximum number of players for {game2Name} is {game2MaxPlayers}");
            Assert.Equal($"Time Limit for {gameName2} is {timeLimit} minutes", $"Time Limit for {game2Name} is {game2TimeLimit} minutes");
        }
    }
}
