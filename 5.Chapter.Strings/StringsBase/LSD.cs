namespace LSD
{
    public class LSD
    {
        private string[] _aux;
        public LSD(string[] a, int w)
        {
            int N = a.Length;
            int R = 256;

            _aux = new string[N];
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
                    _aux[count[a[i][d]]++] = a[i];
                }

            }
        }

        public string[] Aux => _aux;
    }
}