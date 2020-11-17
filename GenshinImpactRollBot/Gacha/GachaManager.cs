using System;

namespace GenshinImpactRollBot.Gacha
{
    public static class GachaManager
    {
        private static readonly Random _random;
        
        static GachaManager()
        {
            _random = new Random();
        }

        public static GachaResult Roll()
        {
            var result = new GachaResult();

            var randomValue = _random.NextDouble() * 100;

            result.Name = randomValue > 0.05d ? "Рохатка" : "Мона!1111";

            return result;
        }
    }
}