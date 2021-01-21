using System;

namespace QuestOfTheRing
{
    internal class RandomHelper
    {
        public static int GetRandomNum(int num)
        {
            Random random = new Random();
            int randomNum = random.Next(num);
            return randomNum;
        }

        public static int GetRandomNum(int num1, int num2)
        {
            Random random = new Random();
            int randomNum = random.Next(num1, num2);
            return randomNum;
        }
    }
}