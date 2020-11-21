namespace StringsBase
{
    public class LSD
    {
        public static void Sort(string[] a, int w, int R)
        {
            string[] aux = new string[a.Length];
            Sort(a, w, aux, R);
        }
        private static void Sort(string[] a, int w, string[] aux, int R)
        {
            int N = a.Length;
            for (int d = w - 1; d >= 0; d--)
            {
                int[] count = new int[R + 1];
                for (int i = 0; i < N; i++)
                {
                    count[a[i][d] + 1]++;
                }

                for (int r = 0; r < R; r++)
                {
                    count[r + 1] += count[r];
                }

                for (int i = 0; i < N; i++)
                {
                    aux[count[a[i][d]]++] = a[i];
                }

                for (int i = 0; i < a.Length; i++)
                {
                    a[i] = aux[i];
                }
            }
        }
        // public LSD(string[] a, int w)
        // {
        //     int N = a.Length;
        //     int R = 256;

        //     _aux = new string[N];
        //     for (int d = w - 1; d >= 0; d--)
        //     {
        //         int[] count = new int[R + 1];
        //         for (int i = 0; i < N; i++)
        //         {
        //             count[a[i][d] + 1]++;
        //         }

        //         for (int r = 0; r < R; r++)
        //         {
        //             count[r + 1] += count[r];
        //         }

        //         for (int i = 0; i < N; i++)
        //         {
        //             _aux[count[a[i][d]]++] = a[i];
        //         }
        //     }
        // }
    }
}