namespace Generics
{
    
    partial class Program
    {
        class ArrayCreator<T>
        {
            
            static T[] Create<T>(int length,T item) where T: class
            {
                T[] array = new T[length];
                for (int i = 0; i < length; i++)
                {
                    array[i] = null;
                }
                return array;
            }
        }
    }
}
