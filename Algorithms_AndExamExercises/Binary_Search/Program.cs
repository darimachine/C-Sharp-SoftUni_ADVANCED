using System;

namespace Binary_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int x = 10;
            Console.WriteLine(Binary_Search(number, x));
        }

        private static int Binary_Search(int[] number, int x)
        {
            int left = 0;
            int right = number.Length - 1;
            int mid = 0;
            while (left <= right)
            {
                mid = (right+left) / 2;
                if (number[mid] == x)
                {
                    return mid;
                   
                }
                else if (number[mid] > x)
                {
                    right = mid-1;
                }
                else
                {
                    left = mid+1;
                }
            }
            return -1;
        }
    }
}
